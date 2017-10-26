using Microsoft.AspNetCore.Mvc;
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
