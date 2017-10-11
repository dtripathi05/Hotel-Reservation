using HotelSearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.HotelMultiAvailItinerary
{
    public class SingleAvailItinerary
    {
        public HotelItinerary Itinerary { get; set; }
        public HotelSearchCriterion Criteria { get; set; }
        public string SessionId { get; set; }
    }
}
