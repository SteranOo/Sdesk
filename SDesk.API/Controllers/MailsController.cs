using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using SDesk.DAL;
using SDesk.Model;

namespace SDesk.API.Controllers
{
    public class MailsController : ApiController
    {
        public IEnumerable<Mail> Get()
        {
            return DbFake.Mails;
        }

        public Mail Get(int id)
        {
            return DbFake.Mails.Find(x=>x.Id == id);
        }
      
        public void Post([FromBody]Mail mail)
        {
            DbFake.Mails.Add(mail);
        }

        public void Put(int id, [FromBody]Mail mail)
        {
            var entity = DbFake.Mails.Find(x => x.Id == id);
            _mapper.Map(mail, entity);
        }
     
        public void Delete(int id)
        {
            DbFake.Mails.Remove(DbFake.Mails.Find(x => x.Id == id));
        }

        private IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Mail, Mail>()));
    }
}
