using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiExamples.Server.Models.People;
using WebApiExamples.Server.Storage;

namespace WebApiExamples.Server.Controllers
{
    [RoutePrefix("v1/people/{personId}/addresses")]
    public class AddressesController : ApiController
    {
        readonly PersonRepository _personRepository;

        public AddressesController()
        {
            _personRepository = new PersonRepository();
        }
        [Route("")]
        public IEnumerable<Address> Get(int personId)
        {
            var person = GetPersonById(personId);
            return person.Addresses;
        }

        [Route("{id}")]
        public Address Get(int personId, int id)
        {
            var person = GetPersonById(personId);
            var address = person.Addresses.FirstOrDefault(a => a.Id == id);
            if (address == null)
                throw new HttpException((int)HttpStatusCode.NotFound, "Address not found");
            return address;
        }

        Person GetPersonById(int personId)
        {
            var person = _personRepository.FindById(personId);
            if (person == null)
                throw new HttpException((int)HttpStatusCode.NotFound, "Person not found.");
            return person;
        }
    }
}