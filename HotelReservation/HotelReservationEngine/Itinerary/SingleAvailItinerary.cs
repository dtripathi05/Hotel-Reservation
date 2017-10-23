using HotelReservation.Contract;
using HotelSearchService;

namespace HotelReservationEngine.HotelMultiAvailItinerary
{
    public class SingleAvailItinerary : IItinerary
    {
        public HotelItinerary Itinerary { get; set; }
        public HotelSearchCriterion Criteria { get; set; }
        public string SessionId { get; set; }
    }
}
