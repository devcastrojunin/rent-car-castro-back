using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
