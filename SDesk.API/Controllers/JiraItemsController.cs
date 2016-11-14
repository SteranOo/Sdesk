using System.Web.Http;
using SDesk.DAL;

namespace SDesk.API.Controllers
{
    public class JiraItemsController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.JiraItems.Find(x => x.JiraItemId == id));
        }
       
        [Route("api/jiraitems/{id:jiraid}")]
        public IHttpActionResult Get(string id)
        {
            var jiraId = int.Parse(id.Split('-')[1]);
            return Ok(DbFake.JiraItems.Find(x => x.JiraItemId == jiraId));
        }
    }
}
