using TestTask.Application.Utils;

public class ManualConverterTests
{
    [Fact]
    public void MapFromDictionaryToProductsList_ReturnsEmptyList_WhenDictionariesIsNull()
    {
        // Arrange
        IEnumerable<Dictionary<int, string>> dictionaries = null;

        // Act
        var result = ManualConverter.MapFromDictionaryToProductsList(dictionaries);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void MapFromDictionaryToProductsList_ReturnsEmptyList_WhenDictionariesIsEmpty()
    {
        // Arrange
        var dictionaries = new List<Dictionary<int, string>>();

        // Act
        var result = ManualConverter.MapFromDictionaryToProductsList(dictionaries);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void MapFromDictionaryToProductsList_ReturnsProductsList_WhenDictionariesContainData()
    {
        // Arrange
        var dictionaries = new List<Dictionary<int, string>>
        {
            new Dictionary<int, string> { { 1, "Product1" }},
            new Dictionary<int, string> { { 2, "Product2" }}
        };

        // Act
        var result = ManualConverter.MapFromDictionaryToProductsList(dictionaries);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dictionaries.Count, result.Count);
        Assert.Equal(1, result[0].Code);
        Assert.Equal("Product1", result[0].Value);
        Assert.Equal(2, result[1].Code);
        Assert.Equal("Product2", result[1].Value);
    }
}