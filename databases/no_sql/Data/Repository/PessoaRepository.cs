using MongoDB.Driver;
using no_sql.Model;

namespace no_sql.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMongoContext _context;
        public PessoaRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _context
                            .Pessoas
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Pessoa> GetOne(Guid id)
        {
            var filter = FindById(id);
            return _context
                    .Pessoas
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Pessoa pessoa)
        {
            await _context.Pessoas.InsertOneAsync(pessoa);
        }
        
        public async Task<bool> Update(Pessoa pessoa)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Pessoas
                        .ReplaceOneAsync(
                            filter: g => g.Id == pessoa.Id,
                            replacement: pessoa);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        private FilterDefinition<Pessoa> FindById(Guid id)
        {
            return Builders<Pessoa>.Filter.Eq(m => m.Id, id);
        }

        public async Task<Guid> GetNextId()
        {
            return Guid.NewGuid();
        }
    }
}
