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
    [VersionedRoute("api/mails", 1)]
    [RoutePrefix("api/mails/{id}/attachements")]
    public class AttachementsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Attachements.Where(x => x.MailId == id));
        }

        [Route("{attId}")]
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

        [Route("")]
        public IHttpActionResult Post(int id, [FromBody]Attachement attachement)
        {
            DbFake.Attachements.Add(attachement);
            return Ok();
        }

        [Route("{attId}")]
        public IHttpActionResult Put(int id, int attId, [FromBody]Attachement attachement)
        {
            var entity = DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId);
            _mapper.Map(attachement, entity);
            return Ok();
        }

        [Route("{attId}")]
        public IHttpActionResult Delete(int id, int attId)
        {
            DbFake.Attachements.Remove(DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId));
            return Ok();
        }

        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Attachement, Attachement>()));
    }
}
