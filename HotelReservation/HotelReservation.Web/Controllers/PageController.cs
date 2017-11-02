using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservation.Web.Controllers
{
    [Route("/")]
    public class PageController : Controller
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

        [HttpGet("rooms")]
        public IActionResult GetRooms()
        {
            return File(new FileStream("wwwroot/HtmlPages/roomListing.html", FileMode.Open), "text/html");
        }

        [HttpGet("roomPricing")]
        public IActionResult GetRoomPrice()
        {
            return File(new FileStream("wwwroot/HtmlPages/pricing.html", FileMode.Open), "text/html");
        }

        [HttpGet("guestDetails")]
        public IActionResult GetGuestDetails()
        {
            return File(new FileStream("wwwroot/HtmlPages/guestDetails.html", FileMode.Open), "text/html");
        }
        [HttpGet("bookingPage")]
        public IActionResult GetBookingPage()
        {
            return File(new FileStream("wwwroot/HtmlPages/finalpage.html", FileMode.Open), "text/html");
        }
    }
}
