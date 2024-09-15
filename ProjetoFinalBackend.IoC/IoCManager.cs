using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinalBackend.Infra.EntityFramework;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;
using ProjetoFinalBackend.Infra.EntityFramework.Repository;

namespace ProjetoFinalBackend.Infra.IoC;

public static class IoCManager
{
    #region "Public Methods"

    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=db.db", b => b.MigrationsAssembly("ProjetoFinalBackend.Api"))
        );
        return services;
    }

    public static IServiceCollection AddAllRepositories(this IServiceCollection services)
    {
        services.AddScoped<UsuarioRepository>();

        return services;
    }

    #endregion


    #region "Private Methods"
    private static IServiceCollection AddAllServicesByTypes(this IServiceCollection services, Type typeInterface, Type implementationType)
    {
        IEnumerable<Type> projectInterfaces = GetDescendentInterfaces(typeInterface);
        return AddServiceOfAllTypesAndDescendentTypes
            (services, projectInterfaces, implementationType);
        
    }

    private static IServiceCollection AddServiceOfAllTypesAndDescendentTypes(IServiceCollection services, IEnumerable<Type> interfaceTypes, Type implementationType)
    {
        foreach (var implementedTye in interfaceTypes)
        {
            var implementedTypes = GetImplementedTypesFromInterface(implementedTye, implementationType);
            AddServiceScoped(services, implementedTye, implementedTypes);
        }
        return services;
    }

    private static  IEnumerable<Type> GetDescendentInterfaces(Type typeInterface)
    {
        return typeInterface.Assembly
            .GetTypes()
            .Where(i => i.IsInterface && i != typeInterface);
    }

    private static IEnumerable<Type> GetImplementedTypesFromInterface
        (Type projectInterface, Type implementationType)
    {
        return implementationType.Assembly.GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract && t.IsAssignableTo(projectInterface));
    }

    private static IServiceCollection AddServiceScoped(
        IServiceCollection services,
        Type interfaceType,
        IEnumerable<Type> implementedTypes)
    {
        foreach (Type implementedType in implementedTypes)
        {
            services.AddScoped(interfaceType, implementedType);
        }
        return services;
    }

    #endregion
}
