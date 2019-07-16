using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Web.Controllers
{
    public class CustomerController : Controller
    {
        private string _url = "http://localhost:54194/";

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

        public ActionResult CSRFDemo()
        {
            return View();
        }


    }
}