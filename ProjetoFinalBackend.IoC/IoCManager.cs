using Microsoft.Extensions.DependencyInjection;

namespace ProjetoFinalBackend.Infra.IoC;

public static class IoCManager
{
    #region "Public Methods"




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
