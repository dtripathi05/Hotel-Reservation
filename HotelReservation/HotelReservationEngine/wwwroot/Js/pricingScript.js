var room;
var roomsPrice;
$(document).ready(function () {

    room = sessionStorage.getItem("roomPricing");
    roomsPrice = JSON.parse(room);
});
