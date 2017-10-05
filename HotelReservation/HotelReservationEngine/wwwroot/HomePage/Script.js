//Data Extraction Function
var result;
function extractData() {
    var place = $("#place")[0].value;
    var checkInDate = $("#datePickerId1")[0].value;
    var checkOutDate = $("#datePickerId2")[0].value;
    var numberOfRooms = $("#rooms")[0].value;
    var adultNumber = $("#adult")[0].value;
    var childNumber = $("#children")[0].value;
    var checkInDateString1 = checkInDate.toString();
    var checkInDateString2 = checkOutDate.toString();
    var data = {
        "place": place,
        "checkinDate": checkInDateString1,
        "checkoutDate": checkInDateString2,
        "numberOfRooms": numberOfRooms,
        "adultNumber":
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