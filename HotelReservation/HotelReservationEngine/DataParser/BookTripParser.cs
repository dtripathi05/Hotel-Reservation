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
        private string _tripFolderName;
        private int _age;
        private Money _amount;
        private string _sessionId;
        private HotelItinerary _hotelItinerary;
        private HotelSearchCriterion _hotelSearchCriterion;
        private int[] _ages;
        private int _qty;
        private decimal _fareToAuthorise;
        private BookTripRQ _bookTripRQ;

        public BookTripParser(BookTripRQ bookTripRQ)
        {
            _bookTripRQ = bookTripRQ;
            _hotelItinerary = bookTripRQ.RoomPricingResponse.Product.HotelItinerary;
            _age = Convert.ToInt32(bookTripRQ.Age);
            _hotelSearchCriterion = bookTripRQ.RoomPricingResponse.Criteria;
            _sessionId = bookTripRQ.RoomPricingResponse.SessionId.ToString();
            _tripFolderName = $"TripFolder{DateTime.Now.Date}";
            _amount = bookTripRQ.RoomPricingResponse.Product.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare;
            _ages = new int[] { _age };
            _qty = 1;
            _fareToAuthorise = _hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
        }

        public TripFolderBookRQ TripFolderBookRQ => new TripFolderBookRQ()
        {
            SessionId = _sessionId,
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
                    FirstName = "Sandbox",
                    LastName = "Test",
                    MiddleName = "User",
                    Prefix = "Mr.",
                    Title = "Mr",
                    UserId = 169050,
                    UserName = "3285301"
                },
                FolderName = _tripFolderName,
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
                        Age=_age,
                        BirthDate=new DateTime(1994,12,05),
                        CustomFields=new StateBag[]
                        {
                            new StateBag(){ Name="Boyd Gaming"},
                            new StateBag(){ Name="IsPassportRequired" , Value="false"}
                        },
                        Email="rsarda@tavisca.com",
                        FirstName="Sandbox",
                        Gender=Gender.Male,
                        KnownTravelerNumber="789456",
                        LastName="Test",
                        PassengerType=PassengerType.Adult,
                        PhoneNumber="1111111111",
                        UserName="rsarda@tavisca.com"
                    }
                },
                Payments = new CreditCardPayment[]
                {
                    new CreditCardPayment()
                    {
                        PaymentType=PaymentType.Credit,
                        Amount=_amount,
                        Attributes=new StateBag[]
                        {
                            new StateBag() { Name="API_SESSION_ID", Value=_sessionId},
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
                Products = /*new HotelTripProduct[] { _bookTripRQ.RoomPricingResponse.Product },*/
                new HotelTripProduct[]
                {
                   new HotelTripProduct()
                   {
                       Attributes=new StateBag[]
                       {
                           new StateBag{ Name ="API_SESSION_ID", Value=_sessionId},
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
                               Amount=_amount
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
                                       Ages=_ages,
                                       PassengerType=PassengerType.Adult,
                                       Quantity=_qty
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
        public async Task<TripFolderBookRS> GetTripFolderBookRS(TripFolderBookRQ tripFolderBookRQ)
        {
            TripFolderBookRS response=null;
            try
            {
                tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
                ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion = _hotelSearchCriterion;
                ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelItinerary = _hotelItinerary;
                //if (_hotelItinerary.HotelCancellationPolicy == null)
                var samplerules = new List<HotelCancellationRule>();
                    _hotelItinerary.HotelCancellationPolicy = new HotelCancellationPolicy() {CancellationRules= samplerules.ToArray() };
                TripsEngineClient tripsEngineClient = new TripsEngineClient();
                ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion.Guests[0].Ages = new int[] { 30 };
                ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion.RoomOccupancyTypes[0].PaxQuantities[0].Ages = new int[] { 30 };
                ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).HotelSearchCriterion.RoomOccupancyTypes[0].PaxQuantities[0].Quantity = 1;
                ((HotelTripProduct)(tripFolderBookRQ.TripFolder.Products[0])).CancellationDetails = new CancellationDetails() { AppliedRule=new HotelCancellationRule()};
                //TripFolderBookRS response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
                response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
                
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            return response;
        }
    }
}