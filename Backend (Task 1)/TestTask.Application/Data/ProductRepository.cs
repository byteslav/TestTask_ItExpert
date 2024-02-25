using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTask.Domain;
using TestTask.Domain.Entities;

namespace TestTask.Application.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<Product> products)
        {
            await _context.Products.ExecuteDeleteAsync();
            await _context.Products.AddRangeAsync(products);
        }

        public async Task<IEnumerable<Product>> GetAll(IEnumerable<Expression<Func<Product, bool>>> filters)
        {
            IQueryable<Product> products = _context
                .Products
                .AsNoTracking();

            foreach (var filter in filters)
            {
                products = products.Where(filter);
            }

            return await products.ToListAsync();
        }
    }
}
