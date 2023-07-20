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
        public DbSet<RoleModel> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel
                {
                    Id = 1,
                    Name = "admin"   
                },
                new RoleModel
                {
                    Id = 2,
                    Name = "reader"
                }

            );


            Random rnd = new Random();
            int num = rnd.Next();

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = num,
                    Name = "Junior Castro Admin",
                    UserName = "junior.castro",
                    Email = "junior.castro@teste.com",
                    Password = "admin@123",
                    CPF = "12345678936",
                    CNPJ = "",
                    IsActive = true,
                    RoleId = 1
                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
