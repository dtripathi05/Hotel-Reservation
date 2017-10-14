var room;
var roomsPrice;
$(document).ready(function () {

    room = sessionStorage.getItem("roomPrice");
    roomsPrice = JSON.parse(room);

    var roomDescription = [];

    roomDescription.push({

        totalPrice: roomsPrice.product.hotelItinerary.rooms[0].displayRoomRate.totalFare.amount,
        bedtype: roomsPrice.product.hotelItinerary.rooms[0].bedType,
        roomName: roomsPrice.product.hotelItinerary.rooms[0].roomName,
        guestCount: roomsPrice.product.hotelItinerary.rooms[0].guestCount,
        checkin: roomsPrice.product.hotelItinerary.rooms[0].stayPeriod.start,
        checkout: roomsPrice.product.hotelItinerary.rooms[0].stayPeriod.end,
        address: roomsPrice.product.hotelItinerary.hotelProperty.address.completeAddress

    });

});
