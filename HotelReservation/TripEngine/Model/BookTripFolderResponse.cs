using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngineService;

namespace TripEngine.Model
{
    public class BookTripFolderResponse : IItinerary
    {
        public TripFolderBookRS TripFolderBookResponse { get; set; }
        public string SessionId { get; set; }
    }
}
