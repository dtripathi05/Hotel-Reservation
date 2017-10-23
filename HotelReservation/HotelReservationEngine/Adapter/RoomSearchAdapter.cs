using HotelReservation.Contract;
using HotelReservation.Logger;
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

        public async Task<IItinerary> SearchAsync(IItinerary requestedItinerary)
        {
            try
            {
                _engineRepresentative = new HotelEngineClient();
                _parser = new SingleAvailParser();
                _hotelRoomAvailRQ = _parser.RoomRequestParser((SingleAvailItinerary)requestedItinerary);
                _hotelRoomAvailRS = await _engineRepresentative.HotelRoomAvailAsync(_hotelRoomAvailRQ);
                _singleAvailItinerary = _parser.RoomResponseParser(_hotelRoomAvailRS, (SingleAvailItinerary)requestedItinerary);
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            finally
            {
                await _engineRepresentative.CloseAsync();
            }
            return _singleAvailItinerary;
        }
    }
}