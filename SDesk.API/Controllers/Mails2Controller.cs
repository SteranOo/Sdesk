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
    [VersionedRoute("api/mails", 2)]
    public class Mails2Controller : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(DbFake.Mails);
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Mails.Find(x => x.Id == id));
        }

        public IHttpActionResult Post([FromBody]Mail mail)
        {
            DbFake.Mails.Add(mail);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody]Mail mail)
        {
            var entity = DbFake.Mails.Find(x => x.Id == id);
            _mapper.Map(mail, entity);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            DbFake.Mails.Remove(DbFake.Mails.Find(x => x.Id == id));
            return Ok();
        }

        [Route("api/mails/{id}/attachements")]
        public IHttpActionResult GetAttachement(int id)
        {
            return Ok(DbFake.Attachements.Where(x => x.MailId == id));
        }

        [Route("api/mails/{id}/attachements/{attId}")]
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

        [Route("api/mails/{id}/attachements")]
        public IHttpActionResult PostAttachement(int id, [FromBody]Attachement attachement)
        {
            DbFake.Attachements.Add(attachement);
            return Ok();
        }

        [Route("api/mails/{id}/attachements/{attId}")]
        public IHttpActionResult PutAttachement(int id, int attId, [FromBody]Attachement attachement)
        {
            var entity = DbFake.Attachements.Find(x => x.MailId == id && x.Id == attId);
            _mapper.Map(attachement, entity);
            return Ok();
        }

        [Route("api/mails/{id}/attachements/{attId}")]
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
