$(document).ready(function () {
    $("#checkindate").datepicker({ dateFormat: 'yy-mm-dd' });
    $("#checkoutdate").datepicker({ dateFormat:'yy-mm-dd' });
});



//Data Extraction Function
var result;


function extractData() {
    

    //if (document.hotelSearchForm.place.value == "") {
    //    document.getElementById('errors').innerHTML = "Please Enter The Place You would Visit";
    //    return false;
    //}
    //if (document.hotelSearchForm.checkindate.value == "") {
    //    document.getElementById('errors').innerHTML = "Please Select Check-In Date";
    //    return false;
    //}
    //if (document.hotelSearchForm.checkoutdate.value == "") {
    //    document.getElementById('errors').innerHTML = "Please Select Check-Out Date";
    //    return false;
    //}


    var place = $("#place")[0].value;
    var checkInDate = $("#checkindate")[0].value;
    var checkOutDate = $("#checkoutdate")[0].value;
    var numberOfRooms = $("#rooms")[0].value;
    var adultNumber = $("#adult")[0].value;
    var childNumber = $("#children")[0].value;


    var data = {
        "Destination": place,
        "CheckIn": checkInDate,
        "CheckOut": checkOutDate,
        "Rooms": numberOfRooms,
        "Adults": adultNumber,
        "ChildAge": childNumber
    };

    var modifiedData = JSON.stringify(data);

    $.ajax({
        url: '/api/search/newRequest',
        type: 'post',
        contentType: "application/json",
        success: function (result) {
            alert(result);
        },
        data: modifiedData
    });

}