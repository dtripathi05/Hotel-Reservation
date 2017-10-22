using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.HotelMultiAvailItinerary;
using Newtonsoft.Json;
using TripEngineService;
using TripEngine.Model;
using HotelReservation.Contract;
using HotelReservation.Logger;

namespace HotelReservationEngine.Adapter
{
    public class RoomPricingAdapter : IHotelFactory
    {
        private TripsEngineClient _engineClient = null;
        private TripProductPriceRQ _tripProductPriceRQ = null;
        private TripProductPriceRS _tripProductPriceRS = null;
        private RoomPricingResponse _roomPricingResponse = null;
        private RoomPricingParser _parser = null;

        public async Task<string> SearchAsync(string request)
        {
            try
            {
                _engineClient = new TripsEngineClient();
                var deserialize = JsonConvert.DeserializeObject<RoomPricingItinerary>(request);
                _parser = new RoomPricingParser();
                _tripProductPriceRQ = _parser.RoomPriceRQParser(deserialize);
                _tripProductPriceRS = await _engineClient.PriceTripProductAsync(_tripProductPriceRQ);
                _roomPricingResponse = _parser.RoomPriceRSParser(_tripProductPriceRS, deserialize);
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            finally
            {
                await _engineClient.CloseAsync();
            }
            return JsonConvert.SerializeObject(_roomPricingResponse);
        }
    }
}
