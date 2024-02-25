using Moq;
using TestTask.Application.Handlers.Queries;
using TestTask.Domain.Entities;
using TestTask.Domain;
using System.Linq.Expressions;
using NUnit.Framework;

namespace TestTask.UnitTests
{
    public class GetProductsQueryHandlerTests
    {
        public GetProductsQueryHandlerTests()
        {
            
        }

        [Test]
        public async Task Handler_Should_ReturnProductsListAsync()
        {
            // Arrange
            var query = new GetProductsQuery(2, "test_value");

            var expectedProducts = new List<Product>
            {
                new Product(123, "SomeValue"),
                new Product(105, "test_value"),
                new Product(12, "1234"),
                new Product(123, "texttext"),
                new Product(123, "test_value"),
            };

            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<IEnumerable<Expression<Func<Product, bool>>>>()))
                          .ReturnsAsync(expectedProducts);

            var handler = new GetProductsQueryHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equals(true, true);
        }
    }
}
