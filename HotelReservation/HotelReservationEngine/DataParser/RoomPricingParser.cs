using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using HotelReservationEngine.HotelMultiAvailItinerary;

namespace HotelReservationEngine.DataParser
{
    public class RoomPricingParser
    {
        public HotelRoomPriceRQ RoomPriceRQParser(SingleAvailItinerary singleAvailItinerary)
        {
            return new HotelRoomPriceRQ
            {
                HotelSearchCriterion = singleAvailItinerary.Criteria,
                SessionId=singleAvailItinerary.SessionId,
                Itinerary=singleAvailItinerary.Itinerary,
            };
        }
        public SingleAvailItinerary RoomPriceRSParser(HotelRoomPriceRS hotelRoomAvailRS, SingleAvailItinerary singleAvailItinerary)
        {
            return new SingleAvailItinerary
            {
                SessionId = hotelRoomAvailRS.SessionId,
                Itinerary = hotelRoomAvailRS.Itinerary,
                Criteria = singleAvailItinerary.Criteria
            };
        }
    }
}
