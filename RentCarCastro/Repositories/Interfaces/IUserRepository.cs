using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;

namespace RentCarCastro.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(Guid id);
        Task<UserModel> AddUsersAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<(bool, string)> DeleteUserAsync(UserModel user);
    }
}
