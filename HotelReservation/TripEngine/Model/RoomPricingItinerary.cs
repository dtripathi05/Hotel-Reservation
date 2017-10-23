using HotelReservation.Contract;
using HotelReservation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngineService;

namespace TripEngine.Model
{
    public class RoomPricingItinerary : IItinerary
    {
        public HotelItinerary Itinerary { get; set; }
        public HotelSearchCriterion Criteria { get; set; }
        public string SessionId { get; set; }
        public string RoomName { get; set; }

        public RoomPricingItinerary GetSelectedRoom(RoomPricingItinerary roomPricingItinerary)
        {
            try
            {
                if (roomPricingItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return new RoomPricingItinerary
            {
                Criteria = roomPricingItinerary.Criteria,
                SessionId = roomPricingItinerary.SessionId,
                Itinerary = GetItinerary(roomPricingItinerary.Itinerary, roomPricingItinerary.RoomName)
            };
        }
        public HotelItinerary GetItinerary(HotelItinerary hotelItinerary, string roomName)
        {
            try
            {
                if (hotelItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }

            HotelItinerary hotel = hotelItinerary;
            Room room = new Room();
            for (int i = 0; i < hotelItinerary.Rooms.Length; i++)
            {
                if (hotelItinerary.Rooms[i].RoomName == roomName)
                {
                    room = hotelItinerary.Rooms[i];
                    break;
                }
            }
            hotel.Rooms = new Room[1];
            hotel.Rooms[0] = new Room();
            hotel.Rooms[0] = room;
            return hotel;
        }
    }
}


