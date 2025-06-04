using MongoDB.Driver;
using no_sql.Model;

namespace no_sql.Data
{
    public interface IMongoContext
    {
        IMongoCollection<Pessoa> Pessoas { get; }
    }
}
