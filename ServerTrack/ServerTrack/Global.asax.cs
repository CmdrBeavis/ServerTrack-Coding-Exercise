
namespace ServerTrack
{
	using System.Web.Http;
	using System.Web.Mvc;
	using System.Web.Optimization;
	using System.Web.Routing;

	using Data;
	using Services;

	using SimpleInjector;
	using SimpleInjector.Integration.WebApi;


	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			// DI container spin up. (Simple Injector)
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

			container.Register<ServerTrack_InMemDb, ServerTrack_InMemDb>(Lifestyle.Scoped);

			container.Verify();

			// the rest of this is 'normal' Web API registration stuff.
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
