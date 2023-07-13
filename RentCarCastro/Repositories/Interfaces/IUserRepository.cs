using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;

namespace RentCarCastro.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> AddUsersAsync(UserModel user);
        Task<UserDTO> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int id);
    }
}
