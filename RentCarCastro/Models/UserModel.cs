﻿namespace RentCarCastro.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
