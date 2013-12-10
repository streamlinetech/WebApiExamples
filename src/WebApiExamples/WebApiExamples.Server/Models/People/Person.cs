using System.Collections.Generic;

namespace WebApiExamples.Server.Models.People
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}