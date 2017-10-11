using HotelReservationEngine.Contracts;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelSearchService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Adapter
{
    public class RoomSearchAdapter : IHotelFactory
    {
        public async Task<string> SearchAsync(string request)
        {
            HotelEngineClient engineRepresentative = null;
            SingleAvailItinerary searchResponse = null;
            try
            {
                var convert = JsonConvert.DeserializeObject<SingleAvailItinerary>(request);
                engineRepresentative = new HotelEngineClient();
                SingleAvailParser parser = new SingleAvailParser();
                HotelRoomAvailRQ hotelRoomAvailRQ = parser.RoomRequestTranslator(convert);
                HotelRoomAvailRS hotelRoomAvailRS = await engineRepresentative.HotelRoomAvailAsync(hotelRoomAvailRQ);
                //searchResponse = parser.ResponseTranslator(hotelSearchRS, hotelSearchReq);
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