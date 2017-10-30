Handlebars.registerHelper('times', function (n, block) {
    var accum = '';
    for (var i = 0; i < n; ++i)
        accum += block.fn(i);
    return accum;
});

var roomList;
var hotel;
$(document).ready(function () {

    roomList = sessionStorage.getItem("rooms");
    hotel = JSON.parse(roomList);

    var roomType = [];
    var img = [];
    for (var i = 0; i < hotel.itinerary.rooms.length; i++) {
        {
            for (k = 0; k < hotel.itinerary.hotelProperty.mediaContent.length; k++) {
                if (hotel.itinerary.hotelProperty.mediaContent[k].url != null) {
                    img.push({
                        img : hotel.itinerary.hotelProperty.mediaContent[k].url.toString()
                    });
                }
            }
            if (hotel.itinerary.rooms[i].hotelFareSource.name == "TouricoTGSTest") {
                roomType.push({
                    hotelname: hotel.itinerary.hotelProperty.name,
                    description: hotel.itinerary.rooms[i].roomDescription,
                    roomtype: hotel.itinerary.rooms[i].roomName,
                    price: hotel.itinerary.rooms[i].displayRoomRate.baseFare.amount,
                    imageurl: img,
                    currencyCode:hotel.itinerary.fare.baseFare.currency

                });
            }
        }
    }
    if (roomType.length == 0)
    {
        alert("Sorry No Rooms Found Please Select Another Hotel");
        window.location.href = "/hotel";
    }
    var temp = $("#x");
    var cmp = Handlebars.compile(temp.html());
    var htm = cmp({
        hotelname: roomType[0].hotelname,
        address: hotel.itinerary.hotelProperty.address.completeAddress,
        imageurl: roomType[0].imageurl,
        rating: hotel.itinerary.hotelProperty.hotelRating.rating,
        duration: hotel.itinerary.stayPeriod.duration,
        distance: hotel.itinerary.hotelProperty.distance.amount,
        latitude: hotel.itinerary.hotelProperty.geoCode.latitude,
        longitude: hotel.itinerary.hotelProperty.geoCode.longitude
    });
    $("#roomList-container").html(htm);

    var template = $('#room-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomType);
    $('#roomList-container').append(html);
});
var roomName;
var roomSelected;

function price(roomDetail) {
    console.log(roomDetail);
    roomName = roomDetail.value;
    for (i = 0; i < hotel.itinerary.rooms.length; i++) {
        var check = hotel.itinerary.rooms[i].roomName.toString();
        if (roomName.toString() == check) {
            var roomPricingRq =
                {
                    "Itinerary": hotel.itinerary,
                    "Criteria": hotel.criteria,
                    "SessionId": hotel.sessionId,
                    "RoomName": roomName
                };
            $.ajax({
                type: "post",
                contentType: "application/json",
                url: "/api/hotel/roomPrice",
                data: JSON.stringify(roomPricingRq),
                dataType: 'json',
                crossDomain: true,
                success: function (roomPricingRs) {
                    sessionStorage.setItem('roomPrice', JSON.stringify(roomPricingRs));
                    window.location.href = "/roomPricing";
                },
                error: function (data) {
                    alert("Some Error Occured");
                    window.location.href = "/index";
                },
            });

        }
    }
}