﻿using HotelReservation.Contract;
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
    public class CompleteBookingAdapter : IHotelFactory
    {
        private TripsEngineClient _tripsEngine = null;
        private CompleteBookingRQ _completeBookingRQ = null;
        private CompleteBookingRS _completeBookingRS = null;
        private CompleteBookingParser _completeBookingParser = null;
        
        public async Task<IItinerary> SearchAsync(IItinerary request)
        {
            try
            {
                _tripsEngine = new TripsEngineClient();
                _completeBookingParser = new CompleteBookingParser();
                _completeBookingRQ = _completeBookingParser.CompleteBookingRQParser((BookTripFolderResponse)request);
                _completeBookingRS = await _tripsEngine.CompleteBookingAsync(_completeBookingRQ);
                var response = _completeBookingRS;
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            finally
            {
                await _tripsEngine.CloseAsync();
            }
            return null;
        }
    }
}