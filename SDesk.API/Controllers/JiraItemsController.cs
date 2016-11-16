using System.Web.Http;
using SDesk.DAL;

namespace SDesk.API.Controllers
{
    public class JiraItemsController : ApiController
    {
        /// <summary>
        /// Get JiraItem by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>JiraItem</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.JiraItems.Find(x => x.JiraItemId == id));
        }

        /// <summary>
        /// Get JiraItem by Jira-id
        /// </summary>
        /// <param name="jira_Id">Jira-id (ex. Jira-1)</param>
        /// <returns>JiraItem</returns>
        [Route("api/jiraitems/{jira_id:jiraid}")]
        public IHttpActionResult Get(string jira_Id)
        {
            if(jira_Id == null)
                return BadRequest("Id is null");

            var jiraId = int.Parse(jira_Id.Split('-')[1]);
            return Ok(DbFake.JiraItems.Find(x => x.JiraItemId == jiraId));
        }
    }
}
