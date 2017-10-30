using System;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using HotelReservationEngine.Adapter;
using HotelSearchService;
using Parser;
using HotelReservation.Contract;
using HotelReservationEngine.Model;

namespace HotelReservation.Test
{
    public class MultiAvailSearchResponse_Test
    {
        HotelSearchField request = null;

        public MultiAvailSearchResponse_Test()
        {
            request = new HotelSearchField
            {
                Destination = new HotelReservationEngine.Model.Location
                {
                    Latitude = 28.639f,
                    Longitude = 77.223f,
                    CityName = "New Delhi",
                    SearchType = "City"
                },
                Adult = 1,
                ChildrenCount = 2,
                Rooms = 1,
                CheckInDate = new DateTime(2017, 11, 11),
                CheckOutDate = new DateTime(2017, 11, 12)
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
