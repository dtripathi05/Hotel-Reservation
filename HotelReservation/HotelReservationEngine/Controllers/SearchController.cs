using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelEntities;
using HotelReservationEngine.Model;
using HotelReservationEngine.Adapter;
using Newtonsoft.Json;
using HotelReservationEngine.HotelMultiAvailItinerary;
using TripEngine.Model;
using TripEngineService;
using HotelReservationEngine.DataParser;
using HotelReservation.Contract;

namespace HotelReservationEngine.Controllers
{

    [Route("api/search")]
    public class SearchController : Controller
    {
        private static Dictionary<string, MultiAvailSearchRequest> _searchStore = new Dictionary<string, MultiAvailSearchRequest>();

        [HttpPost("newRequest")]
        public string NewRequest([FromBody]MultiAvailSearchRequest searchFields)
        {
            return Cache.AddToCache(searchFields);
        }

        [HttpGet("retriveRequest/{guid}")]
        public MultiAvailSearchRequest GetSearchFields(string guid)
        {
            return Cache.GetSearchRequest(guid);
        }
        [HttpPost("hotel")]
        public async Task<MultiAvailItinerary> Hotel([FromBody]MultiAvailSearchRequest searchFields)
        {
            IHotelFactory hotelFactory = Factory.GetHotelServices("HotelsListing");
            var serialize = JsonConvert.SerializeObject(searchFields);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<MultiAvailItinerary>(result);
            return deserialize;
        }
        [HttpPost("room")]
        public async Task<SingleAvailItinerary> Rooms([FromBody]SingleAvailItinerary hotelItinerary)
        {
            IHotelFactory hotelFactory = Factory.GetHotelServices("RoomListing");
            var serialize = JsonConvert.SerializeObject(hotelItinerary);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<SingleAvailItinerary>(result);
            return deserialize;
        }
        [HttpPost("roomPrice")]
        public async Task<RoomPricingResponse> MarkUp([FromBody]RoomPricingItinerary room)
        {
            RoomPricingItinerary roomPricingItinerary = new RoomPricingItinerary().GetSelectedRoom(room);
            IHotelFactory hotelFactory = Factory.GetHotelServices("RoomPricing");
            var serialize = JsonConvert.SerializeObject(roomPricingItinerary);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<RoomPricingResponse>(result);
            return deserialize;

        }
        [HttpPost("completePayment")]
        public async Task<TripFolderBookRS> Booking([FromBody]BookTripRQ bookTripRQ)
        {
            BookTripParser bookTripParser = new BookTripParser(bookTripRQ);
            var result = await bookTripParser.GetTripFolderBookRS(bookTripParser.TripFolderBookRQ);
            // var result =await bookTripParser.tripFolderBookRQParser(bookTripRQ);
            return result;

        }
    }
}