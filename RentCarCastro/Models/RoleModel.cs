using System.Text.Json.Serialization;

namespace RentCarCastro.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<UserModel> User { get; set; }

    }
}
