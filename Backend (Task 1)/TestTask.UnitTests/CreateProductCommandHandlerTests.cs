using Moq;
using TestTask.Application.Handlers.Commands;
using TestTask.Domain;
using TestTask.Domain.Entities;

public class CreateProductCommandHandlerTests
{
    [Fact]
    public async Task Handle_ProductsAddedToRepository()
    {
        // Arrange
        var data = new List<Dictionary<int, string>>
        {
            new Dictionary<int, string> { { 1, "value32" } },
            new Dictionary<int, string> { { 2, "value12" } }
        };
        var command = new CreateProductCommand(data);

        var mockRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CreateProductCommandHandler(mockRepository.Object, mockUnitOfWork.Object);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.AddRangeAsync(It.IsAny<IEnumerable<Product>>()), Times.Once);
        mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }
}
