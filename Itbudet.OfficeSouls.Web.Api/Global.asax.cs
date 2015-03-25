using System.Web.Http;
using System.Web.Routing;

namespace Itbudet.OfficeSouls.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
