using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            try
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
            catch (Exception e)
            {
                _logger.Fatal("Application failed to initialize one of config classes", e);
                throw;
            }
        }
    }
}
