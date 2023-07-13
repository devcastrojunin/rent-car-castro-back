using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarCastro.Data;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;

namespace src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _dbContext;

        public UserRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            UserModel user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) return null;

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                CPF = user.CPF,
                CNPJ = user.CNPJ,
                IsActive = user.IsActive
            };

            return userDTO;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            List<UserDTO> userDTO = new List<UserDTO>();

            List<UserModel> users = await _dbContext.Users.ToListAsync();

            foreach (var item in users)
            {
                userDTO.Add(new UserDTO
                
                {
                    Id = item.Id,
                    Name = item.Name,
                    UserName = item.UserName,
                    Email = item.Email,
                    CPF = item.CPF,
                    CNPJ = item.CNPJ,
                    IsActive = item.IsActive
                });
            }

            return userDTO;
        }

        public async Task<UserDTO> AddUsersAsync(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                CPF = user.CPF,
                CNPJ = user.CNPJ,
                IsActive = user.IsActive
            };

            return userDTO;
        }

        public async Task<UserDTO> UpdateUserAsync(UserModel user)
        {
            try
            {
                var userModified = _dbContext.Entry(user).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    CPF = user.CPF,
                    CNPJ = user.CNPJ,
                    IsActive = user.IsActive
                };

                return userDTO;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {

            try
            {
                var userModel = await _dbContext.Users.FindAsync(id);

                _dbContext.Users.Remove(userModel);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
