using TestTask.Domain.Entities;

namespace TestTask.Application.Utils
{
    public static class ManualConverter
    {
        public static List<Product> MapFromDictionaryToProductsList(IEnumerable<Dictionary<int, string>> dictionaries)
        {
            var products = new List<Product>();
            if (dictionaries == null) return products;

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
