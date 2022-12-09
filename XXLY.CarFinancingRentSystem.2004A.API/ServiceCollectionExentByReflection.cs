using System.Reflection;

namespace XXLY.CarFinancingRentSystem._2004A.API
{
    public static class ServiceCollectionExentByReflection
    {
        static void AddScoped(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementAssembly)
        {
            var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);
            var implements = implementAssembly.GetTypes();
            foreach (var item in interfaces)
            {
                var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
                if (type != null)
                {
                    services.AddScoped(item, type);
                }
            }
        }

        public static void AddSingleton(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementAssembly)
        {
            var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);
            var implements = implementAssembly.GetTypes();
            foreach (var item in interfaces)
            {
                var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
                if (type != null)
                {
                    services.AddSingleton(item, type);
                }
            }
        }

        public static void AddTransient(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementAssembly)
        {
            var interfaces = interfaceAssembly.GetTypes().Where(t => t.IsInterface);
            var implements = implementAssembly.GetTypes();
            foreach (var item in interfaces)
            {
                var type = implements.FirstOrDefault(x => item.IsAssignableFrom(x));
                if (type != null)
                {
                    services.AddTransient(item, type);
                }
            }
        }
    }
}
