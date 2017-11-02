//using HotelEntities;
using HotelReservation.Contract;
using HotelReservation.Logger;
//using HotelReservationEngine.HotelMultiAvailItinerary;
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
        public SingleAvailItinerary GetSingleAvail(IItinerary request)
        {
            try
            {
                var req = (HotelInfo)request;
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
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            return  _singleAvail;
        }
    }
}
