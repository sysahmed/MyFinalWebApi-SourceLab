using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Demo.Core.CrossCuttingConcerns.Caching;
using MyApp.Demo.Core.Utilities.Interceptors;
using MyApp.Demo.Core.Utilities.IoC;

namespace MyApp.Demo.Core.Aspect.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager? _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
