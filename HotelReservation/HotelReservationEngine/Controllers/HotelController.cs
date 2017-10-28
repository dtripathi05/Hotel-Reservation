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
using System;
using HotelReservation.Logger;

namespace HotelReservationEngine.Controllers
{

    [Route("api/hotel")]
    public class HotelController : Controller
    {
       // private static Dictionary<string, MultiAvailSearchRequest> _searchStore = new Dictionary<string, MultiAvailSearchRequest>();

        [HttpPost("searchField")]
        public string HotelSearchFields([FromBody]MultiAvailSearchRequest searchFields)
        {
            try
            {
                if (searchFields == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return Cache.AddToCache(searchFields);
        }

        [HttpGet("retriveSearchField/{guid}")]
        public MultiAvailSearchRequest GetSearchFields(string guid)
        {
            return (MultiAvailSearchRequest)Cache.GetSearchRequest(guid);
        }
        [HttpPost("hotelSearch")]
        public async Task<HotelList> MultipleItinerary([FromBody]MultiAvailSearchRequest searchFields)
        {
            try
            {
                if (searchFields == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            IHotelServiceFactory hotelFactory = Factory.GetHotelServices("HotelsListing");
            var result = await hotelFactory.GetHotelServiceRSAsync(searchFields);
            HotelList hotelList = (HotelList)result;
            return hotelList;
        }
        [HttpPost("roomSearch")]
        public async Task<SingleAvailItinerary> SingleItinerary([FromBody]HotelInfo hotelInfo)
        {
            try
            {
                if (hotelInfo == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            SingleAvailAdapter multiToSingleAdapter = new SingleAvailAdapter();
            var singleAvail = multiToSingleAdapter.GetSingleAvail(hotelInfo);
            IHotelServiceFactory hotelFactory = Factory.GetHotelServices("RoomListing");
            var result = await hotelFactory.GetHotelServiceRSAsync(singleAvail);
            SingleAvailItinerary singleAvailItinerary = (SingleAvailItinerary)result;
            return singleAvailItinerary;
        }
        [HttpPost("roomPrice")]
        public async Task<RoomPricingResponse> RoomPricing([FromBody]RoomPricingItinerary room)
        {
            try
            {
                if (room == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            RoomPricingItinerary roomPricingItinerary = new RoomPricingItinerary().GetSelectedRoom(room);
            IHotelServiceFactory hotelFactory = Factory.GetHotelServices("RoomPricing");
            var result = await hotelFactory.GetHotelServiceRSAsync(roomPricingItinerary);
            RoomPricingResponse roomPricingResponse = (RoomPricingResponse)result;
            return roomPricingResponse;

        }
        [HttpPost("completePayment")]
        public async Task<CompleteBookingResponse> Booking([FromBody]BookTripRQ bookTripRQ)
        {
            try
            {
                if (bookTripRQ == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            IHotelServiceFactory hotelFactory = Factory.GetHotelServices("TripBookFolder");
            var tripBookResult = await hotelFactory.GetHotelServiceRSAsync(bookTripRQ);
            IHotelServiceFactory factory = Factory.GetHotelServices("CompleteBooking");
            var result = await factory.GetHotelServiceRSAsync(tripBookResult);
            CompleteBookingResponse completeBookingResult = (CompleteBookingResponse)result;
            return completeBookingResult;
        }
    }
}