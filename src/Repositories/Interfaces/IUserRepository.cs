using src.Models;

namespace src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
    }
}
