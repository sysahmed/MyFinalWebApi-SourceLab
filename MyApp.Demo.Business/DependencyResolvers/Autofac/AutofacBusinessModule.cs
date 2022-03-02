using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Business.Concrete;
using MyApp.Demo.Core.Utilities.Interceptors;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.DataAccess.Concrete.EntityFramework;

namespace MyApp.Demo.Business.DependencyResolvers.Autofac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrdersManager>().As<IOrdersService>();
            builder.RegisterType<EfOrdersDal>().As<IOrdersDal>();

            builder.RegisterType<OrderLinesManager>().As<IOrderLinesService>();
            builder.RegisterType<EfOrderLinesDal>().As<IOrderLinesDal>();

            builder.RegisterType<ItemsManager>().As<IItemsService>();
            builder.RegisterType<EfItemsDal>().As<IItemsDal>();

            builder.RegisterType<ClientsManager>().As<IClientsService>();
            builder.RegisterType<EfClientsDal>().As<IClientsDal>();

            builder.RegisterType<AzureDal>().As<IAzureDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
