using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelEntities;
using HotelAdapter;
using System.IO;
using HotelReservationEngine.Model;

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
            ConnectorAdapter connectorAdapter = new ConnectorAdapter();
            var result = await connectorAdapter.SearchAsync(searchFields);
            return result;
        }
    }
}
