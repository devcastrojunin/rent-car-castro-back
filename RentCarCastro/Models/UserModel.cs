using System.ComponentModel.DataAnnotations;

namespace RentCarCastro.Models
{
    public class UserModel
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

    }
}
