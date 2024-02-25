using System.Linq.Expressions;
using TestTask.Domain.Entities;

namespace TestTask.Domain
{
    public interface IProductRepository
    {
        Task AddRangeAsync(IEnumerable<Product> products);
        Task<IEnumerable<Product>> GetAll(IEnumerable<Expression<Func<Product, bool>>> filters);
    }
}
