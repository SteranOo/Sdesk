using System.Net;
using System.Web.Http.ExceptionHandling;

namespace SDesk.API.Tracing
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new GlobalException
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = $"Internal exception has occured: {context.Exception.Message}",
                Request = context.Request
            };
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}
