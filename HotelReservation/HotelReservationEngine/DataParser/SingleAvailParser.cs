using HotelSearchService;
using HotelReservationEngine.HotelMultiAvailItinerary;

namespace HotelReservationEngine.DataParser
{
    public class SingleAvailParser
    {
        public HotelRoomAvailRQ RoomRequestTranslator(SingleAvailItinerary singleAvailItinerary)
        {
            return new HotelRoomAvailRQ
            {
                HotelSearchCriterion = singleAvailItinerary.Criteria,
                SessionId = singleAvailItinerary.SessionId,
                ResultRequested = ResponseType.Complete,
                Itinerary = singleAvailItinerary.Itinerary
            };
        }
        public SingleAvailItinerary RoomResponseTranslator(HotelRoomAvailRS hotelRoomAvailRS,SingleAvailItinerary singleAvailItinerary)
        {
            return new SingleAvailItinerary
            {
                SessionId=hotelRoomAvailRS.SessionId,
                Itinerary=hotelRoomAvailRS.Itinerary,
                Criteria= singleAvailItinerary.Criteria
            };
        }
    }
}
