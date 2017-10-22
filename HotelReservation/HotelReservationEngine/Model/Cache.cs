using HotelEntities;
using HotelReservation.Logger;
using System;
using System.Collections.Generic;

namespace HotelReservationEngine.Model
{
    public class Cache
    {
        private static Dictionary<string, MultiAvailSearchRequest> _searchStore = new Dictionary<string, MultiAvailSearchRequest>();
        public static string AddToCache(MultiAvailSearchRequest request)
        {
            var guidId = Guid.NewGuid().ToString();

            try
            {
                if (request == null)
                {
                    throw new NullReferenceException();
                }
                _searchStore.Add(guidId, request);
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return guidId;
        }
        public static MultiAvailSearchRequest GetSearchRequest(string guid)
        {
            return _searchStore[guid];
        }
    }
}
