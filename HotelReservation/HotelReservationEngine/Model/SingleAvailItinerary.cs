using HotelReservation.Contract;
using HotelSearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class SingleAvailItinerary : IItinerary
    {
        private HotelItinerary _hotelItinerary;
        private HotelSearchCriterion _hotelSearchCriterion;
        private string _sessionId;
        public HotelItinerary Itinerary
        {
            get { return this._hotelItinerary; }
            set { this._hotelItinerary = value; }
        }
        public HotelSearchCriterion Criteria
        {
            get { return this._hotelSearchCriterion; }
            set { this._hotelSearchCriterion = value; }
        }
        public string SessionId
        {
            get { return this._sessionId; }
            set { this._sessionId=value; }
        }
    }
}
