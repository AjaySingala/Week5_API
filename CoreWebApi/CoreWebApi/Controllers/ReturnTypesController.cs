using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypesController : ControllerBase
    {
        [Route("Log")]
        public void LogData()
        {
            // Perform some logging tasks.
        }

        [Route("Data")]
        public HttpResponseMessage GetData()
        {
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("hello geek97", Encoding.Unicode);
            response.ReasonPhrase = "Data is processed";
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }

        private IList<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 101, Firstname = "John", Lastname = "Smith" },
                new Customer { Id = 102, Firstname = "Mary", Lastname = "Jane" },
                new Customer { Id = 103, Firstname = "Neo", Lastname = "Trinity" }
            };

            return customers;
        }

        //// Does not work on .NET Core!
        //[Route("DataInBody")]
        //public HttpResponseMessage GetDataInBody()
        //{
        //    var customers = this.GetCustomers();

        //    HttpRequestMessage request = new HttpRequestMessage();
        //    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK);
        //    //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = 
        //        new ObjectContent<IList<Customer>>(
        //            customers, 
        //            new JsonMediaTypeFormatter()
        //        );
        //    response.ReasonPhrase = "Data is processed";
        //    response.Headers.CacheControl = new CacheControlHeaderValue()
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20)
        //    };
        //    return response;
        //}

        // Synchronous action.
        [Route("Customers")]
        [ProducesResponseType(typeof(IList<Customer>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetListOfCustomers()
        {
            var customers = this.GetCustomers();
            if(customers == null || customers.Count <= 0)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // Synchronous action.
        [Route("Customer/{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSingleCustomer(int id)
        {
            var customer = this.GetCustomers()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // Asynchronous action.
        [HttpPost]
        [Route("AddCustomer")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCustomerAsync([FromBody] Customer customer)
        {
            if(customer == null || customer.Firstname.Contains("Dummy"))
            {
                return BadRequest();
            }

            customer.Id = new Random().Next(10);

            //await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetSingleCustomer), new { id = customer.Id }, customer);
        }

        // ActionResult<T>.
        [Route("GetCustomers")]
        public ActionResult<IEnumerable<Customer>> GetCustomer2()
        {
            // C# doesn't support implicit cast operators on interfaces.
            // Consequently, conversion of the interface to a concrete type is 
            // necessary to use ActionResult<T>. 
            // For example, use of IEnumerable in the following example doesn't work:
            // return GetCustomers();   // won't work.
            // Use .ToList() explicitly as follows:

            var customers = GetCustomers().ToList();
            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        // ?For Syn ops:
        [HttpGet("GetbyId/{id}")]
        //[Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = this.GetCustomers()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // For Async ops:
        [HttpPost]
        [Route("CreateAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Customer>> CreateAsync(Customer customer)
        {
            if (customer.Firstname.Contains("Dummy"))
            {
                return BadRequest();
            }

            //await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById), 
                new { id = customer.Id }, customer);
        }
    }
}
