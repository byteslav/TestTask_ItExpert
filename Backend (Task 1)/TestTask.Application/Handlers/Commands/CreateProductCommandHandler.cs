using MediatR;
using TestTask.Domain.Entities;
using TestTask.Domain;
using TestTask.Application.Utils;

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
            var products = ManualConverter.MapFromDictionaryToProductsList(command.Data);
            var orderedProducts = products.OrderBy(p => p.Code);

            await _productRepository.AddRangeAsync(orderedProducts);

            await _unitOfWork.CompleteAsync();
        }
    }
}
