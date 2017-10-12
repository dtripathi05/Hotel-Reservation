using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.HotelMultiAvailItinerary;

namespace HotelReservationEngine.Adapter
{
    public class RoomPricingAdapter
    {
        public async Task<HotelRoomPriceRS> SearchAsync(SingleAvailItinerary request)
        {
            HotelEngineClient hotelEngineClient = new HotelEngineClient();
            

            RoomPricingParser parser = new RoomPricingParser();
            HotelRoomPriceRQ hotelRoomPriceRQ = parser.RoomPriceRQParser(request);
            HotelRoomPriceRS hotelRoomPriceRS = await hotelEngineClient.HotelRoomPriceAsync(hotelRoomPriceRQ);
            return hotelRoomPriceRS;
        }
    }
}
