using System;
using System.Threading.Tasks;

namespace HotelReservation.Contract
{
    public interface IHotelServiceFactory
    {
        Task<IItinerary> GetHotelServiceRSAsync(IItinerary request);
    }
}
