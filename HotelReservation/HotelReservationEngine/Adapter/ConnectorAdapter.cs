using HotelEntities;
using HotelSearchService;
using Parser;
using System;
using System.Threading.Tasks;

namespace HotelAdapter
{
    public class ConnectorAdapter
    {
        public async Task<SearchResponse> SearchAsync(SearchRequest hotelSearchRQ)
        {
            HotelEngineClient engineRepresentative = new HotelEngineClient();
            DataParser parser = new DataParser();
            HotelSearchRQ hotelSearchReq = parser.RequestTranslator(hotelSearchRQ);
            HotelSearchRS hotelSearchRS = await engineRepresentative.HotelAvailAsync(hotelSearchReq);
            SearchResponse searchResponse = parser.ResponseTranslator(hotelSearchRS);
            return searchResponse;
        }
    }
}
