using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using RentCarCastro.Models;
using RentCarCastro.Repositories.Interfaces;
using RentCarCastro.Services;
using RentCarCastro.Services.Interfaces;

namespace RentCarCastro.Tests.Services
{
    [TestClass]
    public class TokenServiceTest
    {
        private IUserService _userService;
        private ITokenService _tokenService;
        private IConfiguration _configuration;
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

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Jwt:Issuer", "testissuer"),
                    new KeyValuePair<string, string>("Jwt:Audience", "testaudience"),
                    new KeyValuePair<string, string>("Jwt:Key", "testkey"),
                    new KeyValuePair<string, string>("Jwt:Subject", "testsubject")
                })
                .Build();

            _tokenService = new TokenService(_configuration, _userRepositoryMock.Object);

            _userService = new UserService(
                _userRepositoryMock.Object,
                _mapperMock.Object,
                _roleRepositoryMock.Object);

        }

        [TestMethod]
        public async Task Login_Authentication_Returns_Error()
        {
            _userRepositoryMock.Setup(u => u.GetUserByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((UserModel)null);

            var userData = new TokenModel
            {
                Email = "testuser@test.com",
                Password = "testpassword"
            };

            var tokenDto = await _tokenService.UserIsLogged(userData);

            Assert.IsNull(tokenDto);

        }

        [TestMethod]
        public async Task UserIsLogged_WithValidUser_ReturnsToken()
        {
            var user = new UserModel
            {
                Id = 1,
                Name = "Test User",
                UserName = "testuser",
                Email = "testuser@test.com",
                RoleId = 2,
                Password = "testpassword",
                CNPJ = "",
                CPF = "12345678985",
                IsActive = true
            };

            _userRepositoryMock.Setup(u => u.GetUserByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);

            var userData = new TokenModel
            {
                Email = "testuser@test.com",
                Password = "testpassword"
            };

            var tokenDto = await _tokenService.UserIsLogged(userData);

            Assert.IsNotNull(tokenDto);
            Assert.IsNotNull(tokenDto.token);
            Assert.IsNotNull(tokenDto.user);
        }
    }
}
