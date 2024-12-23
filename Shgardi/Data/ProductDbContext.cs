using Microsoft.EntityFrameworkCore;
using Shgardi.Models;

namespace Shgardi.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Product;Integrated Security=false");
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
    }
}
