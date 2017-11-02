//using HotelEntities;
using HotelReservation.Contract;
using HotelReservation.Logger;
using HotelReservationEngine.DataParser;
using HotelReservationEngine.Model;
//using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelSearchService;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HotelReservationEngine.Adapter
{
    public class RoomSearchAdapter : IHotelServiceFactory
    {
        private HotelEngineClient _engineRepresentative = null;
        private HotelRoomAvailRQ _hotelRoomAvailRQ = null;
        private HotelRoomAvailRS _hotelRoomAvailRS = null;
        private SingleAvailItinerary _singleAvailItinerary = null;
        private SingleAvailParser _parser = null;

        public async Task<IItinerary> GetHotelServiceRSAsync(IItinerary request)
        {
            try
            {
                _engineRepresentative = new HotelEngineClient();
                _parser = new SingleAvailParser();
                _hotelRoomAvailRQ = _parser.RoomRequestParser((SingleAvailItinerary)request);
                _hotelRoomAvailRS = await _engineRepresentative.HotelRoomAvailAsync(_hotelRoomAvailRQ);
                _singleAvailItinerary = _parser.RoomResponseParser(_hotelRoomAvailRS, (SingleAvailItinerary)request);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            finally
            {
                await _engineRepresentative.CloseAsync();
            }
            return _singleAvailItinerary;
        }
    }
}