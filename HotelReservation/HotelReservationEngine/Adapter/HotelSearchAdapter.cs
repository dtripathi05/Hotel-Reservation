using HotelEntities;
using HotelReservationEngine.Adapter;
using HotelSearchService;
using Parser;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HotelReservationEngine.Log;

namespace HotelAdapter
{
    public class HotelSearchAdapter : IHotelFactory
    {
        public async Task<string> SearchAsync(string request)
        {
            HotelEngineClient engineRepresentative = null;
            MultiAvailSearchResponse searchResponse = null;
            
            try
            {
                var convert = JsonConvert.DeserializeObject<MultiAvailSearchRequest>(request);
                engineRepresentative = new HotelEngineClient();
                MultiAvailParser parser = new MultiAvailParser();
                HotelSearchRQ hotelSearchReq = parser.RequestTranslator(convert);
                HotelSearchRS hotelSearchRS = await engineRepresentative.HotelAvailAsync(hotelSearchReq);
                searchResponse = parser.ResponseTranslator(hotelSearchRS);
            }
            catch(Exception ex)
            {
                Logger logger = new Logger();
                logger.ExecuteLogger(ex.ToString());
            }
            finally
            {
                await engineRepresentative.CloseAsync();
            }

            return JsonConvert.SerializeObject(searchResponse);
        }
    }
}
