$(document).ready(function () {
    $("#checkindate").datepicker({
        dateFormat: "yy-mm-dd",
        minDate: 0,
        onSelect: function () {
            var checkOutDate = $('#checkoutdate');
            var startDate = $(this).datepicker('getDate');
            startDate.setDate(startDate.getDate() + 1);
            var minDate = $(this).datepicker('getDate');
            checkOutDate.datepicker('setDate', minDate);
            checkOutDate.datepicker('option', 'minDate', minDate);
        }
    });
    $('#checkoutdate').datepicker({
        dateFormat: "yy-mm-dd"
    });
});

var latitude;
var longitude;
var cityName;
var searchType;
var result;

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
        url: 'hotel',
        type: 'post',
        contentType: "application/json",
        success: function (result) {
            alert(result);
        },
        data: modifiedData
    });
}


$(function () {

    $("#place").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "http://portal.dev-rovia.com/Services/api/Content/GetAutoCompleteDataGroups?type=poi",
                dataType: "jsonp",
                data: {
                    query: request.term
                },
                success: function (data) {
                    var data = data[0].ItemList;
                    var hotelList = [];
                    for (var i = 0; i < data.length; i++) {
                        hotelList.push({
                            value: data[i].CulturedText,
                            data: data[i]
                        });
                    }
                    response(hotelList);
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            console.log(ui);
            latitude = ui.item.data.Latitude;
            longitude = ui.item.data.Longitude;
            cityName = ui.item.data.CityName;
            searchType = ui.item.data.SearchType;
        }
    });
});
