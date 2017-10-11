$(document).ready(function () {
    $("#checkindate").datepicker({ dateFormat: 'yy-mm-dd' });
    $("#checkoutdate").datepicker({ dateFormat: 'yy-mm-dd' });
});

var latitude;
var longitude;
var cityName;
var searchType;
var result;


//Data Extraction Function



function extractData() {

    var place = $("#place").val();
    var checkInDate = $("#checkindate").val();
    var checkOutDate = $("#checkoutdate")[0].value;
    var numberOfRooms = $("#rooms")[0].value;
    var adultNumber = $("#adult")[0].value;
    var childNumber = $("#children")[0].value;


    var data = {
        "Destination": {
            "Longitude": longitude,
            "Latitude": latitude,
            "SearchType": searchType,
            "CityName": cityName
        },
        "CheckInDate": checkInDate,
        "CheckOutDate": checkOutDate,
        "Rooms": numberOfRooms,
        "Adults": adultNumber,
        "ChildrenCount": childNumber
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