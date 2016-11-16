using System.Web.Http;
using AutoMapper;
using SDesk.DAL;
using SDesk.Model;

namespace SDesk.API.Controllers
{
    public class MailsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(DbFake.Mails);
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(DbFake.Mails.Find(x=>x.Id == id));
        }
      
        public IHttpActionResult Post([FromBody]Mail mail)
        {
            if (mail == null)
                return BadRequest("Mail is null");

            DbFake.Mails.Add(mail);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody]Mail mail)
        {
            if (mail == null)
                return BadRequest("Mail is null");

            var entity = DbFake.Mails.Find(x => x.Id == id);
            _mapper.Map(mail, entity);
            return Ok();
        }
     
        public IHttpActionResult Delete(int id)
        {
            DbFake.Mails.Remove(DbFake.Mails.Find(x => x.Id == id));
            return Ok();
        }

        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Mail, Mail>()));
    }
}
