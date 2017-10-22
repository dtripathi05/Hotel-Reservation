using HotelEntities;
using HotelSearchService;
using Parser;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservation.Contract;
using System;
using HotelReservation.Logger;

namespace HotelAdapter
{
    public class HotelSearchAdapter : IHotelFactory
    {
        private HotelEngineClient _engineClient = null;
        private MultiAvailItinerary _searchResponse = null;
        private MultiAvailParser _parser = null;
        private HotelSearchRQ _hotelSearchRQ = null;
        private HotelSearchRS _hotelSearchRS = null;

        public async Task<string> SearchAsync(string request)
        {
            try
            {
                var convert = JsonConvert.DeserializeObject<MultiAvailSearchRequest>(request);
                _engineClient = new HotelEngineClient();
                _parser = new MultiAvailParser();
                _hotelSearchRQ = _parser.MultiAvailRQParser(convert);
                _hotelSearchRS = await _engineClient.HotelAvailAsync(_hotelSearchRQ);
                _searchResponse = _parser.MultiAvailRSParser(_hotelSearchRS, _hotelSearchRQ);
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            finally
            {
                await _engineClient.CloseAsync();
            }
            return JsonConvert.SerializeObject(_searchResponse);
        }
    }
}
