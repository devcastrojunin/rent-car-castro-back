using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;
using src.Repositories.Interfaces;

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

    }
}
