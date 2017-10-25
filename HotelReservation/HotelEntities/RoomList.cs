using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class RoomList: IItinerary
    {
        public List<RoomInfo> Rooms { get; set; }
    }
}
