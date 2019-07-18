using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClient.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonApiController : ControllerBase
    {

        private static List<Person> People = new List<Person>()
            {
                new Person() {Id=1, Name = "Fred Blogs"},
                new Person() {Id=2, Name = "James Smith"},
                new Person() {Id=3, Name = "Jerry Jones" }
            };

        public PersonApiController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(People);
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(int id)
        {
            Person person = (from p in People where p.Id == id select p)
                .FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(person);
            }
        }

        // POST api/person
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            int nextId = (from p in People select p.Id).Max() + 1;
            person.Id = nextId;
            People.Add(person);

            return CreatedAtRoute("GetPerson", new { id = nextId }, person);
        }
    }
}