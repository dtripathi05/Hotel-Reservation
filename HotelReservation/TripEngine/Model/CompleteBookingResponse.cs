using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripEngine.Model
{
    public class CompleteBookingResponse : IItinerary
    {
        public string ConfirmationNumber { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string TravelerName { get; set; }
    }
}
