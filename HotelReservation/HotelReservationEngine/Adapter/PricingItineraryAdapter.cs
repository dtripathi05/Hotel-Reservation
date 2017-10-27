using HotelEntities;
using HotelReservation.Contract;
using HotelReservation.Logger;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservationEngine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngine.Model;

namespace HotelReservationEngine.Adapter
{
    public class PricingItineraryAdapter
    {
        private RoomPricingItinerary _roomPricing = null;
        private SingleAvailItinerary _singleAvailItinerary = null;
        public RoomPricingItinerary GetRoomPricing(IItinerary requestedItinerary)
        {
            try
            {
                if (requestedItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            try
            {
                var req = (RoomInfo)requestedItinerary;
                var roomName = req.RoomName;
                _singleAvailItinerary = (SingleAvailItinerary)Cache.GetSearchRequest(req.GuidId.ToString());
                string jsonItinerary = JsonConvert.SerializeObject(_singleAvailItinerary.Itinerary);
                TripEngineService.HotelItinerary hotelItinerary = JsonConvert.DeserializeObject<TripEngineService.HotelItinerary>(jsonItinerary);
                string jsonCriteria = JsonConvert.SerializeObject(_singleAvailItinerary.Itinerary);
                TripEngineService.HotelSearchCriterion criteria = JsonConvert.DeserializeObject<TripEngineService.HotelSearchCriterion>(jsonCriteria);
                _roomPricing = new RoomPricingItinerary
                {
                    Itinerary = hotelItinerary,
                    Criteria = criteria,
                    SessionId = _singleAvailItinerary.SessionId,
                    RoomName = req.RoomName
                };
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return _roomPricing;
        }
    }
}
