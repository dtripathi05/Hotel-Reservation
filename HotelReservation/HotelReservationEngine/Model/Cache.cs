using HotelReservation.Contract;
using HotelReservation.Logger;
using System;
using System.Collections.Generic;

namespace HotelReservationEngine.Model
{
    public class Cache
    {
        private static Dictionary<string, IItinerary> _searchStore = new Dictionary<string, IItinerary>();
        public static string AddToCache(IItinerary request)
        {
            var guidId = Guid.NewGuid().ToString();

            try
            {
                if (request == null)
                {
                    throw new NullReferenceException();
                }
                _searchStore.Add(guidId,request);
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return guidId;
        }
        public static IItinerary GetSearchRequest(string guid)
        {
            try
            {
                if (guid == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return _searchStore[guid];
        }
    }
}
