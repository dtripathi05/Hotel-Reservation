using HotelReservation.Contract;
using System;

namespace HotelEntities
{
    public class MultiAvailSearchRequest:IItinerary
    {
        private Location _pickedHotel;
        private DateTime _checkInDate;
        private DateTime _checkOutDate;
        private int _rooms;
        private int _adult;
        private int _children;

        public Location Destination
        {
            get { return this._pickedHotel; }
            set { this._pickedHotel = value; }
        }

        public DateTime CheckInDate
        {
            get { return this._checkInDate; }
            set { this._checkInDate = value; }
        }
        public DateTime CheckOutDate
        {
            get { return this._checkOutDate; }
            set { this._checkOutDate = value; }
        }
        public int Rooms
        {
            get { return this._rooms; }
            set { this._rooms = value; }
        }
        public int Adult
        {
            get { return this._adult; }
            set { this._adult = value; }
        }
        public int ChildrenCount
        {
            get { return this._children; }
            set { this._children = value; }
        }
    }
}
