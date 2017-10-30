using HotelReservationEngine.Model;
using System;
using Xunit;

namespace HotelReservation.Test
{
    public class Cache_Test
    {
        HotelSearchField request = null;
        public Cache_Test()
        {
            request = new HotelSearchField
            {
                Destination = new Location
                {
                    Latitude = 18.5599861f,
                    Longitude = 73.91191f,
                    CityName = "Pune",
                    SearchType = "Hotel"
                },
                Adult = 1,
                ChildrenCount = 2,
                Rooms = 1,
                CheckInDate = new DateTime(2017, 10, 11),
                CheckOutDate = new DateTime(2017, 10, 12)
            };
        }
        [Fact]
        public void GetSearchRequest_Test()
        {
            var guid = Cache.AddToCache(request);
            var resultRequest = Cache.GetSearchRequest(guid);
            Assert.Equal(request, resultRequest);
        }
    }
}
