var details;
var completeBooking;
$(document).ready(function () {
    details = sessionStorage.getItem("bookingDetails");
    completeBooking = JSON.parse(details);

    var bookingDescription = [];
    bookingDescription.push({
        bookingId: completeBooking.confirmationNumber,
        checkin: completeBooking.checkIn,
        checkout: completeBooking.checkOut,
        totalPrice: completeBooking.amountPaid
    });
    var template = $('#booking-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(bookingDescription);
    $('#booking-container').html(html);
});

function startPage() {
    sessionStorage.clear();
    window.location.href = "/index";
}