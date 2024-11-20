using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;

namespace ProjetoFinalBackend.Domain.Repository;

public interface IDefaultRepository<TEntity, TFilter, Tkey>
    where TEntity : class
    where TFilter : Filter, new()
{
    public Task<TEntity?> FindAsync(Tkey id);  // Alterado para aceitar uma chave do tipo TKey
    public Task<TEntity?> GetByIdAsync(Tkey id);
    public Task<PagedResult<TEntity>> GetAllAsync(TFilter filter);
    public Task<TEntity> AddAsync(TEntity entity);
    public Task AddRangeAync(IList<TEntity> entities);
    public Task UpdateAsync(TEntity entity);
    public Task<bool> HasAnyAsync(Func<TEntity, bool>? predicate = null);
    public Task<TEntity> DeleteAsync(TEntity entity);
    public Task SaveChangesAsync();
    public Task ChangeTracker();
    public Task Dispose();
}