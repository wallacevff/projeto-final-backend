using LinqKit;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;
using System.Linq.Expressions;
using System.Reflection;
using ProjetoFinalBackend.Domain.Repository;
namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public abstract partial class DefaultRepository<TEntity, TFilter, Tkey>(
    AppDbContext appDbContext
    ) : IDefaultRepository<TEntity, TFilter, Tkey>
    where TEntity : class
    where TFilter : Filter, new()
{

    protected readonly AppDbContext Context = appDbContext;
    protected readonly DbSet<TEntity> DbSet = appDbContext.Set<TEntity>();


    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        return (await DbSet.AddAsync(entity)).Entity;
    }

    public virtual async Task AddRangeAync(IList<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public Task<bool> HasAnyAsync()
    {
        return DbSet.AnyAsync();
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        return await Task.FromResult(DbSet.Remove(entity).Entity);
    }

    public virtual async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    public Task ChangeTracker()
    {
        Context.ChangeTracker.Clear();
        return Task.CompletedTask;
    }

    public Task Dispose()
    {
        return Context.DisposeAsync().AsTask();
    }


    public async Task<TEntity?> GetAsync(Tkey id)
    {
        return await DbSet.FindAsync(id);
    }

    protected virtual IEnumerable<Expression<Func<TEntity, object>>> GetIncludes()
    {
        return Enumerable.Empty<Expression<Func<TEntity, object>>>();
    }

    protected virtual IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query)
    {

        return query;
    }

    protected virtual IQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query)
    {

        return query;
    }


    public virtual async Task<PagedResult<TEntity>> GetAllAsync(TFilter filter)
    {
        var query = DbSet.AsQueryable();
        query = ApplyIncludes(query);
        query = ApplyOrderBy(query);
        query = query.Where(GetFilters(filter));
        var result = await query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).ToListAsync()
            ;
        return await GeneratePagedResult(
            result,
            filter
        );
    }

    public Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        return Task.CompletedTask;
    }

    protected virtual async Task<PagedResult<TEntity>> GeneratePagedResult(IList<TEntity> entities, TFilter filter)
    {
        var totalItens = await DbSet.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItens / (double)(filter.PageSize > 0 ? filter.PageSize : 1));

        return new PagedResult<TEntity>
        {
            PageInfo = new PageInfo
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalPages = totalPages
            },
            Dados = entities
        };
    }


    




}