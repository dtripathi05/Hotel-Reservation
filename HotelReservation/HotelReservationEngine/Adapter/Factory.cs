using HotelAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Adapter
{
    public class Factory
    {
        private static Dictionary<string, IHotelFactory> _services = new Dictionary<string, IHotelFactory>()
        {
            { "HotelsListing",new HotelSearchAdapter()}
        };
        public static IHotelFactory GetHotelFactory(string type)
        {
            IHotelFactory result;
             _services.TryGetValue(type, out result);
            return result;
        }
    }
}
