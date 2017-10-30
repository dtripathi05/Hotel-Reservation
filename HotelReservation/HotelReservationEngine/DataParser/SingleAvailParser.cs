using HotelSearchService;
using System;
using HotelReservation.Logger;
using HotelReservationEngine.Model;
using System.Collections.Generic;

namespace HotelReservationEngine.DataParser
{
    public class SingleAvailParser
    {
        public HotelRoomAvailRQ RoomRequestParser(SingleAvailItinerary singleAvailItinerary)
        {
            try
            {
                if (singleAvailItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return new HotelRoomAvailRQ
            {
                HotelSearchCriterion = singleAvailItinerary.Criteria,
                SessionId = singleAvailItinerary.SessionId,
                ResultRequested = ResponseType.Complete,
                Itinerary = singleAvailItinerary.Itinerary
            };
        }
        public SingleAvailItinerary RoomResponseParser(HotelRoomAvailRS hotelRoomAvailRS,SingleAvailItinerary singleAvailItinerary)
        {
            try
            {
                if (hotelRoomAvailRS == null && singleAvailItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            SingleAvailItinerary singleAvail= new SingleAvailItinerary()
            {
                SessionId=hotelRoomAvailRS.SessionId,
                Itinerary=hotelRoomAvailRS.Itinerary,
                Criteria= singleAvailItinerary.Criteria
            };
            var cache=Cache.AddToCache(singleAvail);
            return singleAvail;
        }
    }
}
