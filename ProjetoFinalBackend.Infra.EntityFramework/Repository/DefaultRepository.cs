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

    public virtual async Task<PagedResult<TEntity>> GetAllAsync(TFilter filter)
    {
        var query = DbSet.AsQueryable();
        query = ApplyIncludes(query);
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


    protected virtual Expression<Func<TEntity, bool>> GetFilters(TFilter filter)
    {
        var predicate = PredicateBuilder.New<TEntity>(true); // Inicia com "true" para permitir o uso de And

        // Lista de propriedades que não devem ser aplicadas como filtros
        var excludedProperties = new List<string> { "TotalPages", "PageSize", "PageNumber" };

        // Obtém as propriedades do filtro
        IList<PropertyInfo> filterProperties = typeof(TFilter).GetProperties();

        // Itera sobre as propriedades do filtro
        foreach (PropertyInfo filterProperty in filterProperties)
        {
            var filterValue = filterProperty.GetValue(filter);

            // Ignora as propriedades que estão na lista de exclusão
            if (excludedProperties.Contains(filterProperty.Name))
                continue; // Pula esta iteração se a propriedade está na lista de exclusão

            // Verifica se o valor do filtro não é nulo e que a entidade contém essa propriedade
            if (filterValue != null)
            {
                // Verifica se a entidade TEntity tem a mesma propriedade
                PropertyInfo? entityProperty = typeof(TEntity).GetProperty(filterProperty.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (entityProperty != null)
                {
                    // Cria a expressão para comparar a propriedade do TEntity com o valor do filtro
                    var parameter = Expression.Parameter(typeof(TEntity), "p");
                    var property = Expression.Property(parameter, entityProperty.Name); // Propriedade de TEntity
                    var constant = Expression.Constant(filterValue); // Valor do filtro

                    // Verifica se a propriedade é do tipo string para aplicar Contains
                    if (entityProperty.PropertyType == typeof(string))
                    {
                        // String: Usando Contains para fazer a comparação
                        var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        if (method != null)
                        {
                            var body = Expression.Call(property, method, constant);
                            predicate = predicate.And(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
                        }
                    }
                    // Se for Nullable, precisa tratar a comparação
                    else if (entityProperty.PropertyType.IsGenericType &&
                        entityProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        var hasValue = Expression.Property(property, "HasValue");
                        var value = Expression.Property(property, "Value");
                        var body = Expression.AndAlso(
                            hasValue, Expression.Equal(value, constant)
                        );
                        predicate = predicate.And(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
                    }
                    // Se for do tipo DateTime ou DateTime?, aplicar intervalos (From e To)
                    else if (entityProperty.PropertyType == typeof(DateTime) || entityProperty.PropertyType == typeof(DateTime?))
                    {
                        if (filterProperty.Name.EndsWith("From"))
                        {
                            var body = Expression.GreaterThanOrEqual(property, constant);
                            predicate = predicate.And(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
                        }
                        else if (filterProperty.Name.EndsWith("To"))
                        {
                            var body = Expression.LessThanOrEqual(property, constant);
                            predicate = predicate.And(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
                        }
                    }
                    else
                    {
                        // Caso comum: compara diretamente com ==
                        var body = Expression.Equal(property, constant);
                        predicate = predicate.And(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
                    }
                }
            }
        }

        return predicate;
    }




}