using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarCastro.Data;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Responses;

namespace src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _dbContext;

        public UserRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null) return null;

            return user;
        }

        public async Task<UserModel> GetUserByEmailAsync(UserModel user)
        {
            var userData = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            return userData;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {

            List<UserModel> users = await _dbContext.Users.ToListAsync();

            return users;
        }

        public async Task<UserResponse<UserModel>> AddUsersAsync(UserModel user)
        {
            var hasUserRegistered = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (hasUserRegistered != null)
            {
                var userResponse = new UserResponse<UserModel>
                {
                    Data = null,
                    ErrorMessage = "E-mail já cadastrado na base"
                };

                return userResponse;
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            if (user == null)
            {
                return new UserResponse<UserModel>
                {
                    Data = null,
                    ErrorMessage = "Falha ao cadastrar usuário"
                };
            }

            return new UserResponse<UserModel>
            {
                Data = user,
                ErrorMessage = null
            };
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return user;

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
