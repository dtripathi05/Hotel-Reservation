using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripEngine.Model
{
    public class BookTripRQ
    {
        private RoomPricingResponse _roomPricingResponse;
        private string _firstName;
        private string _lastName;
        private string _mobileNumber;
        private string _age;
        private string _mailId;
        private string _cardNumber;
        private string _cardHolder;
        private string _mm;
        private string _yy;
        private string _cvv;

        public RoomPricingResponse RoomPricingResponse
        {
            get { return this._roomPricingResponse; }
            set { this._roomPricingResponse = value; }
        }
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        public string MobileNumber
        {
            get { return this._mobileNumber; }
            set { this._mobileNumber = value; }
        }
        public string Age
        {
            get { return this._age; }
            set { this._age = value; }
        }
        public string EmailId
        {
            get { return this._mailId; }
            set { this._mailId = value; }
        }
        public string CardNumber
        {
            get { return this._cardNumber; }
            set { this._cardNumber = value; }
        }
        public string CardHolder
        {
            get { return this._cardHolder; }
            set { this._cardHolder = value; }
        }
        public string Month
        {
            get { return this._mm; }
            set { this._mm = value; }
        }
        public string Year
        {
            get { return this._yy; }
            set { this._yy = value; }
        }
        public string Cvv
        {
            get { return this._cvv; }
            set { this._cvv = value; }
        }
    }
}
