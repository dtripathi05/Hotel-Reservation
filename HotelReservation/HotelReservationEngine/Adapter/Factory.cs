using HotelAdapter;
using HotelReservationEngine.Contracts;
using System.Collections.Generic;

namespace HotelReservationEngine.Adapter
{
    public class Factory
    {
        private static Dictionary<string, IHotelFactory> _services = new Dictionary<string, IHotelFactory>()
        {
            { "HotelsListing",new HotelSearchAdapter()},{"RoomListing",new RoomSearchAdapter()}
        };
        public static IHotelFactory GetHotelFactory(string type)
        {
            IHotelFactory result;
             _services.TryGetValue(type, out result);
            return result;
        }
    }
}
