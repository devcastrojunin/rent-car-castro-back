using System.ComponentModel.DataAnnotations;

namespace RentCarCastro.Requests
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
