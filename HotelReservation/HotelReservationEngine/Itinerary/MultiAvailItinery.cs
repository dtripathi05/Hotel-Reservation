using System.Collections.Generic;
using HotelSearchService;
using HotelReservation.Contract;

namespace HotelReservationEngine.HotelMultiAvailItinerary
{
    public class MultiAvailItinerary:IItinerary
    {
        public List<HotelItinerary> Itinerary { get; set; } 
        public string SessionId { get; set; }
        public HotelSearchCriterion HotelSearchCriterion { get; set; }
    }
}
