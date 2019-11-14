using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiClient.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Web.Controllers
{
    public class CustomerController : Controller
    {
        private string _url = "http://localhost:62838/";

        public string Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var apiUrl = "api/customer";
            var stringTask = client.GetStringAsync(_url + apiUrl);
            var res = stringTask.Result;

            return res;
        }

        public ActionResult XSSTest()
        {
            var person = new Person()
            {
                Id = 101,
                Name = "Some name"
            };

            return View(person);
        }

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult XSSTest(Person person)
        {
            return View(person);

            //return RedirectToAction("DisplayPerson", new { name = person.Name });
        }

        public ActionResult DisplayPerson(string name)
        {

            return View();
        }

        public ActionResult CSRFDemo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CSRFDemo(string data)
        {
            return View();
        }

        // For jQuery Demos
        public ActionResult GetCustomers()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            return View();
        }

        public ActionResult GetPerson()
        {
            return View();
        }

        public ActionResult CreatePerson()
        {
            return View();
        }
    }
}