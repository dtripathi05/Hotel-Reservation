using HotelAdapter;
using HotelReservation.Contract;
using HotelReservation.Logger;
using System;
using System.Collections.Generic;

namespace HotelReservationEngine.Adapter
{
    public class Factory
    {
        private static Dictionary<string, IHotelServiceFactory> _services = new Dictionary<string, IHotelServiceFactory>()
        {
            { "HotelsListing",new HotelSearchAdapter()},{"RoomListing",new RoomSearchAdapter()},{"RoomPricing",new RoomPricingAdapter()},{"TripBookFolder",new TripBookFolderAdapter()},{"CompleteBooking",new CompleteBookingAdapter()}
        };
        public static IHotelServiceFactory GetHotelServices(string type)
        {
            IHotelServiceFactory result=null;
            try
            {
                _services.TryGetValue(type, out result);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            return result;
        }
    }
}
