using HotelReservation.Contract;
using HotelSearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class SingleAvailItinerary : IItinerary
    {
        public HotelItinerary Itinerary { get; set; }
        public HotelSearchCriterion Criteria { get; set; }
        public string SessionId { get; set; }
    }
}
