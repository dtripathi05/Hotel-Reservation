using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservationEngine.Controllers
{
    [Route("/")]
    public class HomePageController : Controller
    {
        [HttpGet()]
        [HttpGet("/index.html")]
        [HttpGet("index")]
        public IActionResult GetIndexPage()
        {
            return File(new FileStream("wwwroot/HtmlPages/hotellisting.html", FileMode.Open), "text/html");
        }
    }
}
