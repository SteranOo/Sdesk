using System.Web.Http;
using System.Web.Http.Routing;
using SDesk.API.Constraints;

namespace SDesk.API.Configuration
{
    public class HttpRoutesConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("jiraid", typeof(JiraIdConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Routes.MapHttpRoute(
                name: "Jira",
                routeTemplate: "api/jiraitems/{id}",
                defaults: new { controller = "JiraItems", id = 1 }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
