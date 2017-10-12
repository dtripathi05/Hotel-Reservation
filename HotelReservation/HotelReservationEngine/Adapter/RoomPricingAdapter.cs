using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelReservationEngine.Contracts;
using Newtonsoft.Json;
namespace HotelReservationEngine.Adapter
{
    public class RoomPricingAdapter:IHotelFactory
    {
        HotelEngineClient engineRepresentative = null;
        HotelRoomPriceRQ hotelRoomPriceRQ = null;
        HotelRoomPriceRS hotelRoomPriceRS = null;
        SingleAvailItinerary singleAvailItinerary = null;
        public async Task<string> SearchAsync(string request)
        {
            try
            {
                var deserialize = JsonConvert.DeserializeObject<SingleAvailItinerary>(request);
                HotelEngineClient hotelEngineClient = new HotelEngineClient();
                RoomPricingParser parser = new RoomPricingParser();
                HotelRoomPriceRQ hotelRoomPriceRQ = parser.RoomPriceRQParser(deserialize);
                HotelRoomPriceRS hotelRoomPriceRS = await hotelEngineClient.HotelRoomPriceAsync(hotelRoomPriceRQ);
                SingleAvailItinerary singleAvailItinerary = parser.RoomPriceRSParser(hotelRoomPriceRS, deserialize);
            }
            catch
            {
                throw;
            }
            finally
            {
                await engineRepresentative.CloseAsync();
            }
            return JsonConvert.SerializeObject(singleAvailItinerary);
        }
    }
}
