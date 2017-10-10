using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HotelEntities;
using System.Threading.Tasks;
using HotelReservationEngine.Contracts;
using HotelReservationEngine.Adapter;
using Newtonsoft.Json;
using HotelSearchService;
using Parser;


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
            IHotelFactory hotelFactory = Factory.GetHotelFactory("HotelsListing");
            var serialize = JsonConvert.SerializeObject(request);
            MultiAvailParser multiAvailParser = new MultiAvailParser();
            var deserialize = JsonConvert.DeserializeObject<MultiAvailSearchRequest>(serialize);
            HotelSearchRQ hotelSearchRQ = multiAvailParser.RequestTranslator(deserialize);
            HotelSearchRS hotelSearchRS = await cLient.HotelAvailAsync(hotelSearchRQ);
            MultiAvailSearchResponse searchResponse = multiAvailParser.ResponseTranslator(hotelSearchRS);
            var itenaryresult = searchResponse.HotelResults;
            var sessionId = searchResponse.SessionId;
            Assert.NotNull(itenaryresult);
            Assert.NotNull(sessionId);

        }
    }
}
