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
    public class TripBookFolderAdapter: IHotelServiceFactory
    {
        private TripsEngineClient _tripsEngineClient = null;
        private BookTripParser _bookTripParser = null;
        private TripFolderBookRQ _tripFolderBookRQ = null;
        private TripFolderBookRS _tripFolderBookRS = null;
        private BookTripFolderResponse _bookTripFolderResponse = null;
        public async Task<IItinerary> GetHotelServiceRSAsync(IItinerary request)
        {
            try
            {
                _tripsEngineClient = new TripsEngineClient();
                _bookTripParser = new BookTripParser();
                _tripFolderBookRQ = _bookTripParser.TripFolderBookRQParser((BookTripRQ)request);
                _tripFolderBookRS = await _tripsEngineClient.BookTripFolderAsync(_tripFolderBookRQ);
                _bookTripFolderResponse = _bookTripParser.TripFolderBookRSParser((BookTripRQ)request, _tripFolderBookRS);
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            finally
            {
                await _tripsEngineClient.CloseAsync();
            }
            return _bookTripFolderResponse;
        }

    }
}
