using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SDesk.API.Tracing
{
    public class GlobalException : IHttpActionResult
    {
        public HttpRequestMessage Request { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(Message),
                RequestMessage = Request
            };

            return Task.FromResult(response);
        }
    }
}
