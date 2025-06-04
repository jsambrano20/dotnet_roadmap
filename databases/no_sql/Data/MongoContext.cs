using Microsoft.Extensions.Options;
using MongoDB.Driver;
using no_sql.Data.Configuration;
using no_sql.Model;

namespace no_sql.Data
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);

            CriarIndices();
        }

        public IMongoCollection<Pessoa> Pessoas => _database.GetCollection<Pessoa>("Pessoas");

        private void CriarIndices()
        {
            var indexOptions = new CreateIndexOptions { Unique = true };
            var indexKeys = Builders<Pessoa>.IndexKeys.Ascending(p => p.Email);
            var indexModel = new CreateIndexModel<Pessoa>(indexKeys, indexOptions);

            Pessoas.Indexes.CreateOne(indexModel);
        }
    }
}
