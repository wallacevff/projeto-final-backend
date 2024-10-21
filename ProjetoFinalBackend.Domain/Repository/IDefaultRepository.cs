using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;

namespace ProjetoFinalBackend.Domain.Repository;

public interface IDefaultRepository<TEntity, TFilter, TKey>
    where TEntity : class
    where TFilter : Filter, new()
{
    public Task<TEntity?> GetAsync(TKey id);  // Alterado para aceitar uma chave do tipo TKey
    public Task<PagedResult<TEntity>> GetAll(TFilter filter);
    public Task<TEntity> AddAsync(TEntity entity);
    public Task AddRangeAync(IList<TEntity> entities);
    public Task UpdateAsync(TEntity entity);
    public Task<TEntity> DeleteAsync(TEntity entity);
    public Task SaveChangesAsync();
    public Task ChangeTracker();
    public Task Dispose();
}