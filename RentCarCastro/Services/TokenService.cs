using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentCarCastro.Data;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentCarCastro.Services
{
    public class TokenService : ITokenService
    {
        public IConfiguration _configuration;
        private readonly ApiDbContext _context;

        public TokenService(IConfiguration config, ApiDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        public async Task<TokenDTO> UserIsLogged(TokenModel userData)
        {
            var user = await GetUser(userData.Email, userData.Password);

            if (userData != null && userData.Email != null && userData.Password != null) { 
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", user.Id.ToString()),
                            new Claim("Name", user.Name),
                            new Claim("UserName", user.UserName),
                            new Claim("Email", user.Email)
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var tokenDto = new TokenDTO
                    {
                        token = token,
                        user = new UserDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            UserName = user.UserName,
                            Email = user.Email,
                            CPF = user.CPF,
                            CNPJ = user.CNPJ,
                            IsActive = user.IsActive
                        },
                    };

                    return tokenDto;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<UserModel> GetUser(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
