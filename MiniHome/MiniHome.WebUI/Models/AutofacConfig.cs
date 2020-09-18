using Autofac;
using Autofac.Integration.Mvc;
using MiniHome.Domain;
using System.Reflection;

namespace MiniHome.WebUI
{
    public class AutofacConfig
    {
        public static IContainer Create(Assembly assembly)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(assembly);
            builder.RegisterType<MiniHomeRepository>().As<IMiniHomeRepository>();
            builder.RegisterType<WebSite>().As<IWebSite>();
            return builder.Build();
        }
    }
}