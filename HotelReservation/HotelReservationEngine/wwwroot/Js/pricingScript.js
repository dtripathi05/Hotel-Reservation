var room;
var price;
$(document).ready(function () {

    room = sessionStorage.getItem("roomPrice");
    price = JSON.parse(room);

    var roomDescription = [];

    roomDescription.push({
        totalPrice: roomsPrice.product.hotelItinerary.rooms[0].displayRoomRate.totalFare.amount,
        roomtype: roomsPrice.product.hotelItinerary.rooms[0].roomName,
        hotelName: roomsPrice.product.hotelItinerary.hotelProperty.name,
        guestCount: roomsPrice.product.hotelItinerary.rooms[0].guestCount,
        checkin: roomsPrice.product.hotelItinerary.rooms[0].stayPeriod.start,
        checkout: roomsPrice.product.hotelItinerary.rooms[0].stayPeriod.end,
        address: roomsPrice.product.hotelItinerary.hotelProperty.address.completeAddress

    });

    var template = $('#price-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomDescription);
    $('#priceList-container').html(html);

});

function paymentPage()
{
    sessionStorage.setItem('price', JSON.stringify(price));
    window.location.href = "/guestDetails";
}