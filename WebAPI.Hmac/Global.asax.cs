namespace WebAPI.Hmac
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Routing;

    using Castle.Windsor;
    using WebApi.Core.Dependency;

    using WebAPI.Hmac.Filters;

    /// <summary>
    /// The mvc application.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        private static readonly IWindsorContainer WindsorContainer = new WindsorContainer();

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            RegisterDependencies();
            RegisterGlobalFilters();

            RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
        }

        private static void RegisterDependencies()
        {
            WindsorContainer.Install(
                new CustomizedWebApiInstaller(GlobalConfiguration.Configuration, typeof(MvcApplication).Assembly),
                new ControllerInstaller());

            var windsorDependencyResolver = new WindsorDependencyResolver(WindsorContainer);
            GlobalConfiguration.Configuration.DependencyResolver = windsorDependencyResolver;
        }

        private void RegisterGlobalFilters()
        {
            var configuration = GlobalConfiguration.Configuration;
            configuration.Filters.Add(new UnhandleExceptionAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}