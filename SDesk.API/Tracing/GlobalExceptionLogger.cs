using System.Reflection;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace SDesk.API.Tracing
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Log(ExceptionLoggerContext context)
        {
            Log4Net.Error($"Unhandled exception thrown in {context.Request.Method} for request {context.Request.RequestUri} : {context.Exception}");
        }
    }
}
