using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users == null)
            {
                return BadRequest("Nenhum usuário encontrado.");
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById([FromRoute] Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return BadRequest($"Usuário com id: {id} não foi encontrado.");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddNewUser([FromBody] UserModel user)
        {

            UserModel userModel = await _userRepository.AddUsersAsync(user);

            if (userModel == null)
            {
                return BadRequest("Erro ao salvar usuário");
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user)
        {

            UserModel userModel = await _userRepository.UpdateUserAsync(user);

            if (userModel == null)
            {
                return BadRequest("Erro ao atualizar usuário");
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            (bool status, string message) = await _userRepository.DeleteUserAsync(user);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, new { Status = true, Message = message });
        }
    }
}
