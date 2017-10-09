using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearchService;
namespace HotelReservationEngine.DataParser
{
    public class SingleAvailParser
    {
        public HotelRoomAvailRQ GetHotelRooms()
        {
            return new HotelRoomAvailRQ()
            {
                ResultRequested = ResponseType.Unknown,
                SessionId = Guid.NewGuid().ToString(),
                HotelSearchCriterion = new HotelSearchCriterion()
                {
                    Attributes = new StateBag[]
                    {
                        new StateBag
                        {
                            Name="API_SESSION_ID",
                            Value="ca5afc64-a172-4e5b-bb2e-4f3ae2963bd9"
                        },
                        new StateBag
                        {
                            Name="FareType",
                            Value="basefare"
                        }
                    },
                    MatrixResults = true,
                    MaximumResults = 1200,
                    Pos = new PointOfSale
                    {
                        AdditionalInfo = new StateBag[]
                        {
                            new StateBag
                            {
                                Name="IPAddress",
                                Value="172.16.14.79"
                            },
                            new StateBag
                            {
                                Name="DealerUrl",
                                Value="portal.dev-rovia.com"
                            },
                            new StateBag
                            {
                                Name="SiteUrl",
                                Value="ota"
                            },
                            new StateBag
                            {
                                Name="AccountId",
                                Value="169050"
                            },
                            new StateBag
                            {
                                Name="UserId",
                                Value="3285301"
                            },
                            new StateBag
                            {
                                Name="CountryName",
                                Value="United States"
                            },
                            new StateBag
                            {

                                Name ="CountryCode",
                                Value="US"
                            },
                            new StateBag
                            {
                                Name="UserProfileCountryCode",
                                Value="US"
                            },
                            new StateBag
                            {
                                Name="CustomerType",
                                Value="DTP"
                            },
                            new StateBag
                            {
                                Name="DKCommissionIdentifier",
                                Value="3285301P"
                            },
                            new StateBag
                            {
                                Name="MemberSignUpDate",
                                Value="Tue, 04 Jan 2011"
                            }
                        },
                        PosId = 101,
                        Requester = new Company
                        {
                            Agency = new Agency
                            {
                                AgencyId = 0,
                                AgencyName = "WV"
                            },
                            Code = "DTP",
                            CodeContext = CompanyCodeContext.PersonalTravelClient,
                            DK = "3285301P",
                            FullName = "Rovia",
                            ID = 0
                        }
                    },
                    PriceCurrencyCode = "USD",
                    Guests = new PassengerTypeQuantity[]
                    {
                        new PassengerTypeQuantity
                        {
                        Ages = new int[]{30,30 },
                        PassengerType = PassengerType.Adult,
                        Quantity = 2
                        }
                    },
                    IsReturnRooms = false,
                    Location = new Location
                    {
                        CodeContext = LocationCodeContext.City,
                        GeoCode = new GeoCode
                        {
                            Latitude = 36.11093f,
                            Longitude = -115.16935f
                        },
                        GmtOffsetMinutes = 0,
                        Id = 0,
                        Name = "Las Vegas",
                        Radius = new Distance
                        {
                            Amount = 20,
                            From = LocationCodeContext.City,
                            Unit = DistanceUnit.mi
                        },
                    },
                    NoOfRooms = 1,
                    ProcessingInfo = new HotelSearchProcessingInfo
                    {
                        DisplayOrder = HotelDisplayOrder.ByPriceLowToHigh
                    },
                    RoomOccupancyTypes = new RoomOccupancyType[]
                    {
                    new RoomOccupancyType()
                    {
                        PaxQuantities = new PassengerTypeQuantity[]
                        {
                            new PassengerTypeQuantity()
                            {
                                Ages = new int[]
                                {
                                    30,
                                    30
                                },
                                PassengerType = PassengerType.Adult,
                                Quantity = 2
                            }
                        }
                    }
                    },
                    SearchType = HotelSearchType.City,
                    StayPeriod = new DateTimeSpan()
                    {
                        Duration = 0,
                        End = new DateTime(2017, 10, 26),
                        Start = new DateTime(2017, 10, 25)
                    },
                    TravelPreference = new HotelSearchPreference
                    {
                        MaxNumberOfBedRooms = 0,
                        MaxOccupancy = 0,
                        MinNumberOfBedRooms = 0,
                        MinOccupancy = 0
                    }
                },
                Itinerary = new HotelItinerary()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    ItineraryStatus = ItineraryStatusType.Unbooked,
                    Rph = 0,
                    AllPaxDetailsRequired = false,
                    GuaranteeRequired = false,
                    HotelProperty = new HotelProperty()
                    {
                        Id = 88359
                    },
                    ShippingAddressRequired = false
                }
            };
        }
    }
}
