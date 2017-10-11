using HotelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Contracts
{
    public interface IHotelFactory
    {
       Task<string> SearchAsync(string request);
    }
}
