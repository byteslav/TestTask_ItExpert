using System.Linq.Expressions;
using Moq;
using TestTask.Application.Handlers.Queries;
using TestTask.Domain.Entities;
using TestTask.Domain;

public class GetProductsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsFilteredProducts()
    {
        // Arrange
        var code = 123;
        var value = "test_value";
        var query = new GetProductsQuery(code, value);

        var expectedProducts = new List<Product>
        {
            new Product(code, value)
        };

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(r => r.GetAllAsync(It.IsAny<IEnumerable<Expression<Func<Product, bool>>>>()))
                      .ReturnsAsync(expectedProducts);

        var handler = new GetProductsQueryHandler(mockRepository.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.GetAllAsync(It.IsAny<IEnumerable<Expression<Func<Product, bool>>>>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(expectedProducts.First().Code, result.First().Code);
        Assert.Equal(expectedProducts.First().Value, result.First().Value);
    }

    [Fact]
    public async Task Handle_NoQuery_ReturnsAllProducts()
    {
        // Arrange
        var query = new GetProductsQuery(null, null);
        var expectedProducts = new List<Product>
        {
            new Product(1, "SomeValue"),
            new Product(2, "test_value")

        };

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(r => r.GetAllAsync(It.IsAny<IEnumerable<Expression<Func<Product, bool>>>>()))
                      .ReturnsAsync(expectedProducts);

        var handler = new GetProductsQueryHandler(mockRepository.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.GetAllAsync(It.IsAny<IEnumerable<Expression<Func<Product, bool>>>>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(expectedProducts.Count, result.Count());
    }
}
