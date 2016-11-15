using System.Web;
using System.Web.Http;
using SDesk.API.Configuration;

namespace SDesk.WebHost
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
