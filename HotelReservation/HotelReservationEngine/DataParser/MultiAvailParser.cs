using System;
using HotelSearchService;
using System.Collections.Generic;
using HotelEntities;
using Newtonsoft.Json;
using HotelReservationEngine.Constants;
using HotelReservationEngine.HotelMultiAvailItinerary;

namespace Parser
{
    public class MultiAvailParser
    {
        private Dictionary<string, HotelSearchType> _hotelResolver = new Dictionary<string, HotelSearchType>()
            {
            {"PointOfInterest",HotelSearchType.PointOfInterest},
            {"ZipCode", HotelSearchType.ZipCode },
            {"IdList",HotelSearchType.IdList },
            {"Tags",HotelSearchType.Tags },
            {"Address",HotelSearchType.Address },
            {"Airport",HotelSearchType.Airport },
            {"City",HotelSearchType.City },
            {"GeoCode",HotelSearchType.GeoCode },
            {"Hotel", HotelSearchType.GeoCode}
            };
        private Dictionary<string, LocationCodeContext> _locationResolver = new Dictionary<string, LocationCodeContext>()
            {
            {"PointOfInterest",LocationCodeContext.PointOfInterest},
            {"RentalLocation",LocationCodeContext.RentalLocation },
            {"ZipCode", LocationCodeContext.ZipCode },
            {"Address",LocationCodeContext.Address },
            {"Airport",LocationCodeContext.Airport },
            {"City",LocationCodeContext.City },
            {"GeoCode",LocationCodeContext.GeoCode },
            {"Hotel", LocationCodeContext.GeoCode }
            };
        public HotelSearchRQ RequestTranslator(MultiAvailSearchRequest searchRequest)
        {
            HotelSearchRQ listRQ = new HotelSearchRQ();
            listRQ.SessionId = Guid.NewGuid().ToString();
            listRQ.ResultRequested = ResponseType.Complete;
            listRQ.Filters = new AvailabilityFilter[1]
            {
                new AvailabilityFilter()
            {
            ReturnOnlyAvailableItineraries = MultiAvailSearchRequestStaticData._availableItenaries
            }
            };
            GeoAxisCode geoAxis = new GeoAxisCode(searchRequest.Destination.Longitude, searchRequest.Destination.Latitude);
            listRQ.HotelSearchCriterion = new HotelSearchCriterion();
            listRQ.HotelSearchCriterion.MatrixResults = MultiAvailSearchRequestStaticData._matrixResults;
            listRQ.HotelSearchCriterion.MaximumResults = MultiAvailSearchRequestStaticData._maxResults;
            listRQ.HotelSearchCriterion.Pos = new PointOfSale();
            listRQ.HotelSearchCriterion.Pos.PosId = MultiAvailSearchRequestStaticData._defaultPosId;
            listRQ.HotelSearchCriterion.Pos.Requester = GetDefaultRequester();
            listRQ.HotelSearchCriterion.PriceCurrencyCode = MultiAvailSearchRequestStaticData._priceCurrencyCode;
            listRQ.HotelSearchCriterion.Guests = GetGuestDetails(searchRequest.Adult, searchRequest.ChildrenCount);
            listRQ.HotelSearchCriterion.Location = GetLocation(searchRequest.Destination.CityName, searchRequest.Destination.SearchType, geoAxis);
            listRQ.HotelSearchCriterion.NoOfRooms = GetMinimumRoomsRequired(Convert.ToInt32(searchRequest.Adult), Convert.ToInt32(searchRequest.ChildrenCount));
            listRQ.HotelSearchCriterion.ProcessingInfo = new HotelSearchProcessingInfo()
            {
                DisplayOrder = HotelDisplayOrder.ByRelevanceScoreDescending
            };
            listRQ.HotelSearchCriterion.RoomOccupancyTypes = new RoomOccupancyType[1]
            {
                new RoomOccupancyType()
            {
            PaxQuantities = listRQ.HotelSearchCriterion.Guests
            }
            };
            listRQ.HotelSearchCriterion.SearchType = _hotelResolver[searchRequest.Destination.SearchType];
            listRQ.HotelSearchCriterion.StayPeriod = GetStayPeriod(searchRequest.CheckInDate, searchRequest.CheckOutDate);
            listRQ.PagingInfo = new PagingInfo()
            {
                Enabled = true,
                StartNumber = MultiAvailSearchRequestStaticData._pagingInfoStartNumber,
                EndNumber = MultiAvailSearchRequestStaticData._pagingInfoEndNumber,
                TotalRecordsBeforeFiltering = MultiAvailSearchRequestStaticData._totalRecordsBeforeFiltering,
                TotalResults = MultiAvailSearchRequestStaticData._totalResults
            };
            return listRQ;
            }
        private DateTimeSpan GetStayPeriod(DateTime checkInDate, DateTime checkOutDate)
        {
            try
            {
                return new DateTimeSpan()
                {
                    Start = checkInDate,
                    End = checkOutDate,
                };
            }
            catch
            {
                throw;
            }
        }
        private int GetMinimumRoomsRequired(int adultsCount, int childrensCount)
        {
            return (adultsCount / 2 + childrensCount / 2 + 1);
        }
        private HotelSearchService.Location GetLocation(string name, string type, GeoAxisCode geoCode)
        {
            var json = JsonConvert.SerializeObject(geoCode);
            return new HotelSearchService.Location()
            {
                CodeContext = LocationCodeContext.GeoCode,
                Radius = new Distance()
                {
                    Amount = MultiAvailSearchRequestStaticData._searchRadius,
                    From = LocationCodeContext.GeoCode,
                    Unit = DistanceUnit.mi
                },
                GeoCode = JsonConvert.DeserializeObject<GeoCode>(json)
            };
        }

