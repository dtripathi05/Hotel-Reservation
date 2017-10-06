$(document).ready(function () {
    $("#checkindate").datepicker({ dateFormat: 'yy-mm-dd' });
    $("#checkoutdate").datepicker({ dateFormat:'yy-mm-dd' });
});



//Data Extraction Function
var result;


function extractData() {
  
    var place = $("#place")[0].value;
    var checkInDate = $("#checkindate").val();
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