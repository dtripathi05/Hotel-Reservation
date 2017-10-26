using HotelReservation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngine.Model;
using TripEngineService;
namespace HotelReservationEngine.DataParser
{
    public class BookTripParser
    {
        private HotelItinerary _hotelItinerary;
        private HotelSearchCriterion _hotelSearchCriterion;
        private string _gender;
        public TripFolderBookRQ TripFolderBookRQParser(BookTripRQ bookTripRQ)
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
            _hotelItinerary = bookTripRQ.RoomPricingResponse.Product.HotelItinerary;
            _hotelSearchCriterion = bookTripRQ.RoomPricingResponse.Criteria;

            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
            {
                SessionId = bookTripRQ.RoomPricingResponse.SessionId.ToString(),
                ResultRequested = ResponseType.Unknown,
                TripFolder = new TripFolder()
                {
                    Creator = new User()
                    {
                        AdditionalInfo = new StateBag[]
                     {
                        new StateBag(){ Name="AgencyName", Value="WV"},
                        new StateBag(){ Name="CompanyName", Value= "Rovia"},
                        new StateBag(){ Name="UserType", Value="Normal"}
                     },
                        Email = "sbejugam@v-worldventures.com",
                        FirstName = bookTripRQ.FirstName,
                        LastName = bookTripRQ.LastName,
                        MiddleName = "User",
                        Prefix = bookTripRQ.Prefix,
                        Title = bookTripRQ.Prefix,
                        UserId = 169050,
                        UserName = "3285301"
                    },
                    FolderName = $"BookTripFolder{DateTime.Now.Date}",
                    Owner = new User()
                    {
                        AdditionalInfo = new StateBag[]
                     {
                        new StateBag(){ Name="AgencyName", Value="WV"},
                        new StateBag(){ Name="CompanyName", Value= "Rovia"},
                        new StateBag(){ Name="UserType", Value="Normal"}
                     },
                        Email = "sbejugam@v-worldventures.com",
                        FirstName = "Sandbox",
                        LastName = "Test",
                        MiddleName = "User",
                        Prefix = "Mr.",
                        Title = "Mr",
                        UserId = 169050,
                        UserName = "3285301"
                    },
                    Pos = new PointOfSale()
                    {
                        AdditionalInfo = new StateBag[]
                     {
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
                     },
                        PosId = 101,
                        Requester = new Company()
                        {
                            Agency = new Agency()
                            {
                                AgencyAddress = new Address()
                                {
                                    CodeContext = LocationCodeContext.Address,
                                    AddressLine1 = "Test1",
                                    AddressLine2 = "Test2",
                                    ZipCode = "89002"
                                },
                                AgencyName = "WV",
                            },
                            Code = "DTP",
                            CodeContext = CompanyCodeContext.Airline,
                            DK = "3285301P",
                            FullName = "Rovia"
                        },
                    },
                    Type = TripFolderType.Personal,
                    Passengers = new Passenger[]
                 {
                    new Passenger()
                    {
                        Age=Convert.ToInt32(bookTripRQ.Age),
                        BirthDate=new DateTime(1994,12,05),
                        CustomFields=new StateBag[]
                        {
                            new StateBag(){ Name="Boyd Gaming"},
                            new StateBag(){ Name="IsPassportRequired" , Value="false"}
                        },
                        //Email="dtripathi@tavisca.com",
                        //FirstName="Deependra",
                        FirstName=bookTripRQ.FirstName,
                        Email=bookTripRQ.EmailId,
                        Gender=Gender.Male,
                        KnownTravelerNumber="789456",
                        LastName=bookTripRQ.LastName,
                        PassengerType=PassengerType.Adult,
                        PhoneNumber=bookTripRQ.MobileNumber,
                        UserName="rsarda@tavisca.com",
                        Prefix=bookTripRQ.Prefix
                    }
                 },
                    Payments = new CreditCardPayment[]
                 {
                    new CreditCardPayment()
                    {
                        PaymentType=PaymentType.Credit,
                        Amount= bookTripRQ.RoomPricingResponse.Product.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare,
                        Attributes=new StateBag[]
                        {
                            new StateBag() { Name="API_SESSION_ID", Value=bookTripRQ.RoomPricingResponse.SessionId.ToString()},
                            new StateBag(){ Name="PointOfSaleRule"},
                            new StateBag(){ Name="SectorRule"},
                            new StateBag(){ Name="_AttributeRule_Rovia_Username"},
                            new StateBag(){ Name="_AttributeRule_Rovia_Password"},
                        },
                        BillingAddress=new Address()
                        {
                            CodeContext=LocationCodeContext.Address,
                            AddressLine1="E Sunset Rd",
                            AddressLine2="Near Trade Center",
                            City=new City()
                            {
                                CodeContext=LocationCodeContext.City,
                                Name="LAS",
                                Country="US",
                                State="State",
                            },
                            PhoneNumber="123456",
                            ZipCode="123456"
                        } ,
                        CardMake=new CreditCardMake()
                        {
                            Code="VI",
                            Name="VISA"
                        },
                        CardType=CreditCardType.Personal,
                        ExpiryMonthYear=DateTime.Parse("2020-12-01T00:00:00"),
                        IsThreeDAuthorizeRequired=false,
                        NameOnCard="test card",
                        Number="0000000000001111",
                        SecurityCode="123"
                    }
                 },
                    Products = new HotelTripProduct[]
                    {
                      new HotelTripProduct()
                      {
                       Attributes=new StateBag[]
                       {
                           new StateBag{ Name ="API_SESSION_ID", Value=bookTripRQ.RoomPricingResponse.SessionId.ToString()},
                           new StateBag{ Name ="token", Value=""},
                           new StateBag{ Name ="ChargingHoursPriorToCPW", Value="48"},
                           new StateBag{ Name ="IsLoginWhileSearching", Value="Y"},
                           new StateBag{ Name ="IsInsuranceSelected", Value="no"},
                       },
                       IsOnlyLeadPaxInfoRequired=true,
                       Owner=new User()
                       {
                           AdditionalInfo=new StateBag[]
                           {
                               new StateBag(){Name="AgencyName", Value="WV"},
                               new StateBag(){ Name="CompanyName", Value="Rovia"},
                               new StateBag(){ Name="UserType", Value="Normal"}
                           },
                            Email = "sbejugam@v-worldventures.com",
                            FirstName = "Sandbox",
                            LastName = "Test",
                            MiddleName = "User",
                            Prefix = "Mr.",
                            Title = "Mr",
                            UserId = 169050,
                            UserName = "3285301"
                       },
                       PassengerSegments=new PassengerSegment[]
                       {
                           new PassengerSegment()
                           {
                               BookingStatus=TripProductStatus.Planned,
                               PostBookingStatus=PostBookingTripStatus.None,
                               Rph=4
                           }
                       },
                       PaymentBreakups=new PaymentBreakup[]
                       {
                           new PaymentBreakup()
                           {
                               Amount= bookTripRQ.RoomPricingResponse.Product.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare
                           }
                       },
                       PaymentOptions=new PaymentType[]
                       {
                           PaymentType.SoftCash,
                           PaymentType.External,
                           PaymentType.Credit
                       },
                       Rph=0,
                       HotelItinerary=_hotelItinerary,
                       HotelSearchCriterion=_hotelSearchCriterion,
                       RoomOccupancyTypes=new RoomOccupancyType[]
                       {
                           new RoomOccupancyType()
                           {
                               PaxQuantities=new PassengerTypeQuantity[]
                               {
                                   new PassengerTypeQuantity()
                                   {
                                       Ages=new int[] { Convert.ToInt32(bookTripRQ.Age) },
                                       PassengerType=PassengerType.Adult,
                                       Quantity= 1
                                   }
                               }
                           }
                       }
                      }
                    },
                    Status = TripStatus.Planned,
                },
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[] { 0 }
                }
            };
            tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion = _hotelSearchCriterion;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelItinerary = _hotelItinerary;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayAmount = _hotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.Amount;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayCurrency = _hotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.Currency;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = _hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = _hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            var samplerules = new List<HotelCancellationRule>();
            _hotelItinerary.HotelCancellationPolicy = new HotelCancellationPolicy() { CancellationRules = samplerules.ToArray() };
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion.Guests[0].Ages = new int[] { 30 };
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion.RoomOccupancyTypes[0].PaxQuantities[0].Ages = new int[] { 30 };
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion.RoomOccupancyTypes[0].PaxQuantities[0].Quantity = 1;
            ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).CancellationDetails = new CancellationDetails() { AppliedRule = new HotelCancellationRule() };
            var hotelTripProduct = ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0]));
            setDisplayValues(hotelTripProduct);
            return tripFolderBookRQ;
        }
        private void setDisplayValues(HotelTripProduct hotelTripProduct)
        {
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.Amount;
            hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.Amount;
            hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.Currency;
            hotelTripProduct.HotelItinerary.Fare.BaseFare.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.BaseFare.Amount;
            hotelTripProduct.HotelItinerary.Fare.BaseFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.BaseFare.Currency;
            hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.Amount;
            hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.Currency;
            hotelTripProduct.HotelItinerary.Fare.MinDailyRate.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.MinDailyRate.Amount;
            hotelTripProduct.HotelItinerary.Fare.MinDailyRate.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.MinDailyRate.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalCommission.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalCommission.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalCommission.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalCommission.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalDiscount.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalDiscount.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalDiscount.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalDiscount.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalFare.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalFare.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalFare.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalFee.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalFee.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalFee.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalFee.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalTax.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalTax.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalTax.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalTax.Currency;
        }
        public BookTripFolderResponse TripFolderBookRSParser(BookTripRQ bookTripRQ, TripFolderBookRS tripFolderBookRS)
        {
            try
            {
                if (bookTripRQ == null && tripFolderBookRS == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }

            return new BookTripFolderResponse
            {
                SessionId = bookTripRQ.RoomPricingResponse.SessionId,
                TripFolderBookResponse = tripFolderBookRS
            };
        }
    }
}