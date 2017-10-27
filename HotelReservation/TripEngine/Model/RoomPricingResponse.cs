using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngineService;

namespace TripEngine.Model
{
    public class RoomPricingResponse : IItinerary
    {
        public string SessionId { get; set; }
        public HotelTripProduct Product { get; set; }
        public HotelSearchCriterion Criteria { get; set; }
    }
}
