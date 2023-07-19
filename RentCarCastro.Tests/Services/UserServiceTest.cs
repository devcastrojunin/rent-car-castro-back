using AutoMapper;
using Moq;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Services;
using RentCarCastro.Services.Interfaces;

namespace RentCarCastro.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _userService;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IRoleRepository> _roleRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Initialize()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _mapperMock = new Mock<IMapper>();

            _roleRepositoryMock.Setup(r => r.GetAllRolesAsync()).ReturnsAsync(new List<RoleModel>());

            _userService = new UserService(
                _userRepositoryMock.Object, 
                _mapperMock.Object, 
                _roleRepositoryMock.Object);
        }

        [TestMethod]
        public async Task Get_All_User_Whit_Return_Error()
        {
            List<UserModel> userResponse = new List<UserModel>();

            _userRepositoryMock.Setup(u => u.GetAllUsersAsync()).ReturnsAsync(userResponse);

            List<UserDTO> users = await _userService.GetAllUsers();

            Assert.AreEqual(users.Count, 0);

        }

        [TestMethod]
        public async Task Get_All_User_Whit_Return_Success()
        {
            Random rnd = new Random();
            int num = rnd.Next();

            UserModel user = new UserModel
            {
                Id = num,
                CNPJ = "",
                CPF = "13467925",
                Email = "teste@teste.com",
                IsActive = true,
                Name = "Test",
                Password = "Password",
                RoleId = 2,
                UserName = "Test",
                Role = new RoleModel
                {
                    Name = "Reader",
                    Id = 2,
                }
            };

            List<UserModel> userResponse = new List<UserModel>();

            userResponse.Add(user);

            _userRepositoryMock.Setup(u => u.GetAllUsersAsync()).ReturnsAsync(userResponse);

            _mapperMock.Setup(m => m.Map<List<UserDTO>>(It.IsAny<List<UserModel>>())).Returns(userResponse.Select(u => new UserDTO
            {
                Id = u.Id,
                CNPJ = u.CNPJ,
                CPF = u.CPF,
                Email = u.Email,
                IsActive = u.IsActive,
                Name = u.Name,
                UserName = u.UserName,
                Role = new RoleModel
                {
                    Name = u.Role.Name,
                    Id = u.Role.Id
                }
            }).ToList());

            List<UserDTO> users = await _userService.GetAllUsers();

            Assert.IsNotNull(users);
        }
    }
}
