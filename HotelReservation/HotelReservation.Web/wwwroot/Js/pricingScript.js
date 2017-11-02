var hotel;
var hotelRoomPrice;
$(document).ready(function () {
   // hotel = sessionStorage.getItem("roomPrice");
   // price = JSON.parse(hotel);
    hotelRoomPrice = JSON.parse(sessionStorage.getItem("roomPrice"));
    var roomDescription = [];

    roomDescription.push({
        totalPrice: hotelRoomPrice.product.hotelItinerary.rooms[0].displayRoomRate.totalFare.amount,
        roomtype: hotelRoomPrice.product.hotelItinerary.rooms[0].roomName,
        hotelName: hotelRoomPrice.product.hotelItinerary.hotelProperty.name,
        guestCount: hotelRoomPrice.product.hotelItinerary.rooms[0].guestCount,
        checkin: hotelRoomPrice.product.hotelSearchCriterion.stayPeriod.start.substring(0, 10),
        checkout: hotelRoomPrice.product.hotelSearchCriterion.stayPeriod.end.substring(0, 10),
        address: hotelRoomPrice.product.hotelItinerary.hotelProperty.address.completeAddress,
        currencyCode:hotelRoomPrice.product.hotelItinerary.fare.baseFare.currency
    });
    var template = $('#price-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomDescription);
    $('#priceList-container').html(html);
});

function paymentPage()
{
    sessionStorage.setItem('price', JSON.stringify(hotelRoomPrice));
    window.location.href = "/guestDetails";
}