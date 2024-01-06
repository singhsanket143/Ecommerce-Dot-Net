using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> typesCollection)
    {
        var checkTypes = typesCollection.Find(type => true).Any();
        var path = Path.Combine("Data", "Seed", "types.json");
        if (!checkTypes)
        {
            var typesData = File.ReadAllText(path);
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if (types != null)
            {
                foreach(var type in types)
                {
                    typesCollection.InsertOneAsync(type);
                }
            }
        }
    }
}