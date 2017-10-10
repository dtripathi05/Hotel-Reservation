using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelEntities;
using HotelAdapter;
using System.IO;
using HotelReservationEngine.Model;
using HotelReservationEngine.Adapter;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservationEngine.Controllers
{

    [Route("api/search")]
    public class SearchController : Controller
    {
        private static Dictionary<string, SearchRequest> _searchStore = new Dictionary<string, SearchRequest>();

        [HttpPost("newRequest")]
        public string NewRequest([FromBody]SearchRequest searchFields)
        {
            return Cache.AddToCache(searchFields);
        }

        [HttpGet("retriveRequest/{guid}")]
        public SearchRequest GetSearchFields(string guid)
        {
            return Cache.GetSearchRequest(guid);
        }

        [HttpPost("hotel")]
        public async Task<SearchResponse> Hotel([FromBody]SearchRequest searchFields)
        {
            IHotelFactory hotelFactory = Factory.GetHotelFactory("HotelsListing");
            var serialize = JsonConvert.SerializeObject(searchFields);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<SearchResponse>(result);
            return deserialize;
        }
    }
}
