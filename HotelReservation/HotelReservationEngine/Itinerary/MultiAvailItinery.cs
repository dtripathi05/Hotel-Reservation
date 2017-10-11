using System.Collections.Generic;
using HotelSearchService;

namespace HotelReservationEngine.HotelMultiAvailItinerary
{
    public class MultiAvailItinery
    {
        public List<HotelItinerary> Itinerary { get; set; } 
        public string SessionId { get; set; }
        public HotelSearchCriterion hotelSearchCriterion { get; set; }
    }
}
