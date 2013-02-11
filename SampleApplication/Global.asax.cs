using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVCUnityExtensions;
using SampleApplication.Controllers;

namespace SampleApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DependencyInitializer.CurrentContainer.RegisterType<IHomeController, HomeController>();
            DependencyInitializer.CurrentContainer.RegisterType<IFoo, Foo>();
        }
    }

    public interface IFoo
    {
        int GetFoo(int x);
    }

    class Foo : IFoo
    {
        public int GetFoo(int x)
        {
            return x * 2;
        }
    }
}