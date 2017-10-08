using System;
using HotelSearchService;
using System.Collections.Generic;
using HotelEntities;
using Newtonsoft.Json;
using Parser;

namespace Parser
{
    public class DataParser
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
        public HotelSearchRQ RequestTranslator(SearchRequest searchRequest)
        {
            HotelSearchRQ listRQ = new HotelSearchRQ();
            listRQ.SessionId = Guid.NewGuid().ToString();
            listRQ.ResultRequested = ResponseType.Complete;
            listRQ.Filters = new AvailabilityFilter[1]
            {
                new AvailabilityFilter()
            {
            ReturnOnlyAvailableItineraries = SearchRequestStaticData._availableItenaries
            }
            };
            GeoAxisCode geoAxis = new GeoAxisCode(searchRequest.Destination.Longitude, searchRequest.Destination.Latitude);
            listRQ.HotelSearchCriterion = new HotelSearchCriterion();
            listRQ.HotelSearchCriterion.MatrixResults = SearchRequestStaticData._matrixResults;
            listRQ.HotelSearchCriterion.MaximumResults = SearchRequestStaticData._maxResults;
            listRQ.HotelSearchCriterion.Pos = new PointOfSale();
            listRQ.HotelSearchCriterion.Pos.PosId = SearchRequestStaticData._defaultPosId;
            listRQ.HotelSearchCriterion.Pos.Requester = GetDefaultRequester();
            listRQ.HotelSearchCriterion.PriceCurrencyCode = SearchRequestStaticData._priceCurrencyCode;
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
                StartNumber = SearchRequestStaticData._pagingInfoStartNumber,
                EndNumber = SearchRequestStaticData._pagingInfoEndNumber,
                TotalRecordsBeforeFiltering = SearchRequestStaticData._totalRecordsBeforeFiltering,
                TotalResults = SearchRequestStaticData._totalResults
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
                    Amount = SearchRequestStaticData._searchRadius,
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
            address.GmtOffsetMinutes = SearchRequestStaticData._gmtOffsetMin;
            address.Id = SearchRequestStaticData._addressId;
            address.AddressLine1 = SearchRequestStaticData._addressLine1;
            address.AddressLine2 = SearchRequestStaticData._addressLine2;
            City city = new City();
            city.CodeContext = LocationCodeContext.City;
            city.GmtOffsetMinutes = SearchRequestStaticData._gmtOffsetMin;
            city.Id = SearchRequestStaticData._addressId;
            address.City = city;
            agency.AgencyId = 0;
            agency.AgencyName = SearchRequestStaticData._agencyName;
            company.Code = SearchRequestStaticData._companyCode;
            company.CodeContext = CompanyCodeContext.PersonalTravelClient;
            company.DK = SearchRequestStaticData._companyDk;
            company.FullName = SearchRequestStaticData._companyName;
            company.ID = SearchRequestStaticData._companyId;
            return company;
        }

        public SearchResponse ResponseTranslator(HotelSearchRS hotelSearchRS)
        {
            SearchResponse parsedRes = new SearchResponse();
            List<Itinerary> listing = new List<Itinerary>();
            foreach (HotelItinerary itinerary in hotelSearchRS.Itineraries)
            {
                Itinerary newItinerary = new Itinerary();
                newItinerary.Address = itinerary.HotelProperty.Address.CompleteAddress;
                newItinerary.Name = itinerary.HotelProperty.Name;
                newItinerary.MinPrice = itinerary.Fare.BaseFare.Amount;
                newItinerary.GeoCode = JsonConvert.DeserializeObject<GeoAxisCode>(JsonConvert.SerializeObject(itinerary.HotelProperty.GeoCode));
                foreach (Media media in itinerary.HotelProperty.MediaContent)
                {
                    if (media.Type == MediaType.Photo)
                    {
                        newItinerary.ImageUrl = media.Url;
                        break;
                    }
                }
                listing.Add(newItinerary);
            }
            parsedRes.HotelResults = listing.ToArray();
            parsedRes.SessionId = hotelSearchRS.SessionId;
            return parsedRes;
        }
    }
}
