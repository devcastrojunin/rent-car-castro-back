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
        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            try
            {
                UserModel user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null) return null;

                return user;
            }
            catch
            {
                return null;
            }


        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            try
            {
                List<UserModel> users = await _dbContext.Users.ToListAsync();

                if (users == null) return null;

                return users;
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserModel> AddUsersAsync(UserModel user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user;

            }
            catch
            {
                return null;
            }


        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteUserAsync(UserModel user)
        {
            try
            {
                var dbUser = await _dbContext.Users.FindAsync(user.Id);

                if (dbUser == null)
                {
                    return (false, "Usuário não encontrado");
                }

                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return (true, "Usuário removido com sucesso");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao remover usuário: {ex.Message}");
            }
        }
    }
}
