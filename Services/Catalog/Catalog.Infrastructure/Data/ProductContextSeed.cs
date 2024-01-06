using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class ProductContextSeed
{
    public static void SeedData(IMongoCollection<Product> productsCollection)
    {
        var checkProducts = productsCollection.Find(product => true).Any();
        var path = Path.Combine("Data", "Seed", "products.json");
        if (!checkProducts)
        {
            var productsData = File.ReadAllText(path);
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products != null)
            {
                foreach(var product in products)
                {
                    productsCollection.InsertOneAsync(product);
                }
            }
        }
    }
}