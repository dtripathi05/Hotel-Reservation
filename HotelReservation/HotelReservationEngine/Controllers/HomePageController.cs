﻿using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HotelReservationEngine.Controllers
{
    [Route("/")]
    public class HomePageController : Controller
    {
        [HttpGet()]
        [HttpGet("index")]
        public IActionResult GetIndexPage()
        {
            return File(new FileStream("wwwroot/HtmlPages/index.html", FileMode.Open), "text/html");
        }
        [HttpGet("hotel/{guidId}")]
        public IActionResult GetHotels(string guidId)
        {
            return File(new FileStream("wwwroot/HtmlPages/hotelListing.html", FileMode.Open), "text/html");
        }
    }
}
