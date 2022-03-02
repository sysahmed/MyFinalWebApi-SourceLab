using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Demo.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
