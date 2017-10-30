using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class HotelList : IItinerary
    {
        private List<HotelInfo> _hotel;
        public List<HotelInfo> Hotels
        {
            get { return this._hotel; }
            set { this._hotel = value; }
        }
    }
}
