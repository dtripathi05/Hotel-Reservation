using HotelReservation.Contract;
using HotelSearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class MultiAvailItinerary : IItinerary
    {
        public List<HotelItinerary> Itinerary { get; set; }
        public string SessionId { get; set; }
        public HotelSearchCriterion HotelSearchCriterion { get; set; }
    }
}
