Handlebars.registerHelper('times', function (n, block) {
    var accum = '';
    for (var i = 0; i < n; ++i)
        accum += block.fn(i);
    return accum;
});

var completeUrl = window.location.href;
var end = completeUrl.lastIndexOf("/");
var guidId = completeUrl.slice(end + 1);
var hotelResult;
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
                hotelResult = hotel;
                var hotelList = [];
                var urlImage = "";
                for (i = 0; i < hotel.itinerary.length; i++) {
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
                        stars: hotel.itinerary[i].hotelProperty.hotelRating.rating,
                        buttonName: hotel.itinerary[i].hotelProperty.name
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


function roomDetails(data) {
    console.log(data.value);
    var hotelName = data.value;
    for (i = 0; i < hotelResult.itinerary.length; i++) {
        var check = hotelResult.itinerary[i].hotelProperty.name.toString();
        if (hotelName.toString() == check) {
            var data1 =
                {
                    "Itinerary": hotelResult.itinerary[i],
                    "Criteria": hotelResult.hotelSearchCriterion,
                    "SessionId": hotelResult.sessionId
                };
            $.ajax({
                type: "post",
                contentType: "application/json",
                url: "/api/search/room",
                data: JSON.stringify(data1),
                dataType: 'json',
                crossDomain: true,
                success: function (room) {
                    sessionStorage.setItem('rooms', JSON.stringify(room));
                    window.location.href = "/rooms";
                }
            });
        }
    }
}
