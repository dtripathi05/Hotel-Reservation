using HotelReservation.Logger;
using System;
using System.Threading.Tasks;
using TripEngine.Model;
using TripEngineService;

namespace HotelReservationEngine.DataParser
{
    public class CompleteBookingParser
    {
        public CompleteBookingRQ CompleteBookingRQParser(BookTripFolderResponse bookTripFolderResponse)
        {
            try
            {
                if (bookTripFolderResponse == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                Log.ExcpLogger(ex);
            }
            CompleteBookingRQ completeBookingRQ = new CompleteBookingRQ()
            {
                ResultRequested = ResponseType.Unknown,
                SessionId = bookTripFolderResponse.SessionId,
                ExternalPayment = new CreditCardPayment(),
                TripFolderId = bookTripFolderResponse.TripFolderBookResponse.TripFolder.Id
            };
            completeBookingRQ.ExternalPayment.Attributes = new StateBag[]
               {
               new StateBag()
               {
                Name = "PointOfSaleRule",
                Value = "true"
               },
               new StateBag()
               {
                Name = "SectorRule",
                Value = "true"
               },
               new StateBag()
               {
                Name = "_AttributeRule_Rovia_Username",
                Value = "true"
               },
               new StateBag()
               {
               Name = "_AttributeRule_Rovia_Password",
               Value = "true"
               },
               new StateBag()
               {
               Name = "AmountToAuthorize",
               Value = "1"
               },
               new StateBag()
               {
               Name = "IsDefaultDollerAuthorization",
               Value = "Y"
               },
               new StateBag()
               {
               Name = "PaymentStatus",
               Value = "Authorization successful"
               },
               new StateBag()
               {
               Name = "AuthorizationTransactionId",
               Value = "daa73e68-f46f-4035-94d5-df80a77c1c62"
               },
               new StateBag()
               {
               Name = "ProviderAuthorizationTransactionId",
               Value = "DEF127D6-9257-43D3-AA45-92E53AA59CAE"
               },
               new StateBag()
               {
               Name = "PointOfSaleRule",
               Value = "true"
               },
               new StateBag()
               {
               Name = "SectorRule",
               Value = "true"
               },
               new StateBag()
               {
               Name = "_AttributeRule_Rovia_Username",
               Value = "true"
               },
               new StateBag()
               {
               Name = "_AttributeRule_Rovia_Password",
               Value = "true"
               }

            };
            return completeBookingRQ;
        }

        public CompleteBookingResponse CompleteBookingResponseParser(CompleteBookingRS completeBookingRS)
        {
            return new CompleteBookingResponse
            {
                ConfirmationNumber = completeBookingRS.TripFolder.Products[0].PassengerSegments[0].VendorConfirmationNumber,
                AmountPaid=completeBookingRS.TripFolder.Payments[0].Amount.Amount,
                CheckIn=completeBookingRS.TripFolder.StartDate,
                CheckOut=completeBookingRS.TripFolder.EndDate,
            };
        }
    }
}

