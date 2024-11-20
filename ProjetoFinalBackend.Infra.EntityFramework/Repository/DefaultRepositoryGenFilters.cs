using LinqKit;
using ProjetoFinalBackend.Domain.Shared.Filters;
using System.Linq.Expressions;
using System.Reflection;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public abstract partial class DefaultRepository<TEntity, TFilter, Tkey>
 : IDefaultRepository<TEntity, TFilter, Tkey>
    where TEntity : class
    where TFilter : Filter, new()
{
    protected virtual Expression<Func<TEntity, bool>> GetFilters(TFilter filter)
    {
        var predicate = PredicateBuilder.New<TEntity>(true);
        var excludedProperties = new List<string> { "TotalPages", "PageSize", "PageNumber" };

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