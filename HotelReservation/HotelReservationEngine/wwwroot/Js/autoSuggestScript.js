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
        }
    });
});

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

var result;
function extractData() {

    if (document.hotelSearchForm.place.value == "") {
        document.getElementById('errors').innerHTML = "Please Enter The Place";
        return false;
    }

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