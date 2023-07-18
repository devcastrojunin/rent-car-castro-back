using RentCarCastro.Models;
using RentCarCastro.Responses;

namespace RentCarCastro.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetAllRolesAsync();
    }
}
