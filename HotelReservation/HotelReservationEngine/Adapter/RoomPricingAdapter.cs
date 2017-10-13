using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservationEngine.Contracts;
using Newtonsoft.Json;
using TripEngineService;
using TripEngine.Model;

namespace HotelReservationEngine.Adapter
{
    public class RoomPricingAdapter:IHotelFactory
    {
        TripsEngineClient engineClient;
        TripProductPriceRQ tripProductPriceRQ;
        TripProductPriceRS tripProductPriceRS;
        RoomPricingResponse roomPricingResponse;
        
        public async Task<string> SearchAsync(string request)
        {
            try
            {
                engineClient = new TripsEngineClient();
                var deserialize = JsonConvert.DeserializeObject<RoomPricingItinerary>(request);
                RoomPricingParser parser = new RoomPricingParser();
                tripProductPriceRQ = parser.RoomPriceRQParser(deserialize);
                tripProductPriceRS = await engineClient.PriceTripProductAsync(tripProductPriceRQ);
                roomPricingResponse = parser.RoomPriceRSParser(tripProductPriceRS, deserialize);
            }
            catch(Exception excep)
            {
                throw;
            }
            finally
            {
                await engineClient.CloseAsync();
            }
            return JsonConvert.SerializeObject(roomPricingResponse);
        }
    }
}
