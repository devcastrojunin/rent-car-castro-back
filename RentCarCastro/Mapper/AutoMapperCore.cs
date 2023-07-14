using AutoMapper;
using RentCarCastro.Models;
using RentCarCastro.Models.DTOs;

namespace RentCarCastro.Mapper
{
    public class AutoMapperCore : Profile
    {
        public AutoMapperCore()
        {
            User();
        }

        private void User()
        {
            CreateMap<UserModel, UserDTO>();
        }
    }
}
