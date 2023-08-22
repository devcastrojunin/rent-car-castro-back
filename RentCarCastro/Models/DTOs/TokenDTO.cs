using System.IdentityModel.Tokens.Jwt;

namespace RentCarCastro.Models.DTOs
{
    public class TokenDTO
    {
        public UserDTO? user { get; set; }
        public JwtSecurityToken? token { get; set; }
    }
}
