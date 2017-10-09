//$(function ()
//{
//    var result = sessionStorage.getItem('SearchResponse');
//    result = JSON.parse(result);
//    var hotelList = new Array();
//    for (i = 0; i < result.length; i++) {
//        hotelList.push({
//            image: result[i].Itinerary.ImageUrl,
//            name: result[i].Itinerary.Name,
//            address: result[i].Itinerary.Address,
//            price: result[i].Itinerary.MinPrice
//        });
//    }
//    var template = $('#hotel-item');

//    var compiledTemplate = Handlebars.compile(template.html());

//    var html = compiledTemplate(result);

//    $('#hotelList-container').html(html);

//});

var completeUrl = window.location.href;
var end = completeUrl.lastIndexOf("/");
var guidId = completeUrl.slice(end + 1);
var hotelresult;
$.ajax({
    type: "GET",
    url: '../api/search/retriveRequest/' + guidId,
    success: function (result1) {
        $.ajax({
            type: "post",
            url: "/api/search/hotel",
            contentType: "application/json",
            data: JSON.stringify(result1),
            success: function (hotel) {
                hotelresult: hotel;
            }
        });
        
    }
});
  