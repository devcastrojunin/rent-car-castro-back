using System.ComponentModel.DataAnnotations;

namespace RentCarCastro.Models
{
    public class UserModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        public string? CPF { get; set; }

        public string? CNPJ { get; set; }
        
        public bool IsActive { get; set; } = true;

    }
}
