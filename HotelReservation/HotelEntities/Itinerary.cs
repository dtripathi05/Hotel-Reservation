using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class Itinerary
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public GeoAxisCode GeoCode { get; set; }

        public string ImageUrl { get; set; }

        public decimal MinPrice { get; set; }
    }
}
