using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Demo.Core.CrossCuttingConcerns.Caching;
using MyApp.Demo.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyApp.Demo.Core.Utilities.IoC;
using System.Diagnostics;

namespace MyApp.Demo.Business.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
