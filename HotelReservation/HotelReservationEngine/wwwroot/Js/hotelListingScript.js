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
               
                var hotelList = [];
                var urlImage = "";
                for (i = 0; i < hotel.itinerary.length; i++)
                {
                    for (k = 0; k < hotel.itinerary[i].hotelProperty.mediaContent.length; k++) {
                        if (hotel.itinerary[i].hotelProperty.mediaContent[k].url != null) {
                            urlImage = hotel.itinerary[i].hotelProperty.mediaContent[k].url.toString();
                            break;
                        }
                    }
                    hotelList.push({
                        image: urlImage,
                        name: hotel.itinerary[i].hotelProperty.name,
                        address: hotel.itinerary[i].hotelProperty.address.completeAddress,
                        price: hotel.itinerary[i].fare.baseFare.amount
                    });
                }
                var template = $('#hotel-item');
                var compiledTemplate = Handlebars.compile(template.html());
                var html = compiledTemplate(hotelList);
                $('#hotelList-container').html(html);
            }
        });
        
    }
});
  