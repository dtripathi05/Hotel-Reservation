using HotelEntities;
using HotelReservation.Contract;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservationEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Adapter
{
    public class SingleAvailAdapter
    {
        private SingleAvailItinerary _singleAvail = null;
        public SingleAvailItinerary GetSingleAvail(IItinerary requestedItinerary)
        {
            var req = (HotelInfo)requestedItinerary;
            var hotelName = req.Name;
            MultiAvailItinerary multiAvailItinerary = (MultiAvailItinerary)Cache.GetSearchRequest(req.GuidId.ToString());
            foreach (var itinerary in multiAvailItinerary.Itinerary)
            {
                if (itinerary.HotelProperty.Name == hotelName)
                {
                    _singleAvail = new SingleAvailItinerary
                    {
                        Criteria = multiAvailItinerary.HotelSearchCriterion,
                        SessionId = multiAvailItinerary.SessionId,
                        Itinerary = itinerary
                    };
                }
            }
            return  _singleAvail;
        }
    }
}
