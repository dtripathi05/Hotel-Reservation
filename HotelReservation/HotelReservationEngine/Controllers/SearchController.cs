﻿using System.Collections.Generic;
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

    [Route("api/search")]
    public class SearchController : Controller
    {
        private static Dictionary<string, MultiAvailSearchRequest> _searchStore = new Dictionary<string, MultiAvailSearchRequest>();

        [HttpPost("newRequest")]
        public string NewRequest([FromBody]MultiAvailSearchRequest searchFields)
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

        [HttpGet("retriveRequest/{guid}")]
        public MultiAvailSearchRequest GetSearchFields(string guid)
        {
            return (MultiAvailSearchRequest)Cache.GetSearchRequest(guid);
        }
        [HttpPost("hotel")]
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
            IHotelFactory hotelFactory = Factory.GetHotelServices("HotelsListing");
            var result = await hotelFactory.SearchAsync(searchFields);
            HotelList hotelList = (HotelList)result;
            return hotelList;
        }
        [HttpPost("room")]
        //public async Task<SingleAvailItinerary> SingleItinerary([FromBody]SingleAvailItinerary hotelItinerary)
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
            IHotelFactory hotelFactory = Factory.GetHotelServices("RoomListing");
            var result = await hotelFactory.SearchAsync(singleAvail);
            SingleAvailItinerary singleAvailItinerary = (SingleAvailItinerary)result;
            return singleAvailItinerary;
        }
        [HttpPost("roomPrice")]
        //public async Task<RoomPricingResponse> RoomPricing([FromBody]RoomInfo room)
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
            // SingleAvailItinerary res = (SingleAvailItinerary)Cache.GetSearchRequest(room.GuidId);
            //PricingItineraryAdapter roomPricing = new PricingItineraryAdapter();
            //RoomPricingItinerary pricingItinerary = roomPricing.GetRoomPricing(room);
            //RoomPricingItinerary roomPricingItinerary = new RoomPricingItinerary().GetSelectedRoom(pricingItinerary,room.RoomName);
            RoomPricingItinerary roomPricingItinerary = new RoomPricingItinerary().GetSelectedRoom(room);
            IHotelFactory hotelFactory = Factory.GetHotelServices("RoomPricing");
            var result = await hotelFactory.SearchAsync(roomPricingItinerary);
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
            IHotelFactory hotelFactory = Factory.GetHotelServices("TripBookFolder");
            var tripBookResult = await hotelFactory.SearchAsync(bookTripRQ);
            IHotelFactory factory = Factory.GetHotelServices("CompleteBooking");
            var result = await factory.SearchAsync(tripBookResult);
            CompleteBookingResponse completeBookingResult = (CompleteBookingResponse)result;
            return completeBookingResult;
        }
    }
}