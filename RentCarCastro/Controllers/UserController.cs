using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Responses;
using RentCarCastro.Services.Interfaces;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(
            IUserRepository userRepository,
            IUserService userService
        )
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users == null)
            {
                return BadRequest("Nenhum usuário encontrado.");
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return BadRequest($"Usuário com id: {id} não foi encontrado.");
            }           

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse<UserDTO>>> AddNewUser([FromBody] UserModel user)
        {

            var userModel = await _userService.AddUser(user);

            if (userModel.Data == null)
            {
                return BadRequest(userModel.ErrorMessage);
            }

            return Ok(userModel.Data);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserModel user)
        {

            var userModel = await _userService.UpdateUser(user);

            if (userModel == null)
            {
                return BadRequest("Erro ao atualizar usuário");
            }

            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var userWasRemoved = await _userService.DeleteUser(id);

            if (userWasRemoved == false)
            {
                return BadRequest(new { Status = false, Message = "Falha ao remover usuário" });
            }

            return Ok(new { Status = true, Message = "Usuário removido com sucesso." });
        }
    }
}
