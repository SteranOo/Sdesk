using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using SDesk.DAL;
using SDesk.Model;

namespace SDesk.API.Controllers
{
    public class AttachementsController : ApiController
    {
        [Route("api/mails/{id}/attachements")]
        public IEnumerable<Attachement> Get(int id)
        {
            return DbFake.Attachements.Where(x=>x.MailId == id);
        }

        [Route("api/mails/{id}/attachements/{attId}")]
        public IEnumerable<Attachement> Get(int id, int attId, string extention = null, int? status = null)
        {
            return DbFake.Attachements.Where(x => x.MailId == id);
        }

        private IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Attachement, Attachement>()));
    }
}
