using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEntities
{
    public class Location
    {
        private float _latitude;
        private float _longitude;
        private string _searchType;
        private string _cityName;

        public float Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }

        public float Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }

        public string SearchType
        {
            get { return this._searchType; }
            set { this._searchType = value; }
        }

        public string CityName
        {
            get { return this._cityName; }
            set { this._cityName = value; }
        }

    }
}
