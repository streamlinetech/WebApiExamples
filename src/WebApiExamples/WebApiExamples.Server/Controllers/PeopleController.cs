using System.Collections.Generic;
using System.Web.Http;
using WebApiExamples.Server.Models.People;
using WebApiExamples.Server.Storage;

namespace WebApiExamples.Server.Controllers
{
    [RoutePrefix("v1/people")]
    public class PeopleController : ApiController
    {
        readonly PersonRepository _personRepository;
        public PeopleController()
        {
            _personRepository = new PersonRepository();
        }

        [Route("")]
        public IEnumerable<Person> Get()
        {
            return _personRepository.All();
        }

        [Route("{id}")]
        public Person Get(int id)
        {
            return _personRepository.FindById(id);
        }

    }
}
