using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace SDesk.API.Attributes
{
    public class NullResponseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null && actionExecutedContext.Request.Method == HttpMethod.Get)
            {
                object outValue;
                actionExecutedContext.Response.TryGetContentValue(out outValue);

                if (outValue == null)
                {
                    actionExecutedContext.Response.StatusCode = HttpStatusCode.NotFound;
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
