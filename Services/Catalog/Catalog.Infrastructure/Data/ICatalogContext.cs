using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface ICatalogContext
{
    IMongoCollection<ProductBrand> Brands { get; }
    IMongoCollection<Product> Products { get; }
    IMongoCollection<ProductType> Types { get; }
}