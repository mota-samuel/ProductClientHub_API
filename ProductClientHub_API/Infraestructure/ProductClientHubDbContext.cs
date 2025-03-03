using Microsoft.EntityFrameworkCore;
using ProductClientHub_API.Entities;

namespace ProductClientHub_API.Infraestructure
{
    public class ProductClientHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\samur\\source\\repos\\ProductClientHub_API\\ProductClientHubDB.db");
        }
    }
}
