using HotelReservation.Contract;
using HotelSearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class MultiAvailItinerary : IItinerary
    {
        private List<HotelItinerary> _itinerary;
        private string _sessionId;
        private HotelSearchCriterion _hotelSearchCriterion;
        public List<HotelItinerary> Itinerary
        {
            get { return this._itinerary; }
            set { this._itinerary = value; }
        }
        public string SessionId
        {
            get { return this._sessionId; }
            set { this._sessionId = value; }
        }
        public HotelSearchCriterion HotelSearchCriterion
        {
            get { return this._hotelSearchCriterion; }
            set { this._hotelSearchCriterion = value; }
        }
    }
}