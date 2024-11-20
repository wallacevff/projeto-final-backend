using System.Collections.Immutable;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;
using System.Linq.Expressions;
using System.Reflection;
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

    public virtual Task<bool> HasAnyAsync(Func<TEntity, bool>? predicate = null)
    {
        if(predicate is null)
            return DbSet.AnyAsync();
        return Task.FromResult(DbSet.Any(predicate));
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        return await Task.FromResult(DbSet.Remove(entity).Entity);
    }

    public virtual async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    public virtual Task ChangeTracker()
    {
        Context.ChangeTracker.Clear();
        return Task.CompletedTask;
    }

    public Task Dispose()
    {
        return Context.DisposeAsync().AsTask();
    }


    public virtual async Task<TEntity?> FindAsync(Tkey id)
    {
        IList<PropertyInfo> properties = id!.GetType().GetProperties();
        IList<object> propsObj = new List<object>();
        properties.ForEach(p =>
        {
            propsObj.Add(p.GetValue(id)!);
        });
        var arrayOfKeys = propsObj.ToArray();
        return await DbSet.FindAsync(arrayOfKeys);
    }

    public virtual Task<TEntity?> GetByIdAsync(Tkey id)
    {
        var query = ApplyIncludes(DbSet);
        IList<PropertyInfo> properties = id!.GetType().GetProperties();
        var predicate = GetPredicateUsingKey(properties, id);

        return query
            .FirstOrDefaultAsync(predicate);
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


    private Expression<Func<TEntity, bool>> GetPredicateUsingKey(IList<PropertyInfo> properties, Tkey id)
    {
        var predicate = PredicateBuilder.New<TEntity>(true);
        foreach (var property in properties)
        {
            var param = Expression.Parameter(typeof(TEntity), "p");
            var entityProperty = Expression.Property(param, property.Name);
            var constantValue = Expression.Constant(property.GetValue(id));
            var body = Expression.Equal(entityProperty, constantValue);
            predicate.And(Expression.Lambda<Func<TEntity, bool>>(body, param));
        }

        return predicate;
    }




}