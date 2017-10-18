﻿var result;
var bookingDetails;
$(document).ready(function () {

    room = sessionStorage.getItem("roomPrice");
    bookingDetails = JSON.parse(room);
});
function importDetails() {

    var fName = $("#firstName")[0].value;
    var lName = $("#lastName")[0].value;
    var mobileNumber = $("#mobileNumber")[0].value;
    var age = $("#age")[0].value;
    var emailId = $("#emailId")[0].value;
    var cardNumber = $("#cardNumber")[0].value;
    var cardHolder = $("#cardHolder")[0].value;
    var mm = $("#month")[0].value;
    var yy = $("#year")[0].value;
    var cvv = $("#cvv")[0].value;

    var data = {
        "FirstName": fName,
        "LastName": lName,
        "MobileNumber": mobileNumber,
        "Age": age,
        "EmailId": emailId,
        "CardNumber": cardNumber,
        "CardHolder": cardHolder,
        "Month": mm,
        "Year": yy,
        "Cvv": cvv,
        "RoomPricingResponse": bookingDetails


    };

    var modifiedData = JSON.stringify(data);

    $.ajax({
        url: '/api/search/completePayment',
        type: 'post',
        data: modifiedData,
        crossDomain: true,
        dataType: 'json',
        contentType: "application/json",
        success: function (result) {
            console.log(result);
        },
    });
}
