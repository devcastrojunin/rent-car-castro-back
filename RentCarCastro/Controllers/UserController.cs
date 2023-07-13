using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();

            if (users == null)
            {
                return BadRequest("Nenhum usuário encontrado.");
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return BadRequest($"Usuário com id: {id} não foi encontrado.");
            }           

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddNewUser([FromBody] UserModel user)
        {

            var userModel = await _userRepository.AddUsersAsync(user);

            if (userModel == null)
            {
                return BadRequest("Erro ao salvar usuário");
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserModel user)
        {

            var userModel = await _userRepository.UpdateUserAsync(user);

            if (userModel == null)
            {
                return BadRequest("Erro ao atualizar usuário");
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var userWasRemoved = await _userRepository.DeleteUserAsync(id);

            if (userWasRemoved == false)
            {
                return BadRequest(new { Status = false, Message = "Falha ao remover usuário" });
            }

            return Ok(new { Status = true, Message = "Usuário removido com sucesso." });
        }
    }
}
