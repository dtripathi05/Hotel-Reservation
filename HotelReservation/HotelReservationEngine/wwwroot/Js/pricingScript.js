var room;
var price;
$(document).ready(function () {

    room = sessionStorage.getItem("roomPrice");
    price = JSON.parse(room);

    var roomDescription = [];

    roomDescription.push({
        totalPrice: price.product.hotelItinerary.rooms[0].displayRoomRate.totalFare.amount,
        roomtype: price.product.hotelItinerary.rooms[0].roomName,
        hotelName: price.product.hotelItinerary.hotelProperty.name,
        guestCount: price.product.hotelItinerary.rooms[0].guestCount,
        checkin: price.product.hotelItinerary.rooms[0].stayPeriod.start,
        checkout: price.product.hotelItinerary.rooms[0].stayPeriod.end,
        address: price.product.hotelItinerary.hotelProperty.address.completeAddress

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