using MediatR;
using TestTask.Domain.Entities;
using TestTask.Domain;

namespace TestTask.Application.Handlers.Commands
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var products = MapFromDictionaryToProductsList(command.Data);
            var orderedProducts = products.OrderBy(p => p.Code);

            await _productRepository.AddRangeAsync(orderedProducts);

            await _unitOfWork.CompleteAsync();
        }

        private static List<Product> MapFromDictionaryToProductsList(IEnumerable<Dictionary<int, string>> dictionaries)
        {
            var products = new List<Product>();

            foreach (var dict in dictionaries)
            {
                var p = dict.First();
                var product = new Product(p.Key, p.Value);

                products.Add(product);
            }

            return products;
        }
    }
}
