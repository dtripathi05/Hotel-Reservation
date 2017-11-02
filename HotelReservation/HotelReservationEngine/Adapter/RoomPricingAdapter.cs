using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using HotelReservationEngine.DataParser;
//using HotelReservationEngine.HotelMultiAvailItinerary;
using Newtonsoft.Json;
using TripEngineService;
using TripEngine.Model;
using HotelReservation.Contract;
using HotelReservation.Logger;

namespace HotelReservationEngine.Adapter
{
    public class RoomPricingAdapter : IHotelServiceFactory
    {
        private TripsEngineClient _engineClient = null;
        private TripProductPriceRQ _tripProductPriceRQ = null;
        private TripProductPriceRS _tripProductPriceRS = null;
        private RoomPricingResponse _roomPricingResponse = null;
        private RoomPricingParser _parser = null;

        public async Task<IItinerary> GetHotelServiceRSAsync(IItinerary request)
        {
            try
            {
                _engineClient = new TripsEngineClient();
                _parser = new RoomPricingParser();
                _tripProductPriceRQ = _parser.RoomPriceRQParser((RoomPricingItinerary)request);
                _tripProductPriceRS = await _engineClient.PriceTripProductAsync(_tripProductPriceRQ);
                _roomPricingResponse = _parser.RoomPriceRSParser(_tripProductPriceRS, (RoomPricingItinerary)request);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            finally
            {
                await _engineClient.CloseAsync();
            }
            return _roomPricingResponse;
        }
    }
}
