using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> brandsCollection)
    {
        var checkBrands = brandsCollection.Find(brand => true).Any();
        var path = Path.Combine("Data", "Seed", "brands.json");
        if (!checkBrands)
        {
            var brandsData = File.ReadAllText(path);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if (brands != null)
            {
                foreach(var brand in brands)
                {
                    brandsCollection.InsertOneAsync(brand);
                }
            }
        }
    }
}