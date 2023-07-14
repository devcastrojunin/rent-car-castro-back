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
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null) return null;

            return user;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {

            List<UserModel> users = await _dbContext.Users.ToListAsync();

            return users;
        }

        public async Task<UserModel> AddUsersAsync(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
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
