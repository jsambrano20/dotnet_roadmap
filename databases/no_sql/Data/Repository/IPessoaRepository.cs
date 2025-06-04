using no_sql.Model;

namespace no_sql.Data.Repository
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAll();
        Task<Pessoa> GetOne(Guid id);
        Task Create(Pessoa pessoa);
        Task<bool> Update(Pessoa pessoa);
        Task<Guid> GetNextId();
    }
}
