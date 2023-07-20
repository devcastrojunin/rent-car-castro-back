﻿using RentCarCastro.Models;
using RentCarCastro.Responses;

namespace RentCarCastro.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> GetUserByEmailAndPassword(string email, string password);
        Task<UserResponse<UserModel>> AddUsersAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int id);
    }
}
