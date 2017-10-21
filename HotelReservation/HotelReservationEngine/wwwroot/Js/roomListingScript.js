var roomList;
var room;
$(document).ready(function () {

    roomList = sessionStorage.getItem("rooms");
    room = JSON.parse(roomList);

    var roomType = [];
    var img = "";
    for (var i = 0; i < room.itinerary.rooms.length; i++) {
       // if (room.itinerary.rooms[i].hotelFareSource.name == "HotelBeds Test")
        {
            for (k = 0; k < room.itinerary.hotelProperty.mediaContent.length; k++)
            {
                if (room.itinerary.hotelProperty.mediaContent[k].url != null) {
                    img = room.itinerary.hotelProperty.mediaContent[k].url.toString();
                    break;
                }
            }
           // img = room.itinerary.hotelProperty.mediaContent[i].url.toString();
            roomType.push({

                hotelname: room.itinerary.hotelProperty.name,
                description: room.itinerary.rooms[i].roomDescription,
                address: room.itinerary.hotelProperty.address.completeAddress,
                roomtype: room.itinerary.rooms[i].roomName,
                price: room.itinerary.rooms[i].displayRoomRate.baseFare.amount,
                imageurl: img
            });
        }

    }
    var temp = $("#x");
    var cmp = Handlebars.compile(temp.html());
    var htm = cmp({ hotelname: roomType[0].hotelname });
    $("#roomList-container").html(htm);

    var template = $('#room-item');
    //console.log(roomType[0].hotelname);
    //console.log(template.html());
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomType);
    //console.log(html);
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