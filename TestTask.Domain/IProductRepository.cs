using System.Linq.Expressions;
using TestTask.Domain.Entities;

namespace TestTask.Domain
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        void AddRange(IEnumerable<Product> products);
        void Delete(int id);
        Task<IEnumerable<Product>> GetAll(IEnumerable<Expression<Func<Product, bool>>> filters);
    }
}
