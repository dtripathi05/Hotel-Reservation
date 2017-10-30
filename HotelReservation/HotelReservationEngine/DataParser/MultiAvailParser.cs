using System;
using HotelSearchService;
using System.Collections.Generic;
using Newtonsoft.Json;
using HotelReservationEngine.Constants;
using HotelReservation.Logger;
using HotelReservationEngine.Model;

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
        public HotelSearchRQ MultiAvailRQParser(HotelSearchField searchRequest)
        {
            try
            {
                if (searchRequest == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            HotelSearchRQ listRQ = new HotelSearchRQ();
            listRQ.SessionId = Guid.NewGuid().ToString();
            listRQ.ResultRequested = ResponseType.Complete;
            listRQ.AdditionalInfo = new StateBag[] { new StateBag() { Name = "API_SESSION_ID", Value = listRQ.SessionId } };
            listRQ.Filters = new AvailabilityFilter[1]
            {
                new AvailabilityFilter()
            {
            ReturnOnlyAvailableItineraries = MultiAvailSearchRequestStaticData._availableItenaries
            }
            };
            GeoAxisCode geoAxis = new GeoAxisCode(searchRequest.Destination.Longitude, searchRequest.Destination.Latitude);
            listRQ.HotelSearchCriterion = new HotelSearchCriterion();
            listRQ.HotelSearchCriterion.Attributes = new StateBag[6]
            {
                new StateBag() { Name = "API_SESSION_ID", Value = listRQ.SessionId },
                new StateBag(){ Name="FareType",Value="BaseFare"},
                new StateBag(){ Name="ResetFiltersIfNoResults",Value="true"},
                new StateBag(){ Name="ReturnRestrictedRelevanceProperties",Value="true"},
                new StateBag(){ Name="MaxHideawayRelevancePropertiesToDisplay",Value="5"},
                new StateBag(){ Name="MaxHotelRelevancePropertiesToDisplay",Value="10"}
            };
            listRQ.HotelSearchCriterion.MatrixResults = MultiAvailSearchRequestStaticData._matrixResults;
            listRQ.HotelSearchCriterion.MaximumResults = MultiAvailSearchRequestStaticData._maxResults;
            listRQ.HotelSearchCriterion.Pos = new PointOfSale();
            listRQ.HotelSearchCriterion.Pos.AdditionalInfo = new StateBag[12]
            {
                new StateBag() { Name = "API_SESSION_ID", Value = listRQ.SessionId },
                new StateBag() { Name = "IPAddress", Value = "127.0.0.1" },
                new StateBag() { Name = "DealerUrl", Value = "localhost" },
                new StateBag() { Name = "SiteUrl", Value = "ota" },
                new StateBag() { Name = "AccountId", Value = "169050" },
                new StateBag() { Name = "UserId", Value = "3285301" },
                new StateBag() { Name = "CountryName", Value = "United States" },
                new StateBag() { Name = "CountryCode", Value = "US" },
                new StateBag() { Name = "UserProfileCountryCode", Value = "US" },
                new StateBag() { Name = "CustomerType", Value = "DTP" },
                new StateBag() { Name = "DKCommissionIdentifier", Value = "3285301P" },
                new StateBag() { Name = "MemberSignUpDate", Value = "Tue, 04 Jan 2011" }
            };
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
                Enabled = false,
                //StartNumber = MultiAvailSearchRequestStaticData._pagingInfoStartNumber,
                //EndNumber = MultiAvailSearchRequestStaticData._pagingInfoEndNumber,
                //TotalRecordsBeforeFiltering = MultiAvailSearchRequestStaticData._totalRecordsBeforeFiltering,
                //TotalResults = MultiAvailSearchRequestStaticData._totalResults
            };
            return listRQ;
        }
        private DateTimeSpan GetStayPeriod(DateTime checkInDate, DateTime checkOutDate)
        {
            DateTimeSpan dateTimeSpan = new DateTimeSpan();
            try
            {
                dateTimeSpan.Start = checkInDate;
                dateTimeSpan.End = checkOutDate;
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return dateTimeSpan;
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

            PassengerTypeQuantity[] passengerTypeQuantity = new PassengerTypeQuantity[1];
            PassengerTypeQuantity adultPassengers = new PassengerTypeQuantity();
            adultPassengers.PassengerType = PassengerType.Adult;
            adultPassengers.Quantity = adultCount;
            passengerTypeQuantity[0] = adultPassengers;
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
        public HotelList MultiAvailRSParser(HotelSearchRS hotelSearchRS, HotelSearchRQ hotelSearchRQ)
        {
            try
            {
                if (hotelSearchRS == null && hotelSearchRQ == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }

            List<HotelItinerary> itinerary = new List<HotelItinerary>();
            foreach (var itineraries in hotelSearchRS.Itineraries)
            {
                itinerary.Add(itineraries);
            }
            MultiAvailItinerary multiAvailItinerary = new MultiAvailItinerary()
            {
                Itinerary = itinerary,
                SessionId = hotelSearchRS.SessionId,
                HotelSearchCriterion = hotelSearchRQ.HotelSearchCriterion
            };
            var cache = Cache.AddToCache(multiAvailItinerary);
            // return multiAvailItinerary;
            List<HotelInfo> hotelInfo = new List<HotelInfo>();
            try
            {
                foreach (var info in itinerary)
                {
                    //if (info.HotelFareSource.Name == "HotelBeds Test" || info.HotelFareSource.Name == "TouricoTGSTest")
                    {
                        string imageUrl = "";
                        for (int i = 0; i < info.HotelProperty.MediaContent.Length; i++)
                        {
                            if (info.HotelProperty.MediaContent[i].Url != null)
                            {
                                imageUrl = info.HotelProperty.MediaContent[i].Url.ToString();
                                break;
                            }
                        }
                        HotelInfo hotel = new HotelInfo()
                        {
                            GuidId = cache,
                            Address = info.HotelProperty.Address.CompleteAddress,
                            ImgUrl = imageUrl,
                            Name = info.HotelProperty.Name,
                            Rating = info.HotelProperty.HotelRating.Rating,
                            HotelId = info.HotelProperty.Id,
                            SessionId = hotelSearchRS.SessionId,
                            Supplier = info.HotelFareSource.Name,
                            BasePrice=info.Fare.BaseFare.Amount,
                            CurrencyCode=info.Fare.BaseFare.Currency,
                            HotelDetails=info.HotelProperty.Descriptions[0].Description
                        };
                        hotelInfo.Add(hotel);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            var result = new HotelList() { Hotels = hotelInfo };
            return result;
        }
    }
}