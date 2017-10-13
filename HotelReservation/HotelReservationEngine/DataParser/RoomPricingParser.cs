using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationEngine.HotelMultiAvailItinerary;
using HotelSearchService;
using TripEngine.Model;
using TripEngineService;

namespace HotelReservationEngine.DataParser
{
    public class RoomPricingParser
    {
        public TripProductPriceRQ RoomPriceRQParser(RoomPricingItinerary roomPricingItinerary)
        {
            return new TripProductPriceRQ
            {
                SessionId = roomPricingItinerary.SessionId,
                TripProduct = new HotelTripProduct
                {
                    HotelSearchCriterion = roomPricingItinerary.Criteria,
                    HotelItinerary = roomPricingItinerary.Itinerary,
                } ,
                ResultRequested=TripEngineService.ResponseType.Complete,
            };
        }
        public RoomPricingResponse RoomPriceRSParser(TripEngineService.TripProductPriceRS tripProductPriceRS, RoomPricingItinerary roomPricingItinerary)
        {
            return new RoomPricingResponse
            {
                Product=((HotelTripProduct)tripProductPriceRS.TripProduct),
                SessionId=tripProductPriceRS.SessionId,
                Criteria= roomPricingItinerary.Criteria
            };
        }
    }
}
