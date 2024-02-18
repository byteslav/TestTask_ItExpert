using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public void AddRange(IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
        }

        public void Delete(int id)
        {
            var productToDelete = _context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (productToDelete == null)
            {
                throw new ArgumentNullException(nameof(productToDelete), $"There is no product with Id = {id}");
            }

            _context.Products.Remove(productToDelete);
        }

        public async Task<IEnumerable<Product>> GetAll(IEnumerable<Expression<Func<Product, bool>>> filters)
        {
            IQueryable<Product> products = _context.Products;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    products = products.Where(filter);
                }
            }

            return await products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), $"There is no product with Id = {id}");
            }

            return product;
        }
    }
}
