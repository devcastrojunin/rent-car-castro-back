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
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> AddUsersAsync(UserModel user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;

        }

    }
}
