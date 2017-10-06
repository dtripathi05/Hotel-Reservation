using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HotelReservationEngine.Controllers
{
    [Route("/")]
    public class ValuesController : Controller
    {
        [HttpGet()]
        [HttpGet("/api/values")]
        [HttpGet("index")]
        public IActionResult GetIndexPage()
        {
            return File(new FileStream("wwwroot/Pages/index.html", FileMode.Open), "text/html");
        }
    }
}
