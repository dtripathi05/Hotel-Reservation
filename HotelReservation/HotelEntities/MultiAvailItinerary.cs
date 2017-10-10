using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class MultiAvailItinerary
    {
        private string _name;
        private string _address;
        private GeoAxisCode _geoCode;
        private string _imageUrl;
        private decimal _minPrice;

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

        public GeoAxisCode GeoCode
        {
            get { return this._geoCode; }
            set { this._geoCode = value; }
        }

        public string ImageUrl
        {
            get { return this._imageUrl; }
            set { this._imageUrl = value; }
        }

        public decimal MinPrice
        {
            get { return this._minPrice; }
            set { this._minPrice = value; }
        }
    }
}
