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
            if (room.itinerary.rooms[i].hotelFareSource.name == "TouricoTGSTest")
            {
                roomType.push({

                    //hotelname: room.rooms[i].hotelName,
                    //description: room.rooms[i].roomDiscription,
                    //roomtype: room.rooms[i].roomName,
                    //price: room.rooms[i].price,
                    //imageurl: room.rooms[i].imageUrl
                    hotelname: room.itinerary.hotelProperty.name,
                    description: room.itinerary.rooms[i].roomDescription,
                    roomtype: room.itinerary.rooms[i].roomName,
                    price: room.itinerary.rooms[i].displayRoomRate.baseFare.amount,
                    imageurl: img,

                });
            }
        }
    }

    var temp = $("#x");
    var cmp = Handlebars.compile(temp.html());
    var htm = cmp({
        //hotelname: roomType[0].hotelname,
        //address: room.rooms[0].address,
        //imageurl: roomType[0].imageurl,
        //rating: room.rooms[0].rating,
        //duration: room.rooms[0].duration,
        //distance: room.rooms[0].distance
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
        //roomSelected = room.itinerary.rooms[i];
        //room.itinerary.rooms = roomSelected;
        if (roomName.toString() == check) {
            var data1 =
                {
                    "Itinerary": room.itinerary,
                    "Criteria": room.criteria,
                    "SessionId": room.sessionId,
                    "RoomName": roomName
                    //"HotelName": room.rooms[0].hotelName,
                    //"RoomName": room.rooms[i].roomName,
                    //"RoomDiscription": room.rooms[0].roomDiscription,
                    //"price": room.rooms[i].price,
                    //"ImageUrl": room.rooms[i].imageUrl,
                    //"GuidId": room.rooms[i].guidId,
                    //"Address": room.rooms[i].address,
                    //"Rating": room.rooms[i].rating,
                    //"Distance": room.rooms[i].distance,
                    //"Duration": room.rooms[i].duration

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
                }
            });

        }
    }
}