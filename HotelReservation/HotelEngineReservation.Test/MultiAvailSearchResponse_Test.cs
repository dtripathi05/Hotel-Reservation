using System;
using System.Text;
using Xunit;
using HotelEntities;
using System.Threading.Tasks;
using HotelReservationEngine.Adapter;
using HotelSearchService;
using Parser;
using HotelReservation.Contract;

namespace HotelReservation.Test
{
    public class MultiAvailSearchResponse_Test
    {
        MultiAvailSearchRequest request = null;

        public MultiAvailSearchResponse_Test()
        {
            request = new MultiAvailSearchRequest
            {
                Destination = new HotelEntities.Location
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
            HotelEngineClient cLient = new HotelEngineClient();
            IHotelServiceFactory hotelFactory = Factory.GetHotelServices("HotelsListing");
            MultiAvailParser multiAvailParser = new MultiAvailParser();
            HotelSearchRS hotelSearchRS = await cLient.HotelAvailAsync(multiAvailParser.MultiAvailRQParser(request));
            Assert.NotNull(hotelSearchRS);
        }
    }
}
