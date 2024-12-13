using RentCarCastro.Models;

namespace RentCarCastro.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetAllRolesAsync();
    }
}
