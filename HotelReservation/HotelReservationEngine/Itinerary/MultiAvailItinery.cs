using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
