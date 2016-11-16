using System;
using System.Web.Http;
using Owin;
using SDesk.API.Configuration;
using Swashbuckle.Application;

namespace SDesk.SelfHost
{
    public class StartOwin
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            
            WebApiConfig.Register(config);

            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SDesk.SelfHost");

                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    var xmlPath = path.Replace("WebHost", "API");
                    c.IncludeXmlComments($@"{xmlPath}\SDesk.API.XML");
                }).EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }
    }
}
