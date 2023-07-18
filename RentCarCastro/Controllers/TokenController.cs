using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace RentCarCastro.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TokenModel user)
        {
            var userData = await _tokenService.UserIsLogged(user);

            if (userData != null)
            {
                return Ok(new { user = userData.user, token = new JwtSecurityTokenHandler().WriteToken(userData.token) });
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        
    }
}
