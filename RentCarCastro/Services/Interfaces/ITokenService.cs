using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;

namespace RentCarCastro.Services.Interfaces
{
    public interface ITokenService
    {
        Task<UserModel> GetUser(string email, string password);
        Task<TokenDTO> UserIsLogged(UserModel userData);
    }
}
