using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class HotelList:IItinerary
    {
        public List<HotelInfo> Hotels { get; set; }
    }
}
