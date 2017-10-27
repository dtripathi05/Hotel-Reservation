var details;
var completeBooking;
var currency;
$(document).ready(function () {
    details = sessionStorage.getItem("bookingDetails");
    currency = sessionStorage.getItem("rooms");
    completeBooking = JSON.parse(details);
    currencyCode = JSON.parse(currency);

    var bookingDescription = [];
    bookingDescription.push({
        bookingId: completeBooking.confirmationNumber,
        checkin: completeBooking.checkIn.substring(0, 10),
        checkout: completeBooking.checkOut.substring(0, 10),
        totalPrice: completeBooking.amountPaid,
        name: completeBooking.travelerName,
        currencyCode: currencyCode.itinerary.fare.baseFare.currency
    });
    var template = $('#booking-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(bookingDescription);
    $('#booking-container').html(html);
});

function startPage() {
    sessionStorage.clear();
    alert("Thank You For Booking With Us..!!Do Visit Again");
    window.location.href = "/index";
}
function printPage() {
    window.print();
}