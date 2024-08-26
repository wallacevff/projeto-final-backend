using Microsoft.Extensions.DependencyInjection;

namespace ProjetoFinalBackend.IoC;

public static class IoCManager
{
    #region "Public Methods"

       
    

    #endregion


    #region "Private Methods"
    private static IServiceCollection AddAllServicesByTypes(this IServiceCollection services, Type typeInterface, Type implementationType)
    {
        IEnumerable<Type> repositoryInterfaces = typeInterface.Assembly
            .GetTypes()
            .Where(i => i.IsInterface && i != typeInterface);

        IEnumerable<Type> implementedTypes;

        foreach (Type type in repositoryInterfaces)
        {
            implementedTypes = implementationType.Assembly.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract && t.IsAssignableTo(type));
            foreach (Type implementedType in implementedTypes)
            {
                services.AddTransient(type, implementedType);
            }
        }
        return services;
    }
    #endregion
}
