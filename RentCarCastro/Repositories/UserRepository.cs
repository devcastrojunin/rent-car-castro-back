using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarCastro.Data;
using RentCarCastro.Models;
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
            UserModel user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
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
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUserAsync(UserModel user)
        {

            try
            {
                var userModel = await _dbContext.Users.FindAsync(user.Id);

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
