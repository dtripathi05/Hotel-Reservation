using System;

namespace HotelEntities
{
    public class GeoAxisCode
    {
        private float _longitude;
        private float _latitude;


        public GeoAxisCode(float longitude, float latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

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
    }
}
