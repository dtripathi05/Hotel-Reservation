var room;
var roomsPrice;
$(document).ready(function () {

    room = sessionStorage.getItem("roomPrice");
    roomsPrice = JSON.parse(room);

    var roomDescription = [];

    roomDescription.push({

        totalPrice: roomsPrice.product.hotelItinerary.rooms[0].displayRoomRate.totalFare.amount,
        roomtype: roomsPrice.product.hotelItinerary.rooms[0].roomType,
        hotelName: roomsPrice.product.hotelItinerary.hotelProperty.name,
        guestCount: roomsPrice.product.hotelItinerary.rooms[0].guestCount,
        checkin: roomsPrice.product.hotelItinerary.rooms[0].stayPeriod.start,
        checkout: roomsPrice.product.hotelItinerary.rooms[0].stayPeriod.end,
        address: roomsPrice.product.hotelItinerary.hotelProperty.address.completeAddress

    });

    var template = $('#hotel-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomDescription);
    $('#hotelList-container').html(html);
});

function paymentPage()
{
    window.location.href = "/guestDetails";
}