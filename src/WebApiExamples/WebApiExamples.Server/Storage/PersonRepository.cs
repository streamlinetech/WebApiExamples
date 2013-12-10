using System.Collections.Generic;
using System.Linq;
using WebApiExamples.Server.Models.People;

namespace WebApiExamples.Server.Storage
{
    public class PersonRepository
    {
        readonly IEnumerable<Person> _peopleRepository;

        public PersonRepository()
        {
            _peopleRepository = SetupPersonRepository();
        }

        IEnumerable<Person> SetupPersonRepository()
        {
            yield return new Person()
            {
                Id = 1,
                FirstName = "Some",
                LastName = "One",
                IsActive = true,
                Addresses = new List<Address>()
                                         {
                                             new Address()
                                             {
                                                 Street = "123 Somewhere",
                                                 City = "Orlando",
                                                 Id = 1,
                                                 IsActive = true,
                                                 State = "FL",
                                                 Zip = "12345"
                                             }
                                         }
            };
        }

        public IEnumerable<Person> All()
        {
            return _peopleRepository.Where(p => p.IsActive).OrderBy(p => p.LastName);
        }

        public Person FindById(int id)
        {
            return All().FirstOrDefault(p => p.Id == id);
        }
    }
}