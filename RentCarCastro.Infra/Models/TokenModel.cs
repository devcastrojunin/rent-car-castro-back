using System.ComponentModel.DataAnnotations;

namespace RentCarCastro.Models
{
    public class TokenModel
    {
        [Required(ErrorMessage = "E-mail obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        public string? Password { get; set; }

    }
}
