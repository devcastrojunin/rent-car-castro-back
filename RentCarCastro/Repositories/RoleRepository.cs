using Microsoft.EntityFrameworkCore;
using RentCarCastro.Data;
using RentCarCastro.Models;
using RentCarCastro.Repositories.Interfaces;

namespace src.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApiDbContext _dbContext;

        public RoleRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public async Task<List<RoleModel>> GetAllRolesAsync()
        {

            List<RoleModel> roles = await _dbContext.Roles.ToListAsync();

            return roles;
        }
    }
}
