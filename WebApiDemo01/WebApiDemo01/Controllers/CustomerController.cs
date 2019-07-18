using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo01.Model;

// TODO:
// To test jQuery, remove "launchUrl" from Properties/launchSettings.json.
//
namespace WebApiDemo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CustomerController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CustomerController(ApiDbContext context)
        {
            _context = context;

            if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(
                    new Customer
                    {
                        Id = 101,
                        Firstname = "Ajay",
                        Lastname = "Singala"
                    }
                    );
                _context.SaveChanges();
            }
        }

        // GET api/Customer
        [HttpGet]
        //[Produces("application/xml")]
        public async Task<IEnumerable<Customer>> Get()
        {
            var customers = await _context.Customers.ToListAsync<Customer>();
            return customers;
        }

        // GET api/Customer/10  
        [HttpGet("{id}")]
        //[Produces("application/xml")]
        public async Task<Customer> Get(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        // { "id":102, "firstname":"John", "lastname":"Smith" }
        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            var id = 0;
            if (_context.Customers.Count() > 0)
            {
                id = _context.Customers.Max(c => c.Id);
            }
            id++;

            customer.Id = id;
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(Get), 
                new { id = customer.Id }, 
                customer);
        }

        // { "id":102, "firstname":"John", "lastname":"Smith" }
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if(customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChangesAsync();

            return NoContent();
        }
    }
}