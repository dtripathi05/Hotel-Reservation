var roomList;
var rooms;

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