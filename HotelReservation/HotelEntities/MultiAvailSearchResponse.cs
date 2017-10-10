using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class MultiAvailSearchResponse
    {
        public MultiAvailItinerary[] HotelResults { get; set; }
        public string SessionId { get; set; }
    }
}
