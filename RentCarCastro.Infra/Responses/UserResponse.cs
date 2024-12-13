using RentCarCastro.Models;

namespace RentCarCastro.Responses
{
    public class UserResponse<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
