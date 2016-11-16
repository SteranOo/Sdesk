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
    [RoutePrefix("api/mails/{id}/attachements")]
    public class AttachementsController : ApiController
    {
        [VersionedRoute("", 1)]
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Attachements.Where(x => x.MailId == id));
        }

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

        [VersionedRoute("", 1)]
        public IHttpActionResult Post(int id, [FromBody]Attachement attachement)
        {
            if (attachement == null)
                return BadRequest("Attachement is null");

            DbFake.Attachements.Add(attachement);
            return Ok();
        }

        [VersionedRoute("{attId}", 1)]
        public IHttpActionResult Put(int id, int attId, [FromBody]Attachement attachement)
        {
            if (attachement == null)
                return BadRequest("Attachement is null");

            var entity = DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId);
            _mapper.Map(attachement, entity);
            return Ok();
        }

        [VersionedRoute("{attId}", 1)]
        public IHttpActionResult Delete(int id, int attId)
        {
            DbFake.Attachements.Remove(DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId));
            return Ok();
        }

        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Attachement, Attachement>()));
    }
}
