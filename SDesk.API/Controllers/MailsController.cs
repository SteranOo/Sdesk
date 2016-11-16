using System.Web.Http;
using AutoMapper;
using SDesk.API.Attributes;
using SDesk.DAL;
using SDesk.Model;

namespace SDesk.API.Controllers
{
    /// <summary>
    /// v1 Mails Controller
    /// </summary>
    [RoutePrefix("api/mails")]
    public class MailsController : ApiController
    {
        /// <summary>
        /// Get All Mails
        /// </summary>
        /// <returns>List of Mails</returns>
        [VersionedRoute("", 1)]
        public IHttpActionResult Get()
        {
            return Ok(DbFake.Mails);
        }

        /// <summary>
        /// Get Mail by id
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <returns>Mail</returns>
        [VersionedRoute("{id}", 1)]
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Mails.Find(x=>x.Id == id));
        }

        /// <summary>
        /// Add new Mail
        /// </summary>
        /// <param name="mail">Mail</param>
        /// <returns></returns>
        [VersionedRoute("", 1)]
        public IHttpActionResult Post([FromBody]Mail mail)
        {
            if (mail == null)
                return BadRequest("Mail is null");

            DbFake.Mails.Add(mail);
            return Ok();
        }

        /// <summary>
        /// Update Mail by Id
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <param name="mail">Mail</param>
        /// <returns></returns>
        [VersionedRoute("{id}", 1)]
        public IHttpActionResult Put(int id, [FromBody]Mail mail)
        {
            if (mail == null)
                return BadRequest("Mail is null");

            var entity = DbFake.Mails.Find(x => x.Id == id);
            _mapper.Map(mail, entity);
            return Ok();
        }

        /// <summary>
        /// Delete Mail by Id
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <returns></returns>
        [VersionedRoute("{id}", 1)]
        public IHttpActionResult Delete(int id)
        {
            DbFake.Mails.Remove(DbFake.Mails.Find(x => x.Id == id));
            return Ok();
        }

        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Mail, Mail>()));
    }
}
