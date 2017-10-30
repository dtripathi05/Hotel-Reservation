using HotelReservation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationEngine.Model
{
    public class HotelInfo : IItinerary
    {
        private string _sessionId;
        private string _imgUrl;
        private string _name;
        private string _address;
        private float _rating;
        private string _guidId;
        private int _hotelId;
        private string _supplier;
        private decimal _basePrice;
        private string _currencyCode;
        private string _hotelDetails;

        public string SessionId
        {
            get { return this._sessionId; }
            set { this._sessionId = value; }
        }
        public string ImgUrl
        {
            get { return this._imgUrl; }
            set { this._imgUrl = value; }
        }
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        public float Rating
        {
            get { return this._rating; }
            set { this._rating = value; }
        }
        public string GuidId
        {
            get { return this._guidId; }
            set { this._guidId = value; }
        }
        public int HotelId
        {
            get { return this._hotelId; }
            set { this._hotelId = value; }
        }
        public string Supplier
        {
            get { return this._supplier; }
            set { this._supplier = value; }
        }
        public decimal BasePrice
        {
            get { return this._basePrice; }
            set { this._basePrice = value; }
        }
        public string CurrencyCode
        {
            get { return this._currencyCode; }
            set { this._currencyCode = value; }
        }
        public string HotelDetails
        {
            get { return this._hotelDetails; }
            set { this._hotelDetails = value; }
        }
    }
}
