using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class SearchResponse
    {
        public Itinerary[] HotelResults { get; set; }
        public string SessionId { get; set; }
    }
}
