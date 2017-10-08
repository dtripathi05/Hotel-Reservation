using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using HotelSearchService;
using HotelEntities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservationEngine.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private static Dictionary<string, SearchRequest> _searchStore = new Dictionary<string, SearchRequest>();

        [HttpPost("newRequest")]
        public string NewRequest([FromBody]SearchRequest searchFields)
        {
            string guid = Guid.NewGuid().ToString();
            _searchStore[guid] = searchFields;
            return guid;
        }

        [HttpGet("retriveRequest/{guid}")]
        public SearchRequest GetSearchFields(string guid)
        {
            return _searchStore[guid];
        }
        
    }
}
