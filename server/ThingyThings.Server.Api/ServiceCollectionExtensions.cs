using System.Reflection;

namespace ThingyThings.Server.Api;

public static class ServiceCollectionExtensions
{
    public static void AddScoped(this IServiceCollection services, Type serviceType, Assembly assembly)
    {
        var types = assembly.GetExportedTypes();
        if (serviceType.IsGenericType)
        {
            foreach (var type in types)
            {
                var interfaceTypes = type
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == serviceType);

                foreach(var interfaceType in interfaceTypes)
                {
                    services.AddScoped(interfaceType, type);
                }
            }
        }
    }
}