using HotelEntities;
using HotelReservation.Contract;
using HotelReservationEngine.Adapter;
using HotelSearchService;
using Parser;
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
        public void MultiAvailParser_Test()
        {
            HotelEngineClient cLient = new HotelEngineClient();
            IHotelServiceFactory hotelFactory = Factory.GetHotelServices("HotelsListing");
            MultiAvailParser multiAvailParser = new MultiAvailParser();
            Assert.NotNull(multiAvailParser.MultiAvailRQParser(request));
        }
    }
}
