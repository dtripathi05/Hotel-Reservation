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
        public TripFolderBookRQ tripFolderBookRQParser(BookTripRQ bookTripRQ)
        {
            return new TripFolderBookRQ
            {
                SessionId = bookTripRQ.RoomPricingResponse.SessionId,
                TripFolder = new TripFolder() {
                    Products = new TripProduct[]
                    {
                       bookTripRQ.RoomPricingResponse.Product,
                    },
                    Creator = new User
                    {
                        Email = bookTripRQ.EmailId,
                        FirstName = bookTripRQ.FirstName,
                        LastName = bookTripRQ.LastName,
                        UserName = bookTripRQ.FirstName + Guid.NewGuid().ToString(),

                    },
                    //FolderName=
                    LastModifiedDate = new DateTime(),
                    Id = Guid.NewGuid(),
                    Owner=new User
                    {
                        AdditionalInfo = new StateBag[]
                        {
                            new StateBag()
                            {
                                Name = "AgencyName",
                                Value = "WV"
                            },
                            new StateBag()
                            {
                                Name = "CompanyName",
                                Value = "Rovia"
                            },
                            new StateBag()
                            {
                                Name = "UserType",
                                Value = "Normal"
                            },
                        },
                        Email=bookTripRQ.EmailId,
                        FirstName=bookTripRQ.FirstName,
                        LastName=bookTripRQ.LastName,
                        //UserId=
                        //UserName
                    },
                    Pos=new PointOfSale
                    {
                        PosId = 101,
                        Requester = new Company()
                        {
                            DK = "200000D",
                            ID = 0,
                            CodeContext = CompanyCodeContext.HotelChain,
                        }
                    },
                    Type =TripFolderType.Personal,
                    Passengers=new Passenger[]
                    {
                        new Passenger
                        {
                            Age = 27,
                            BirthDate = new DateTime(1990,03,03),
                            Email = "shrikhande@tavisca.com",
                            FirstName = "Shweta",
                            Gender = Gender.Male,
                            LastName = "Shrikhande",
                            PassengerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            PassengerType = PassengerType.Adult,
                            PhoneNumber = "123456789",
                            Rph = 0,
                            UserId = 0,
                            UserName = "sshrikhande@tavisca.com"
                        }
                    },
                    Payments=new CreditCardPayment[]
                    {
                        new CreditCardPayment
                        {
                            CardMake=new CreditCardMake
                            {
                                 Code = "VI",
                                Name = "Visa"
                            },
                             CardType = CreditCardType.Personal,
                            ExpiryMonthYear = new DateTime(2019, 01, 01),
                            NameOnCard = "Saurabh Cache",
                            IsThreeDAuthorizeRequired = false,
                            Number = "0000000000001111",
                            SecurityCode = "123",
                            //Amount =
                            Amount= new Money()
                            {
                                Amount = 200.34M,
                                Currency = "USD",
                                DisplayAmount = 200.34M,
                                DisplayCurrency = "USD"
                            },
                            BillingAddress = new Address()
                            {
                                CodeContext = LocationCodeContext.Address,
                                AddressLine1 = "5100 Tennyson Parkway",
                                AddressLine2 = "dsv effs",
                                PhoneNumber = "972-805-5200",
                                ZipCode = "75024",
                                City = new City()
                                {
                                    Code = "PLN",
                                    CodeContext = LocationCodeContext.City,
                                    Name = "Plano",
                                    Country = "US",
                                    State = "TX"

                                }
                            }
                        }
                    }
                },
                ResultRequested=ResponseType.Unknown
            };
        }
    }
}
