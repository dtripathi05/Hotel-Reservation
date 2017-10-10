using HotelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class Cache
    {
        private static Dictionary<string, MultiAvailSearchRequest> _searchStore = new Dictionary<string, MultiAvailSearchRequest>();

        public static string AddToCache(MultiAvailSearchRequest request)
        {
            var guidId = Guid.NewGuid().ToString();
            _searchStore.Add(guidId, request);
            return guidId;
        }
        public static MultiAvailSearchRequest GetSearchRequest(string guid)
        {
            return _searchStore[guid];
        }
    }
}
