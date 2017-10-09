using HotelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class Cache
    {
        private static Dictionary<string, SearchRequest> _searchStore = new Dictionary<string, SearchRequest>();

        public static string AddToCache(SearchRequest request)
        {
            var guidId = Guid.NewGuid().ToString();
            _searchStore.Add(guidId, request);
            return guidId;
        }
        public static SearchRequest GetSearchRequest(string guid)
        {
            return _searchStore[guid];
        }
    }
}
