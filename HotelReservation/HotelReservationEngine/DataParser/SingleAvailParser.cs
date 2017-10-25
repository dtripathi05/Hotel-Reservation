using HotelSearchService;
using HotelReservationEngine.HotelMultiAvailItinerary;
using System;
using HotelReservation.Logger;
using HotelReservationEngine.Model;
using HotelEntities;
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
            //List<RoomInfo> roomInfo = new List<RoomInfo>();
            //for (int i = 0;i < hotelRoomAvailRS.Itinerary.Rooms.Length;i++)
            //{
            //    string imageUrl = "";
            //    for (int j = 0; j <= hotelRoomAvailRS.Itinerary.HotelProperty.MediaContent.Length; j++)
            //    {
            //        if (hotelRoomAvailRS.Itinerary.HotelProperty.MediaContent[j].Url != null)
            //        {
            //            imageUrl = hotelRoomAvailRS.Itinerary.HotelProperty.MediaContent[j].Url.ToString();
            //            break;
            //        }
            //    }
            //    RoomInfo room = new RoomInfo()
            //    {
            //        GuidId=cache,
            //        HotelName= hotelRoomAvailRS.Itinerary.HotelProperty.Name,
            //        ImageUrl=imageUrl,
            //        price= hotelRoomAvailRS.Itinerary.Rooms[i].DisplayRoomRate.BaseFare.Amount,
            //        RoomDiscription= hotelRoomAvailRS.Itinerary.Rooms[i].RoomDescription,
            //        RoomName= hotelRoomAvailRS.Itinerary.Rooms[i].RoomName,
            //        Address=hotelRoomAvailRS.Itinerary.HotelProperty.Address.CompleteAddress,
            //        Rating=hotelRoomAvailRS.Itinerary.HotelProperty.HotelRating.Rating,
            //        Distance= hotelRoomAvailRS.Itinerary.HotelProperty.Distance.Amount,
            //        Duration= hotelRoomAvailRS.Itinerary.StayPeriod.Duration
            //    };
            //    roomInfo.Add(room);
            //}
            //var result = new RoomList() { Rooms = roomInfo };
            return singleAvail;
        }
    }
}
