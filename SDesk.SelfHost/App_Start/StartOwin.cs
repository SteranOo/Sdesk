using System.Web.Http;
using Owin;
using SDesk.API.Configuration;

namespace SDesk.SelfHost
{
    public class StartOwin
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            
            WebApiConfig.Register(config);

            appBuilder.UseWebApi(config);
        }
    }
}
