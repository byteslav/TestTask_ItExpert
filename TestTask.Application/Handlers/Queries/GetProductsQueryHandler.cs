using MediatR;
using TestTask.Domain.Entities;
using TestTask.Domain;
using System.Linq.Expressions;

namespace TestTask.Application.Handlers.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var filters = new List<Expression<Func<Product, bool>>>();

            if (query.Code.HasValue) filters.Add(p => p.Code == query.Code);
            if (!string.IsNullOrEmpty(query.Value)) filters.Add(p => p.Value == query.Value);

            var products = await _productRepository.GetAll(filters);

            return products;
        }
    }
}
