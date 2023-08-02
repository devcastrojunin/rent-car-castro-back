using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentCarCastro.Models
{
    public class UserModel : SetDate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string? Name { get; set; }

        public string? UserName { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]  
        public string? Password { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        public string? CPF { get; set; }

        public string? CNPJ { get; set; }
        
        public bool? IsActive { get; set; } = true;

        [JsonIgnore]
        public RoleModel? Role { get; set; }
        public int RoleId { get; set; } = 2;

    }
}
