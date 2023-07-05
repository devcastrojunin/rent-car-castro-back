using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;
using src.Repositories.Interfaces;

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
            return await _userRepository.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUsers(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
    }
}
