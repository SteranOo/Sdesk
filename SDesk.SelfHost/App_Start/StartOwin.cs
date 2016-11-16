using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Owin;
using SDesk.API.Configuration;
using SDesk.API.Constraints;
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

                    c.MultipleApiVersions(ResolveVersionSupportByRouteConstraint,
                           vc =>
                           {
                               vc.Version("v2", "SDesk API V2");
                               vc.Version("v1", "SDesk API V1");
                           });

                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    var xmlPath = path.Replace("WebHost", "API");
                    c.IncludeXmlComments($@"{xmlPath}\SDesk.API.XML");

                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                }).EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }

        private bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            object version;

            var allowedVersion = 0;
            apiDesc.Route.Constraints.TryGetValue("version", out version);

            if (version != null)
                allowedVersion = ((VersionConstraint)version).AllowedVersion;
            else if (targetApiVersion.Equals("v1"))
                return true;

            bool res = targetApiVersion.Equals($"v{allowedVersion}");
            return res;
        }
    }
}
