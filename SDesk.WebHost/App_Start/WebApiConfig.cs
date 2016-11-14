using System.Web.Http;
using SDesk.API.Configuration;

namespace SDesk.WebHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            HttpRoutesConfig.RegisterRoutes(config);
        }
    }
}
