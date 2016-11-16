using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using SDesk.API.Attributes;
using SDesk.DAL;
using SDesk.Model;
using static System.String;

namespace SDesk.API.Controllers
{
    /// <summary>
    /// v1 Attachements Controller
    /// </summary>
    [RoutePrefix("api/mails/{id}/attachements")]
    public class AttachementsController : ApiController
    {
        /// <summary>
        /// Get all mails attachments
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <returns>List of Attachments</returns>
        [VersionedRoute("", 1)]
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Attachements.Where(x => x.MailId == id));
        }

        /// <summary>
        /// Get mail attachments by attachent id or if its value is 0, by extention and/or status 
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <param name="attId">Attachent Id</param>
        /// <param name="extention">Extention</param>
        /// <param name="status">Status</param>
        /// <returns>List of Attachments</returns>
        [VersionedRoute("{attId}", 1)]
        public IHttpActionResult Get(int id, int attId, string extention = null, int? status = null)
        {
            var result = new List<Attachement>();
            if (attId == 0)
            {
                if (!IsNullOrEmpty(extention))
                    result.AddRange(DbFake.Attachements.Where(x => x.MailId == id && x.FileExtention.Equals(extention)));

                if (status != null)
                    result.AddRange(DbFake.Attachements.Where(x => x.MailId == id && x.StatusId == status && !result.Contains(x)));
            }
            else
                result.AddRange(DbFake.Attachements.Where(x => x.MailId == id && x.Id == attId));

            return Ok(result);
        }

        /// <summary>
        /// Add new attachment to mail by id
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <param name="attachement">Attachement</param>
        /// <returns></returns>
        [VersionedRoute("", 1)]
        public IHttpActionResult Post(int id, [FromBody]Attachement attachement)
        {
            if (attachement == null)
                return BadRequest("Attachement is null");

            DbFake.Attachements.Add(attachement);
            return Ok();
        }

        /// <summary>
        /// Update attachment by id
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <param name="attId">Attachment Id</param>
        /// <param name="attachement">Attachment</param>
        /// <returns></returns>
        [VersionedRoute("{attId}", 1)]
        public IHttpActionResult Put(int id, int attId, [FromBody]Attachement attachement)
        {
            if (attachement == null)
                return BadRequest("Attachement is null");

            var entity = DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId);
            _mapper.Map(attachement, entity);
            return Ok();
        }

        /// <summary>
        /// Delete attachment by id
        /// </summary>
        /// <param name="id">Mail Id</param>
        /// <param name="attId">Attachment Id</param>
        /// <returns></returns>
        [VersionedRoute("{attId}", 1)]
        public IHttpActionResult Delete(int id, int attId)
        {
            DbFake.Attachements.Remove(DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId));
            return Ok();
        }

        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Attachement, Attachement>()));
    }
}
