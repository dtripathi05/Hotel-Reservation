using HotelReservation.Contract;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelSearchService;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HotelReservationEngine.Adapter
{
    public class RoomSearchAdapter : IHotelFactory
    {
        private HotelEngineClient _engineRepresentative = null;
        private HotelRoomAvailRQ _hotelRoomAvailRQ = null;
        private HotelRoomAvailRS _hotelRoomAvailRS = null;
        private SingleAvailItinerary _singleAvailItinerary = null;
        private SingleAvailParser _parser = null;

        public async Task<string> SearchAsync(string request)
        {
            try
            {
                var convert = JsonConvert.DeserializeObject<SingleAvailItinerary>(request);
                _engineRepresentative = new HotelEngineClient();
                _parser = new SingleAvailParser();
                _hotelRoomAvailRQ = _parser.RoomRequestParser(convert);
                _hotelRoomAvailRS = await _engineRepresentative.HotelRoomAvailAsync(_hotelRoomAvailRQ);
                _singleAvailItinerary = _parser.RoomResponseParser(_hotelRoomAvailRS, convert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await _engineRepresentative.CloseAsync();
            }
            return JsonConvert.SerializeObject(_singleAvailItinerary);
        }
    }
}