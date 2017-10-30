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
            checkOutDate.datepicker('option', 'minDate', startDate);
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


    var hotelSearchField = {
        "Destination": {
            "Longitude": longitude,
            "Latitude": latitude,
            "SearchType": searchType,
            "CityName": cityName
        },
        "CheckInDate": checkInDate,
        "CheckOutDate": checkOutDate,
        "Rooms": numberOfRooms,
        "Adult": adultNumber,
        "ChildrenCount": childNumber
    };

    var modifiedData = JSON.stringify(hotelSearchField);
    $.ajax({
        url: '/api/hotel/searchField',
        type: 'post',
        contentType: "application/json",
        success: function (guidId) {
            window.location.href = "/hotel/" + guidId;
        },
        error: function (data) {
            alert("Some Error Occured");
            window.location.href = "/index";
        },
        data: modifiedData,

    });
}

$(function () {

    $("#place").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "http://portal.dev-rovia.com/Services/api/Content/GetAutoCompleteDataGroups?type=poi",
                //url:"http://portal.dev-rovia.com/Services/api/Content/GetAutoCompleteDataGroups?type=city%7Cairport%7Cpoi",
                dataType: "jsonp",
                data: {
                    query: request.term
                },
                success: function (autoCompleteRS) {
                    var autoCompleteRS = autoCompleteRS[0].ItemList;
                    var hotelList = [];
                    for (var i = 0; i < autoCompleteRS.length; i++) {
                        hotelList.push({
                            value: autoCompleteRS[i].CulturedText,
                            data: autoCompleteRS[i]
                        });
                    }
                    response(hotelList);
                },
                error: function (data) {
                    alert("Some Error Occured");
                    window.location.href = "/index";
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
