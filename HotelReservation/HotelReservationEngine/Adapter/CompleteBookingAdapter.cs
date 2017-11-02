using HotelReservation.Contract;
using HotelReservation.Logger;
using HotelReservationEngine.DataParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngine.Model;
using TripEngineService;

namespace HotelReservationEngine.Adapter
{
    public class CompleteBookingAdapter : IHotelServiceFactory
    {
        private TripsEngineClient _tripsEngine = null;
        private CompleteBookingRQ _completeBookingRQ = null;
        private CompleteBookingRS _completeBookingRS = null;
        private CompleteBookingParser _completeBookingParser = null;
        private CompleteBookingResponse _completeBookingResponse = null;
        public async Task<IItinerary> GetHotelServiceRSAsync(IItinerary request)
        {
            try
            {
                _tripsEngine = new TripsEngineClient();
                _completeBookingParser = new CompleteBookingParser();
                _completeBookingRQ = _completeBookingParser.CompleteBookingRQParser((BookTripFolderResponse)request);
                _completeBookingRS = await _tripsEngine.CompleteBookingAsync(_completeBookingRQ);
                _completeBookingResponse = _completeBookingParser.CompleteBookingResponseParser(_completeBookingRS);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            finally
            {
                await _tripsEngine.CloseAsync();
            }
            return _completeBookingResponse;
        }
    }
}