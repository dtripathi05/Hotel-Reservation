using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class HotelList : IItinerary
    {
        public List<HotelInfo> Hotels { get; set; }
    }
}
