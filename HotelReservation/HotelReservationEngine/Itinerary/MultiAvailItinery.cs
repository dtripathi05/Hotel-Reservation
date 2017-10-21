using System.Collections.Generic;
using HotelSearchService;

namespace HotelReservationEngine.HotelMultiAvailItinerary
{
    public class MultiAvailItinerary
    {
        public List<HotelItinerary> Itinerary { get; set; } 
        public string SessionId { get; set; }
        public HotelSearchCriterion HotelSearchCriterion { get; set; }
    }
}
