//using HotelEntities;
using HotelSearchService;
using Parser;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservation.Contract;
using System;
using HotelReservation.Logger;
using System.Collections.Generic;
using HotelReservationEngine.Model;

namespace HotelAdapter
{
    public class HotelSearchAdapter : IHotelServiceFactory
    {
        private HotelEngineClient _engineClient = null;
        private HotelList _searchResponse = null;
        private MultiAvailParser _parser = null;
        private HotelSearchRQ _hotelSearchRQ = null;
        private HotelSearchRS _hotelSearchRS = null;

        public async Task<IItinerary> GetHotelServiceRSAsync(IItinerary request)
        {
            try
            {
                _engineClient = new HotelEngineClient();
                _parser = new MultiAvailParser();
                _hotelSearchRQ = _parser.MultiAvailRQParser((HotelSearchField)request);
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
            return _searchResponse;
        }
    }
}
