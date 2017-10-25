using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class RoomInfo: IItinerary
    {
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string RoomDiscription { get; set; }
        public decimal price { get; set; }
        public string ImageUrl { get; set; }
        public string GuidId { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public float Distance { get; set; }
        public int Duration { get; set; }
    }
}
