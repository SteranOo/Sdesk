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
    [RoutePrefix("api")]
    public class Mails2Controller : ApiController
    {
        [Route("v2/mails")]
        [VersionedRoute("mails", 2)]
        public IHttpActionResult Get()
        {
            return Ok(DbFake.Mails);
        }

        [Route("v2/mails/{id}")]
        [VersionedRoute("mails/{id}", 2)]
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Mails.Find(x => x.Id == id));
        }

        [Route("v2/mails")]
        [VersionedRoute("mails", 2)]
        public IHttpActionResult Post([FromBody]Mail mail)
        {
            DbFake.Mails.Add(mail);
            return Ok();
        }

        [Route("v2/mails/{id}")]
        [VersionedRoute("mails/{id}", 2)]
        public IHttpActionResult Put(int id, [FromBody]Mail mail)
        {
            var entity = DbFake.Mails.Find(x => x.Id == id);
            _mapper.Map(mail, entity);
            return Ok();
        }

        [Route("v2/mails/{id}")]
        [VersionedRoute("mails/{id}", 2)]
        public IHttpActionResult Delete(int id)
        {
            DbFake.Mails.Remove(DbFake.Mails.Find(x => x.Id == id));
            return Ok();
        }

        [Route("v2/mails/{id}/attachements")]
        [VersionedRoute("mails/{id}/attachements", 2)]
        public IHttpActionResult GetAttachement(int id)
        {
            return Ok(DbFake.Attachements.Where(x => x.MailId == id));
        }

        [Route("v2/mails/{id}/attachements/{attId}")]
        [VersionedRoute("mails/{id}/attachements/{attId}", 2)]
        public IHttpActionResult GetAttachement(int id, int attId, string extention = null, int? status = null)
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

        [Route("v2/mails/{id}/attachements")]
        [VersionedRoute("mails/{id}/attachements", 2)]
        public IHttpActionResult PostAttachement(int id, [FromBody]Attachement attachement)
        {
            DbFake.Attachements.Add(attachement);
            return Ok();
        }

        [Route("v2/mails/{id}attachements/{attId}")]
        [VersionedRoute("mails/{id}/attachements/{attId}", 2)]
        public IHttpActionResult PutAttachement(int id, int attId, [FromBody]Attachement attachement)
        {
            var entity = DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId);
            _mapper.Map(attachement, entity);
            return Ok();
        }

        [Route("v2/mails/{id}attachements/{attId}")]
        [VersionedRoute("mails/{id}/attachements/{attId}", 2)]
        public IHttpActionResult DeleteAttachement(int id, int attId)
        {
            DbFake.Attachements.Remove(DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId));
            return Ok();
        }

        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Mail, Mail>();
            cfg.CreateMap<Attachement, Attachement>();
        }));
    }
}
