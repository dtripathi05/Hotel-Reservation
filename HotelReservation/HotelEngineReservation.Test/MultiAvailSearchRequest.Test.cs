using HotelEntities;
using HotelReservationEngine.Adapter;
using HotelReservationEngine.Contracts;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HotelReservation.Test
{
    public class MultiAvailSearchRequest_Test
    {
        MultiAvailSearchRequest request = null;
        public MultiAvailSearchRequest_Test()
        {
            request = new MultiAvailSearchRequest
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
        public async Task MultiAvailParser_Test()
        {
            IHotelFactory hotelFactory = Factory.GetHotelFactory("HotelsListing");
            var serialize = JsonConvert.SerializeObject(request);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<MultiAvailSearchResponse>(result);
            Assert.NotNull(deserialize);
            
        }
    }
}
