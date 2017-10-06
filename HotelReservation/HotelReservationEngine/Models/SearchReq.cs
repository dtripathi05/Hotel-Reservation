using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Models
{
    public class SearchReq
    {
        public string Destination { get; set; }
        //yyyy-MM-dd
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Adults { get; set; }
        public int Rooms { get; set; }
        public int ChildAge { get; set; }
    }
}
