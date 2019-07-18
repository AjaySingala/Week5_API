using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("List", Name = "MyIndex")]
        public string Index()
        {
            return "Index";
        }

        [HttpGet]
        [Route("View/{id}")]
        public string Details(int id)
        {
            return $"Details/{id}";
        }

        [HttpGet]
        [Route("View2/{id?}")]
        public string AnotherDetails(int id)
        {
            return $"AnotherDetails/{id}";
        }
    }
}