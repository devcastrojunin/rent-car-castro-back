using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;

namespace RentCarCastro.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> AddUsersAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(UserModel user);
    }
}
