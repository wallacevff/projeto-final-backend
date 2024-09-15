using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.Repository;

public interface IDefaultRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> GetAsync(params object[] id);
    public Task UpdateAsync(TEntity entity, params object[] id);
    public Task<TEntity?> AddAsync(TEntity entity);
    public Task<PagedResult<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize);
}