        private PassengerTypeQuantity[] GetGuestDetails(int adultCount, int childCount)
        {

            PassengerTypeQuantity[] passengerTypeQuantity = new PassengerTypeQuantity[2];
            PassengerTypeQuantity adultPassengers = new PassengerTypeQuantity();
            adultPassengers.PassengerType = PassengerType.Adult;
            adultPassengers.Quantity = adultCount;
            PassengerTypeQuantity childPassengers = new PassengerTypeQuantity();
            childPassengers.PassengerType = PassengerType.Child;
            childPassengers.Quantity = childCount;
            childPassengers.Ages = new int[childCount];
            if (childCount == 0)
            {
                childPassengers.Ages = new int[1];
            }
            else
            {
                childPassengers.Ages = new int[childCount];
            }
            for (int i = 0; i < childPassengers.Ages.Length; i++)
            {
                childPassengers.Ages[i] = 12;
            }
            childPassengers.Quantity = childCount;
            passengerTypeQuantity[0] = adultPassengers;
            passengerTypeQuantity[1] = childPassengers;
            return passengerTypeQuantity;
        }

        private Company GetDefaultRequester()
        {
            Company company = new Company();
            Agency agency = new Agency();
            Address address = new Address();
            address.CodeContext = LocationCodeContext.Address;
            address.GmtOffsetMinutes = MultiAvailSearchRequestStaticData._gmtOffsetMin;
            address.Id = MultiAvailSearchRequestStaticData._addressId;
            address.AddressLine1 = MultiAvailSearchRequestStaticData._addressLine1;
            address.AddressLine2 = MultiAvailSearchRequestStaticData._addressLine2;
            City city = new City();
            city.CodeContext = LocationCodeContext.City;
            city.GmtOffsetMinutes = MultiAvailSearchRequestStaticData._gmtOffsetMin;
            city.Id = MultiAvailSearchRequestStaticData._addressId;
            address.City = city;
            agency.AgencyId = 0;
            agency.AgencyName = MultiAvailSearchRequestStaticData._agencyName;
            company.Code = MultiAvailSearchRequestStaticData._companyCode;
            company.CodeContext = CompanyCodeContext.PersonalTravelClient;
            company.DK = MultiAvailSearchRequestStaticData._companyDk;
            company.FullName = MultiAvailSearchRequestStaticData._companyName;
            company.ID = MultiAvailSearchRequestStaticData._companyId;
            return company;
        }

        public MultiAvailItinery ResponseTranslator(HotelSearchRS hotelSearchRS,HotelSearchRQ hotelSearchRQ)
        {
            MultiAvailItinery multiAvailItinery = new MultiAvailItinery();
            List<HotelItinerary> itinerary = new List<HotelItinerary>();
            foreach (var itineraries in hotelSearchRS.Itineraries)
            {
                itinerary.Add(itineraries);
            }
            multiAvailItinery.Itinerary = itinerary;
            multiAvailItinery.SessionId = hotelSearchRS.SessionId;
            multiAvailItinery.hotelSearchCriterion = hotelSearchRQ.HotelSearchCriterion;
            return multiAvailItinery;
        }
    }
}
