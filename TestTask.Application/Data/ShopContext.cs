using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entities;

namespace TestTask.Application.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
    }
}
