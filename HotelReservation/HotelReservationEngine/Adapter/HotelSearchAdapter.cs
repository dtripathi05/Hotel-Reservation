using HotelEntities;
using HotelSearchService;
using Parser;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HotelReservationEngine.Contracts;
using HotelReservationEngine.HotelMultiAvailItinerary;

namespace HotelAdapter
{
    public class HotelSearchAdapter : IHotelFactory
    {
        public async Task<string> SearchAsync(string request)
        {
            HotelEngineClient engineRepresentative = null;
            MultiAvailItinery searchResponse = null;
            try
            {
                var convert = JsonConvert.DeserializeObject<MultiAvailSearchRequest>(request);
                engineRepresentative = new HotelEngineClient();
                MultiAvailParser parser = new MultiAvailParser();
                HotelSearchRQ hotelSearchReq = parser.RequestTranslator(convert);
                HotelSearchRS hotelSearchRS = await engineRepresentative.HotelAvailAsync(hotelSearchReq);
                searchResponse = parser.ResponseTranslator(hotelSearchRS,hotelSearchReq);
            }
            catch
            {
                throw;
            }
            finally
            {
                await engineRepresentative.CloseAsync();
            }
            return JsonConvert.SerializeObject(searchResponse);
        }
    }
}
