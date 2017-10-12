var roomList;
var room;
$(document).ready(function () {

    roomList = sessionStorage.getItem("rooms");
    room = JSON.parse(roomList);

    var roomType = [];
    var img="";
    for (var i = 0; i < room.itinerary.rooms.length; i++) {
        img = room.itinerary.hotelProperty.mediaContent[i].url.toString();
        roomType.push({

            hotelname: room.itinerary.hotelProperty.name,
            description: room.itinerary.rooms[i].roomDescription,
            address: room.itinerary.hotelProperty.address.completeAddress,
            roomtype: room.itinerary.rooms[i].roomName,
            price: room.itinerary.rooms[i].displayRoomRate.totalFare.amount,
            imageurl: img
        });

    }
    var template = $('#room-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(roomType);
    $('#roomList-container').html(html);
}
);
var roomName
function roomPrice(data1) {
    console.log(data1);
    roomName = data1.value;
    for (i = 0; i < room.itinerary.rooms.length; i++)
    {
        var check = room.itinerary.rooms[i].roomName.toString();
        if (roomName.toString() == check)
        {
            var data1 =
                {
                    "Itinerary": room.itinerary,
                    "Criteria": room.criteria,
                    "SessionId": room.sessionId
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
                    window.location.href = "/roomPrice";
                }
            });

        }
    }
}