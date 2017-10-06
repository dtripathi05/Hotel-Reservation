$(document).ready(function () {
    $("#checkindate").datepicker({ dateFormat:yy-mm-dd });
    $("#checkoutdate").datepicker({ dateFormat:yy-mm-dd });
});



//Data Extraction Function
var result;

function validateDetails() {

    if (document.guestDetailsForm.firstname.value == "") {
        document.getElementById('errors').innerHTML = "Please Enter Your Name";
        return false;
    }
    if (document.guestDetailsForm.lastname.value == "") {
        document.getElementById('errors').innerHTML = "Please Enter Your Last Name";
        return false;
    }
    if (document.guestDetailsForm.mobilenumber.value == "") {
            document.getElementById('errors').innerHTML = "Please Enter Valid Mobile Number";
            return false;
    }
    if (document.guestDetailsForm.age.value == "") {
        document.getElementById('errors').innerHTML = "Please Select Age";
        return false;
    }
    if (document.guestDetailsForm.email.value == "") {
        document.getElementById('errors').innerHTML = "Please Enter Valid Email-ids";
        return false;
    }

    var fName = $("#firstName")[0].value;
    var lName = $("#lastNaame")[0].value;
    var mobNumber = $("#mobileNumber")[0].value;
    var age = $("#age")[0].value;
    var mail = $("#emailId")[0].value;

    var data = {
        "firstName": fName,
        "lastName": lName,
        "mobileNumber": mobNumber,
        "age": age,
        "email-id": mail
    };
}
function extractData() {


    if (document.hotelSearchForm.place.value == "") {
        document.getElementById('errors').innerHTML = "Please Enter The Place You would Visit";
        return false;
    }
    if (document.hotelSearchForm.checkindate.value == "") {
        document.getElementById('errors').innerHTML = "Please Select Check-In Date";
        return false;
    }
    if (document.hotelSearchForm.checkoutdate.value == "") {
        document.getElementById('errors').innerHTML = "Please Select Check-Out Date";
        return false;
    }


    var place = $("#place")[0].value;
    var checkInDate = $("#checkindate")[0].value;
    var checkOutDate = $("#checkoutdate")[0].value;
    var numberOfRooms = $("#rooms")[0].value;
    var adultNumber = $("#adult")[0].value;
    var childNumber = $("#children")[0].value;
   

    var data = {
        "place": place,
        "checkinDate": checkInDate,
        "checkoutDate": checkOutDate,
        "numberOfRooms": numberOfRooms,
        "adultNumber": adultNumber,
        "childNumber": childNumber
    };

    var modifiedData = JSON.stringify(data);

    $.ajax({
        url: '/api/search/new',
        type: 'post',
        contentType: "application/json",
        success: function (result) {
            alert(result);
        },
        data: modifiedData
    });

};