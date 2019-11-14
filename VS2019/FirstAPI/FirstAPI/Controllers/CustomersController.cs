using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer { Id = 101, Firstname = "John", Lastname = "Smith" },
            new Customer { Id = 102, Firstname = "Mary", Lastname = "Jane" },
            new Customer { Id = 103, Firstname = "Joe", Lastname = "Guy" }
        };

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize]
        public Customer Get(int id)
        {
            var customer = _customers
                .Where(c => c.Id == id)
                .SingleOrDefault<Customer>();

            return customer;
        }

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] Customer newCustomer)
        {
            int id = _customers.Max(c => c.Id) + 1;
            newCustomer.Id = id;

            _customers.Add(newCustomer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer existingCustomer)
        {
            var customer = _customers.Where(c => c.Id == id)
                .SingleOrDefault<Customer>();
            if(customer != null)
            {
                customer.Firstname = existingCustomer.Firstname;
                customer.Lastname = existingCustomer.Lastname;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = _customers.Where(c => c.Id == id)
                .SingleOrDefault<Customer>();
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}
