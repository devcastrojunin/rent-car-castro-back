using System.Text.Json.Serialization;

namespace RentCarCastro.Models
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
