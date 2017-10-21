using System;

namespace HotelReservation.Contract
{
    public interface IHotelFactory
    {
        Task<string> SearchAsync(string request);
    }
}
