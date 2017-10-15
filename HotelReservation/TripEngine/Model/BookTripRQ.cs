using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripEngine.Model
{
    public class BookTripRQ
    {
        private RoomPricingResponse _roomPricingResponse;

        public RoomPricingResponse RoomPricingResponse
        {
            get { return this._roomPricingResponse; }
            set { this._roomPricingResponse= value; }
        }

    }
}
