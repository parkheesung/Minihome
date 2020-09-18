using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MiniHome.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = AutofacConfig.Create(typeof(MvcApplication).Assembly);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
