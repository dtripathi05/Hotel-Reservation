var result;
var bookingDetails;
$(document).ready(function () {
    room = sessionStorage.getItem("roomPrice");
    bookingDetails = JSON.parse(room);
});

$(document).ready(function () {
    $("#loader").hide();
});

var flag = false;

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
    var message = "Invalid ";
    var invalidFields = [];
    validateCardNumber(cardNumber);
    if (flag === false) {
        invalidFields.push("Card Number");
    }
    validateCVV(cvv);
    if (flag === false) {
        invalidFields.push("Cvv");
    }
    validateMobileNumber(mobileNumber);
    if (flag === false) {
        invalidFields.push("Mobile Number");
    }
    if (invalidFields.length > 0) {
        var i = 0;
        for (i = 0; i < invalidFields.length; i++) {
            message += invalidFields[i];
            if (i < invalidFields.length - 1)
                message += ", ";
        }
        alert(message);
        return;
    }
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

function validateCardNumber(cardNumber) {

    if (/^[0-9]{16}$/.test(cardNumber)) {
        if (luhnCheck(cardNumber)) {
            flag = true;
        }
        else {
            flag = false;
        }
    }
    else {
        flag = false;
    }

}

function luhnCheck(val) {
    var sum = 0;
    for (var i = 0; i < val.length; i++) {
        var intVal = parseInt(val.substr(i, 1));
        if (i % 2 == 0) {
            intVal *= 2;
            if (intVal > 9) {
                intVal = 1 + (intVal % 10);
            }
        }
        sum += intVal;
    }
    return (sum % 10) === 0;
}

function validateMobileNumber(mobileNumber) {

    if (/^\d{10}$/.test(mobileNumber)) {
        flag = true;
    }
    else {
        flag = false;
    }
}

function validateCVV(cvv) {

    if (/^[0-9]{3,4}$/.test(cvv)) {
        flag = true;
    }
    else {
        flag = false;
    }
}