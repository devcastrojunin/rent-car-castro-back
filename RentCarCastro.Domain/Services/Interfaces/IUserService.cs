using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Responses;

namespace RentCarCastro.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUser(int id);
        Task<UserResponse<UserDTO>> AddUser(UserModel user);
        Task<UserDTO> UpdateUser(UserModel user);
        Task<bool> DeleteUser(int id);
    }
}
