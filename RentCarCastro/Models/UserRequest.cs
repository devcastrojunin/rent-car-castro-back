using System.Text.Json.Serialization;

namespace RentCarCastro.Models
{
    public class UserRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
