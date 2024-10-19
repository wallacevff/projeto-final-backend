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

public abstract partial class DefaultRepository<TEntity, TFilter>(
    AppDbContext appDbContext
    ) : IDefaultRepository<TEntity, TFilter>
    where TEntity : DefaultEntity<Guid>
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
        return Task.FromResult(() => Context.ChangeTracker.Clear());
    }

    public Task Dispose()
    {
        return Task.FromResult(() => Context.DisposeAsync());
    }

    public virtual async Task<PagedResult<TEntity>> GetAll(TFilter filter)
    {
        var result = await
        DbSet
            .Where(GetFilters(filter))
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).ToListAsync()
            ;
        return await GeneratePagedResult(
            result,
            filter
        );
    }



    public async Task<TEntity?> GetAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(d => d.Id == id);
    }

    public Task UpdateAsync(TEntity entity)
    {
        return Task.FromResult(DbSet.Update(entity));
    }

    protected virtual async Task<PagedResult<TEntity>> GeneratePagedResult(IList<TEntity> entities, TFilter filter)
    {
        var pageSizeNonZero = filter.PageSize - 1 != 0 ? filter.PageSize - 1 : 1;
        var totalItens = await DbSet.CountAsync();
        return new PagedResult<TEntity>
        {
            PageInfo = new PageInfo
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalPages = totalItens >= filter.PageSize ? totalItens / pageSizeNonZero : 1
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
                PropertyInfo entityProperty = typeof(TEntity).GetProperty(filterProperty.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

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