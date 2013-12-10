using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiExamples.Server.Models.People;

namespace WebApiExamples.ClientApp
{
    class Program
    {
        readonly HttpClient _client;

        public Program()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5555")
            };
            _client.DefaultRequestHeaders.Add("X-Auth", "My Token Value");
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var response = await _client.GetAsync("v1/people");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Person>>();
        }


        static void Main(string[] args)
        {
            var program = new Program();

            var people = program.GetPeople().Result;
            foreach (var person in people)
                Console.WriteLine(person.FirstName);

            Console.ReadLine();
        }
    }
}
