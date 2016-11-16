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
    [RoutePrefix("api/mails")]
    public class Mails2Controller : ApiController
    {
        [VersionedRoute("", 2)]
        public IHttpActionResult Get()
        {
            return Ok(DbFake.Mails);
        }

        [VersionedRoute("{id}", 2)]
        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Mails.Find(x => x.Id == id));
        }

        [VersionedRoute("", 2)]
        public IHttpActionResult Post([FromBody]Mail mail)
        {
            if (mail == null)
                return BadRequest("Mail is null");

            DbFake.Mails.Add(mail);
            return Ok();
        }

        [VersionedRoute("{id}", 2)]
        public IHttpActionResult Put(int id, [FromBody]Mail mail)
        {
            if (mail == null)
                return BadRequest("Mail is null");

            var entity = DbFake.Mails.Find(x => x.Id == id);
            _mapper.Map(mail, entity);
            return Ok();
        }

        [VersionedRoute("{id}", 2)]
        public IHttpActionResult Delete(int id)
        {
            DbFake.Mails.Remove(DbFake.Mails.Find(x => x.Id == id));
            return Ok();
        }

        [VersionedRoute("{id}/attachements", 2)]
        public IHttpActionResult GetAttachement(int id)
        {
            return Ok(DbFake.Attachements.Where(x => x.MailId == id));
        }

        [VersionedRoute("{id}/attachements/{attId}", 2)]
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

        [VersionedRoute("{id}/attachements", 2)]
        public IHttpActionResult PostAttachement(int id, [FromBody]Attachement attachement)
        {
            if (attachement == null)
                return BadRequest("Attachement is null");

            DbFake.Attachements.Add(attachement);
            return Ok();
        }

        [VersionedRoute("{id}/attachements/{attId}", 2)]
        public IHttpActionResult PutAttachement(int id, int attId, [FromBody]Attachement attachement)
        {
            if (attachement == null)
                return BadRequest("Attachement is null");

            var entity = DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId);
            _mapper.Map(attachement, entity);
            return Ok();
        }

        [VersionedRoute("{id}/attachements/{attId}", 2)]
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
