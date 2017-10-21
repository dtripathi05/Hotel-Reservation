using HotelAdapter;
using HotelReservation.Contract;
using System.Collections.Generic;

namespace HotelReservationEngine.Adapter
{
    public class Factory
    {
        private static Dictionary<string, IHotelFactory> _services = new Dictionary<string, IHotelFactory>()
        {
            { "HotelsListing",new HotelSearchAdapter()},{"RoomListing",new RoomSearchAdapter()},{"RoomPricing",new RoomPricingAdapter()}
        };
        public static IHotelFactory GetHotelServices(string type)
        {
            IHotelFactory result;
            _services.TryGetValue(type, out result);
            return result;
        }
    }
}
