using HotelEntities;
using HotelSearchService;
using Parser;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservation.Contract;
using System;

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
                HotelSearchRQ hotelSearchReq = parser.MultiAvailRQParser(convert);
                HotelSearchRS hotelSearchRS = await engineRepresentative.HotelAvailAsync(hotelSearchReq);
                searchResponse = parser.MultiAvailRSParser(hotelSearchRS,hotelSearchReq);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                await engineRepresentative.CloseAsync();
            }
            return JsonConvert.SerializeObject(searchResponse);
        }
    }
}
