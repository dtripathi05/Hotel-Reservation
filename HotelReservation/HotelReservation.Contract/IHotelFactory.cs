using System;
using System.Threading.Tasks;

namespace HotelReservation.Contract
{
    public interface IHotelFactory
    {
        Task<string> SearchAsync(string request);
    }
}
