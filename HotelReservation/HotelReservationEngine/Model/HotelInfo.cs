using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class HotelInfo : IItinerary
    {
        public string SessionId { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string GuidId { get; set; }
        public int HotelId { get; set; }
        public string Supplier { get; set; }
        public decimal BasePrice { get; set; }
        public string CurrencyCode { get; set; }
        public string HotelDetails { get; set; }
    }
}
