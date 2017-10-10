using HotelAdapter;
using HotelEntities;
using HotelReservationEngine.Adapter;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HotelEngineReservation.Test
{
    public class SearchRequest_Test
    {
        SearchRequest request = null;
        public SearchRequest_Test()
        {
            request = new SearchRequest
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
            var deserialize = JsonConvert.DeserializeObject<SearchResponse>(result);
            Assert.NotNull(deserialize);
            
        }
    }
}
