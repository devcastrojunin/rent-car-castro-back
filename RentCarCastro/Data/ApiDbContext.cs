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
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel {
                    Id = Guid.NewGuid(),
                    Name = "Junior Castro",
                    Email = "teste@teste.com",
                    Password = "admin@123",
                    CPF = "27904525801",
                    CNPJ = "",
                    IsActive =  true
                },
                new UserModel
                {
                    Id = Guid.NewGuid(),
                    Name = "José da Silva",
                    Email = "teste@teste2.com",
                    Password = "admin@123",
                    CPF = "27904525801",
                    CNPJ = "",
                    IsActive = true
                },
                new UserModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Maria Cecília",
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
