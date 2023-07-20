using AutoMapper;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Responses;
using RentCarCastro.Services.Interfaces;

namespace RentCarCastro.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository, 
            IMapper mapper,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var usersModel = await _userRepository.GetAllUsersAsync();
            var rolesModel = await _roleRepository.GetAllRolesAsync();

            var userRes = new List<UserDTO>();

            foreach (var user in usersModel) {
                userRes.Add(new UserDTO
                {
                    CNPJ = user.CNPJ,
                    CPF = user.CPF,
                    Email = user.Email,
                    Id = user.Id,
                    IsActive = user.IsActive,
                    Name = user.Name,
                    UserName = user.UserName,
                    Role = rolesModel.Find(x => x.Id == user.RoleId)
                });
            }
            return userRes;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var usersModel = await _userRepository.GetUserByIdAsync(id);

            if (usersModel == null)
                return null;

            var rolesModel = await _roleRepository.GetAllRolesAsync();

            var role = rolesModel.Find(x => x.Id == usersModel.RoleId);

            var userDto = _mapper.Map<UserDTO>(usersModel);

            if (role == null) return null;

            userDto.Role = role;
            


            return userDto;
        }

        public async Task<UserResponse<UserDTO>> AddUser(UserModel user)
        {
            
            var usersModel = await _userRepository.AddUsersAsync(user);
            var rolesModel = await _roleRepository.GetAllRolesAsync();
            var role = rolesModel.Find(x => x.Id == usersModel.Data.RoleId);

            if (usersModel.Data == null)
            {
                return new UserResponse<UserDTO>
                {
                    Data = null,
                    ErrorMessage = usersModel.ErrorMessage
                };
            }

            var userDto = _mapper.Map<UserDTO>(usersModel.Data);
            userDto.Role = role;

            var userResponse = new UserResponse<UserDTO>
            {
                Data = userDto,
                ErrorMessage = usersModel.ErrorMessage
            };

            return userResponse;

        }

        public async Task<UserDTO> UpdateUser(UserModel user)
        {
            var usersModel = await _userRepository.UpdateUserAsync(user);
            var rolesModel = await _roleRepository.GetAllRolesAsync();

            var role = rolesModel.Find(x => x.Id == usersModel.RoleId);

            var userDto = _mapper.Map<UserDTO>(usersModel);

            userDto.Role = role;

            return userDto;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUserAsync(id);

            return user ? true : false;
        }        
    }
}
