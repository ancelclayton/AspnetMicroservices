using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatelogContext : ICatelogContext
    {
        public CatelogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var db = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = db.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatelogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
