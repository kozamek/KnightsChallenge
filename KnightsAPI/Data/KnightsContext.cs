using KnightsAPI.Entities;
using MongoDB.Driver;

namespace KnightsAPI.Data
{
    public class KnightsContext : IKnightsContext
    {
        public IMongoCollection<Knight> Knights { get; }

        public KnightsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Knights = database.GetCollection<Knight>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            KnightsSeed.SeedData(Knights);
        }
    }
}
