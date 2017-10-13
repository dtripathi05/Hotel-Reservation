using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngineService;

namespace TripEngine.Model
{
    public class RoomPricingResponse
    {
        public string SessionId { get; set; }
        public HotelTripProduct Product { get; set; }
        public HotelSearchCriterion Criteria { get; set; }
    }
}
