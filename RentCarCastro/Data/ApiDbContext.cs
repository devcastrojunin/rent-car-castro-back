using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RentCarCastro.Models;

namespace RentCarCastro.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {            
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random rnd = new Random();

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel {
                    Id = rnd.Next(),
                    Name = "Junior Castro",
                    UserName = "junior.castro",
                    Email = "teste@teste.com",
                    Password = "admin@123",
                    CPF = "27904525801",
                    CNPJ = "",
                    IsActive =  true
                },
                new UserModel
                {
                    Id = rnd.Next(),
                    Name = "José da Silva",
                    UserName = "jose.silva",
                    Email = "teste@teste2.com",
                    Password = "admin@123",
                    CPF = "27904525801",
                    CNPJ = "",
                    IsActive = true
                },
                new UserModel
                {
                    Id = rnd.Next(),
                    Name = "Maria Cecília",
                    UserName = "maria.cecilia",
                    Email = "teste@teste3.com",
                    Password = "admin@123",
                    CPF = "27904525801",
                    CNPJ = "",
                    IsActive = false
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
