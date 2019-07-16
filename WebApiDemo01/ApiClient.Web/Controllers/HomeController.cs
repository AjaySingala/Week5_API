using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiClient.Web.Models;
using System.Text.Encodings.Web;

namespace ApiClient.Web.Controllers
{
    public class HomeController : Controller
    {
        //UrlEncoder _urlEncoder;

        //public HomeController(UrlEncoder urlEncoder)
        //{
        //    _urlEncoder = urlEncoder;

        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var example = "\"Quoted Value with spaces and &\"";
            var encodedValue = System.Web.HttpUtility.UrlEncode(example);
            var encodedValue2 = System.Net.WebUtility.UrlEncode(example);
            var encodedValue3 = Uri.EscapeDataString(example);

            ViewData["HttpUtility_UrlEncode_EncodedValue"] = encodedValue;
            ViewData["WebUtility_UrlEncode_EncodedValue"] = encodedValue2;
            ViewData["EscapeDataString_EncodedValue"] = encodedValue3;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
