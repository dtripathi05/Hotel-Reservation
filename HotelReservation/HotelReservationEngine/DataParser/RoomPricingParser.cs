using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
using TripEngine.Model;
using TripEngineService;
using HotelReservation.Logger;

namespace HotelReservationEngine.DataParser
{
    public class RoomPricingParser
    {
        public TripProductPriceRQ RoomPriceRQParser(RoomPricingItinerary roomPricingItinerary)
        {
            try
            {
                if (roomPricingItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return new TripProductPriceRQ
            {
                SessionId = roomPricingItinerary.SessionId,
                AdditionalInfo = new TripEngineService.StateBag[1] { new TripEngineService.StateBag() { Name = "API_SESSION_ID", Value=roomPricingItinerary.SessionId } },
                TripProduct = new HotelTripProduct
                {
                    HotelSearchCriterion = roomPricingItinerary.Criteria,
                    HotelItinerary = roomPricingItinerary.Itinerary,
                },
                ResultRequested = TripEngineService.ResponseType.Complete,
            };
        }
        public RoomPricingResponse RoomPriceRSParser(TripEngineService.TripProductPriceRS tripProductPriceRS, RoomPricingItinerary roomPricingItinerary)
        {
            try
            {
                if (tripProductPriceRS == null && roomPricingItinerary == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return new RoomPricingResponse
            {
                Product = ((HotelTripProduct)tripProductPriceRS.TripProduct),
                SessionId = tripProductPriceRS.SessionId,
                Criteria = roomPricingItinerary.Criteria
            };
        }
    }
}
