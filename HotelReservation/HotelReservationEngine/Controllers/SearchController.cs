using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelEntities;
using HotelReservationEngine.Model;
using HotelReservationEngine.Adapter;
using Newtonsoft.Json;
using HotelReservationEngine.Contracts;
using HotelReservationEngine.HotelMultiAvailItinerary;
using TripEngine.Model;
using TripEngineService;

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
        public async Task<MultiAvailItinery> Hotel([FromBody]MultiAvailSearchRequest searchFields)
        {
            IHotelFactory hotelFactory = Factory.GetHotelFactory("HotelsListing");
            var serialize = JsonConvert.SerializeObject(searchFields);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<MultiAvailItinery>(result);
            return deserialize;
        }
        [HttpPost("room")]
        public async Task<SingleAvailItinerary> Rooms([FromBody]SingleAvailItinerary hotelItinerary)
        {
            IHotelFactory hotelFactory = Factory.GetHotelFactory("RoomListing");
            var serialize = JsonConvert.SerializeObject(hotelItinerary);
            var result = await hotelFactory.SearchAsync(serialize);
            var deserialize = JsonConvert.DeserializeObject<SingleAvailItinerary>(result);
            return deserialize;
        }
        [HttpPost("roomPrice")]
        public async Task<RoomPricingResponse> MarkUp([FromBody]RoomPricingItinerary room)
        {
            RoomPricingItinerary roomPricingItinerary = new RoomPricingItinerary().GetSelectedRoom(room);
            IHotelFactory hotelFactory = Factory.GetHotelFactory("RoomPricing");
            var serialize= JsonConvert.SerializeObject(roomPricingItinerary);
            var result= await hotelFactory.SearchAsync(serialize);
            var deserialize= JsonConvert.DeserializeObject<RoomPricingResponse>(result);
            return deserialize;

        }
        [HttpPost("completePayment")]
        public async Task<RoomPricingResponse> Booking([FromBody]BookTripRQ bookTripRQ)
        {
            

        }
    }
}