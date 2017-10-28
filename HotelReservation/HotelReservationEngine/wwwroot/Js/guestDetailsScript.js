var result;
var bookingDetails;
$(document).ready(function () {
    hotel = sessionStorage.getItem("roomPrice");
    bookingDetails = JSON.parse(hotel);
});

$(document).ready(function () {
    $("#loader").hide();
});

function importDetails() {
    var prefix = $("#prefix")[0].value; 
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
        "Prefix": prefix,
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
    $("#loader").show();
    $.ajax({
        url: '/api/hotel/completePayment',
        type: 'post',
        data: modifiedData,
        crossDomain: true,
        dataType: 'json',
        contentType: "application/json",
        success: function (result) {
            if (result.confirmationNumber == null) {
                alert("Unable To Complete Request ! Please Try After Sometime");
                window.location.href = "/index";
            }
            else {
                window.location.href = "/bookingPage";
                sessionStorage.setItem('bookingDetails', JSON.stringify(result));
            }
        },
        error: function (data) {
            alert("Some Error Occured");
            window.location.href = "/index";
        }
    });
}
