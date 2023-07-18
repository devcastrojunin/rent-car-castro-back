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

            base.OnModelCreating(modelBuilder);
        }
    }
}
