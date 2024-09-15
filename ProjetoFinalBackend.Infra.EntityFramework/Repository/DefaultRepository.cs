using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class DefaultRepository<TEntity> : IDefaultRepository<TEntity> where TEntity: class, new()
{
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly AppDbContext _appDbContext;

    public DefaultRepository(AppDbContext context)
    {
        _dbSet = context.Set<TEntity>();
        _appDbContext = context;
    }


    public async Task<TEntity?> GetAsync(params object[] id)
    {
        return  await _dbSet.FindAsync(id);
    }

    public virtual Task UpdateAsync(TEntity entity, params object[] id)
    {
        return Task.FromResult(_dbSet.Update(entity));
    }

    public virtual async Task<TEntity?> AddAsync(TEntity entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }

    public virtual async Task<PagedResult<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        var pagedResult = new PagedResult<TEntity>()
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            DataEntity = await _dbSet.ToListAsync()
        };
        return pagedResult;
    }
}