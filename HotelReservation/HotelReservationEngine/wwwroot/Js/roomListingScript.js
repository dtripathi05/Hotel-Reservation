Handlebars.registerHelper('times', function (n, block) {
    var accum = '';
    for (var i = 0; i < n; ++i)
        accum += block.fn(i);
    return accum;
});

var roomList;
var room;
$(document).ready(function () {

    roomList = sessionStorage.getItem("rooms");
    room = JSON.parse(roomList);

    var roomType = [];
    var img = "";
    for (var i = 0; i < room.itinerary.rooms.length; i++) {
        {
            for (k = 0; k < room.itinerary.hotelProperty.mediaContent.length; k++) {
                if (room.itinerary.hotelProperty.mediaContent[k].url != null) {
                    img = room.itinerary.hotelProperty.mediaContent[k].url.toString();
                    break;
                }
            }
            if (room.itinerary.rooms[i].hotelFareSource.name == "TouricoTGSTest") {
                roomType.push({
                    hotelname: room.itinerary.hotelProperty.name,
                    description: room.itinerary.rooms[i].roomDescription,
                    roomtype: room.itinerary.rooms[i].roomName,
                    price: room.itinerary.rooms[i].displayRoomRate.baseFare.amount,
                    imageurl: img,

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
        address: room.itinerary.hotelProperty.address.completeAddress,
        imageurl: roomType[0].imageurl,
        rating: room.itinerary.hotelProperty.hotelRating.rating,
        duration: room.itinerary.stayPeriod.duration,
        distance: room.itinerary.hotelProperty.distance.amount,
        latitude: room.itinerary.hotelProperty.geoCode.latitude,
        longitude: room.itinerary.hotelProperty.geoCode.longitude
    });
    $("#roomList-container").html(htm);

    var template = $('#room-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomType);
    $('#roomList-container').append(html);
});
var roomName;
var roomSelected;

function price(data1) {
    console.log(data1);
    roomName = data1.value;
    for (i = 0; i < room.itinerary.rooms.length; i++) {
        var check = room.itinerary.rooms[i].roomName.toString();
        if (roomName.toString() == check) {
            var data1 =
                {
                    "Itinerary": room.itinerary,
                    "Criteria": room.criteria,
                    "SessionId": room.sessionId,
                    "RoomName": roomName
                };
            $.ajax({
                type: "post",
                contentType: "application/json",
                url: "/api/search/roomPrice",
                data: JSON.stringify(data1),
                dataType: 'json',
                crossDomain: true,
                success: function (roomPrice) {
                    sessionStorage.setItem('roomPrice', JSON.stringify(roomPrice));
                    window.location.href = "/roomPricing";
                },
                statusCode: {
                    404: function () {
                        alert("Page Not Found");
                        window.location.href = "/index";
                    },
                    402: function () {
                        alert("Bad Gateway Error");
                        window.location.href = "/index";
                    },
                    500: function () {
                        alert("Some Error Occured,Redirecting To Start Page");
                        window.location.href = "/index";
                    }
                }
            });

        }
    }
}