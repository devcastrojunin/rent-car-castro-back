using RentCarCastro.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentCarCastro.Models.DTOs
{
    public class UserDTO : SetDate
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }

        public bool? IsActive { get; set; } = true;

        public RoleNameEnum RoleName { get; set; } = RoleNameEnum.READER;        

        public RoleModel Role { get; set; }

    }
}
