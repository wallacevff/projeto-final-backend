using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinalBackend.Application.Services;
using ProjetoFinalBackend.Infra.CrossCutting.Configurations;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;
using ProjetoFinalBackend.Infra.EntityFramework.Repository;

namespace ProjetoFinalBackend.Infra.IoC;

public static class IoCManager
{
    #region "Public Methods"

    public static IServiceCollection ConfigureByIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddAutoMap();
        return services;
    }


    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configutation)
    {
        DbContextConfiguration dbContextConfiguration = new DbContextConfiguration();
        configutation.GetSection(DbContextConfiguration.ConnectionStrings).Bind(dbContextConfiguration);
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(dbContextConfiguration.DefaultConnection)
        );
        return services;
    }

    public static IServiceCollection AddAllRepositories(this IServiceCollection services)
    {
        services.AddScoped<UsuarioRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMap(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IApplicationServices));
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
