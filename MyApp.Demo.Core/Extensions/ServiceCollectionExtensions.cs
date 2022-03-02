using Microsoft.Extensions.DependencyInjection;
using MyApp.Demo.Core.Utilities.IoC;

namespace MyApp.Demo.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
