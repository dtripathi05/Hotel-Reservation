using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationEngine.Model;
using HotelReservationEngine.Adapter;
using Newtonsoft.Json;
using TripEngine.Model;
using TripEngineService;
using HotelReservationEngine.DataParser;
using HotelReservation.Contract;
using System;
using HotelReservation.Logger;

namespace HotelReservation.Web.Controllers
{
    [Route("api/hotel")]
    public class HotelController : Controller
    {
        [HttpPost("searchField")]
        public string HotelSearchFields([FromBody]HotelSearchField searchFields)
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
                Log.ExceptionLogger(ex);
            }
            return Cache.AddToCache(searchFields);
        }

        [HttpGet("retriveSearchField/{guid}")]
        public HotelSearchField GetSearchFields(string guid)
        {
            return (HotelSearchField)Cache.GetSearchRequest(guid);
        }

        [HttpPost("hotelSearch")]
        public async Task<HotelList> MultipleItinerary([FromBody]HotelSearchField searchFields)
        {
            HotelList hotelList = null;
            try
            {
                if (searchFields == null)
                {
                    throw new NullReferenceException();
                }
                IHotelServiceFactory hotelFactory = Factory.GetHotelServices("HotelsListing");
                hotelList = (HotelList)await hotelFactory.GetHotelServiceRSAsync(searchFields);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            return hotelList;
        }

        [HttpPost("roomSearch")]
        public async Task<SingleAvailItinerary> SingleItinerary([FromBody]HotelInfo hotelInfo)
        {
            SingleAvailItinerary singleAvailItinerary = null;
            try
            {
                if (hotelInfo == null)
                {
                    throw new NullReferenceException();
                }
                SingleAvailAdapter singleAvailAdapter = new SingleAvailAdapter();
                var singleAvail = singleAvailAdapter.GetSingleAvail(hotelInfo);
                IHotelServiceFactory hotelFactory = Factory.GetHotelServices("RoomListing");
                singleAvailItinerary = (SingleAvailItinerary)await hotelFactory.GetHotelServiceRSAsync(singleAvail);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            return singleAvailItinerary;
        }

        [HttpPost("roomPrice")]
        public async Task<RoomPricingResponse> RoomPricing([FromBody]RoomPricingItinerary pricingItinerary)
        {
            RoomPricingResponse roomPricingResponse = null;
            try
            {
                if (pricingItinerary == null)
                {
                    throw new NullReferenceException();
                }
                RoomPricingItinerary roomPricingItinerary = new RoomPricingItinerary().GetSelectedRoom(pricingItinerary);
                IHotelServiceFactory hotelFactory = Factory.GetHotelServices("RoomPricing");
                roomPricingResponse = (RoomPricingResponse)await hotelFactory.GetHotelServiceRSAsync(roomPricingItinerary);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            return roomPricingResponse;
        }

        [HttpPost("completePayment")]
        public async Task<CompleteBookingResponse> Booking([FromBody]BookTripRQ bookTripRQ)
        {
            CompleteBookingResponse completeBookingResult = null;
            try
            {
                if (bookTripRQ == null)
                {
                    throw new NullReferenceException();
                }
                IHotelServiceFactory hotelFactory = Factory.GetHotelServices("TripBookFolder");
                var tripBookResult = await hotelFactory.GetHotelServiceRSAsync(bookTripRQ);
                IHotelServiceFactory factory = Factory.GetHotelServices("CompleteBooking");
                completeBookingResult = (CompleteBookingResponse)await factory.GetHotelServiceRSAsync(tripBookResult);
            }
            catch (Exception ex)
            {
                Log.ExceptionLogger(ex);
            }
            return completeBookingResult;
        }
    }
}