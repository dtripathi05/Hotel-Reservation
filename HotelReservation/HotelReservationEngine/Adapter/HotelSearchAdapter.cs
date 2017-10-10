using HotelEntities;
using HotelReservationEngine.Adapter;
using HotelSearchService;
using Parser;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace HotelAdapter
{
    public class HotelSearchAdapter:IHotelFactory
    {
        public async Task<string> SearchAsync(string request)
        {
            var convert = JsonConvert.DeserializeObject<SearchRequest>(request);
            HotelEngineClient engineRepresentative = new HotelEngineClient();
            MultiAvailParser parser = new MultiAvailParser();
            HotelSearchRQ hotelSearchReq = parser.RequestTranslator(convert);
            HotelSearchRS hotelSearchRS = await engineRepresentative.HotelAvailAsync(hotelSearchReq);
            SearchResponse searchResponse = parser.ResponseTranslator(hotelSearchRS);
            return JsonConvert.SerializeObject(searchResponse);
        }
    }
}
