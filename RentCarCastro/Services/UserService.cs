using AutoMapper;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Services.Interfaces;

namespace RentCarCastro.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var usersModel = await _userRepository.GetAllUsersAsync();

            var usersDto = _mapper.Map<List<UserDTO>>(usersModel);

            return usersDto;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var usersModel = await _userRepository.GetUserByIdAsync(id);

            var userDto = _mapper.Map<UserDTO>(usersModel);

            return userDto;
        }

        public async Task<UserDTO> AddUser(UserModel user)
        {
            var usersModel = await _userRepository.AddUsersAsync(user);
            var usersDto = _mapper.Map<UserDTO>(usersModel);

            return usersDto;
        }

        public async Task<UserDTO> UpdateUser(UserModel user)
        {
            var usersModel = await _userRepository.UpdateUserAsync(user);
            var usersDto = _mapper.Map<UserDTO>(usersModel);

            return usersDto;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUserAsync(id);

            return user ? true : false;
        }        
    }
}
