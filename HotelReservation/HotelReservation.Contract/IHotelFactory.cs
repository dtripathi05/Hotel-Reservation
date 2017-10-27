using System;
using System.Threading.Tasks;

namespace HotelReservation.Contract
{
    public interface IHotelFactory
    {
        Task<IItinerary> SearchAsync(IItinerary requestedItinerary);
    }
}
