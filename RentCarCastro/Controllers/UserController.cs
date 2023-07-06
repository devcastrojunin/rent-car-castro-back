using Microsoft.AspNetCore.Mvc;
using RentCarCastro.Data;
using RentCarCastro.Models;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Requests;

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

        [HttpPost]
        public async Task<UserModel> AddNewUser(UserModel user)
        {
            await _userRepository.AddUsersAsync(user);

            return user;
        }
    }
}
