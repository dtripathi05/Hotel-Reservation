var bookingDetails;
$(document).ready(function () {
    bookingDetails = JSON.parse(sessionStorage.getItem("roomPrice"));
});

$(document).ready(function () {
    $("#loader").hide();
});

var flag = false;

function importDetails() {
    var prefix = $("#prefix")[0].value;
    var fName = $("#firstName")[0].value;
    var mName = $("#middleName")[0].value;
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
    validateCardHolder(cardHolder);
    if (flag === false) {
        invalidFields.push(" Card-Holder ");
    }

    validateFirstName(fName)
    if (flag === false) {
        invalidFields.push(" First-Name ");
    }

    validateMiddleName(mName)
    if (flag === false) {
        invalidFields.push(" Middle-Name ");
    }

    validateLastName(lName)
    if (flag === false) {
        invalidFields.push(" Last-Name ");
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
    var guestDetail = {
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

    $("#loader").show();
    $.ajax({
        url: '/api/hotel/completePayment',
        type: 'post',
        data: JSON.stringify(guestDetail),
        crossDomain: true,
        dataType: 'json',
        contentType: "application/json",
        success: function (completeBookingRs) {
            if (completeBookingRs.confirmationNumber == null) {
                alert("Unable To Complete Request ! Please Try After Sometime");
                window.location.href = "/index";
            }
            else {
                window.location.href = "/bookingPage";
                sessionStorage.setItem('bookingDetails', JSON.stringify(completeBookingRs));
            }
        },
        error: function (data) {
            alert("Some Error Occured");
            window.location.href = "/index";
        }
    });
}

function validateCardNumber(cardNumber) {

    if (/^[0-9]{13,14,15,16}$/.test(cardNumber)) {
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

function validateCardHolder(cardHolder) {

    if (/^[a-zA-Z ]*$/.test(cardHolder)) {
        flag = true;
    }
    else {
        flag = false;
    }
}

function validateFirstName(fName) {

    if (/^[a-zA-Z ]*$/.test(fName)) {
        flag = true;
    }
    else {
        flag = false;
    }
}

function validateMiddleName(mName) {

    if (/^[a-zA-Z ]*$/.test(mName)) {
        flag = true;
    }
    else {
        flag = false;
    }
}
function validateLastName(lName) {

    if (/^[a-zA-Z ]*$/.test(lName)) {
        flag = true;
    }
    else {
        flag = false;
    }
}