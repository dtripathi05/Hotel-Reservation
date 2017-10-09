using HotelAdapter;
using HotelEntities;
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
            ConnectorAdapter adapter = new ConnectorAdapter();
            var result = await adapter.SearchAsync(request);
            Assert.NotNull(result);
        }
    }
}
