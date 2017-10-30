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
    url: '../api/hotel/retriveSearchField/' + guidId,
    success: function (hotelSearchRq) {
        try {
            $.ajax({
                type: "post",
                url: "/api/hotel/hotelSearch",
                contentType: "application/json",
                data: JSON.stringify(hotelSearchRq),
                success: function (hotelSearchRs) {
                    hotelResult = hotelSearchRs;
                    var hotelList = [];
                    var urlImage = "";
                    for (i = 0; i < hotelSearchRs.hotels.length; i++) {
                        console.log(hotelSearchRs.hotels[i].supplier.toString());
                        if (hotelSearchRs.hotels[i].supplier == "HotelBeds Test" || hotelSearchRs.hotels[i].supplier == "TouricoTGSTest")
                        {
                            {
                                hotelList.push({
                                    image: hotelSearchRs.hotels[i].imgUrl,
                                    name: hotelSearchRs.hotels[i].name,
                                    address: hotelSearchRs.hotels[i].address,
                                    stars: hotelSearchRs.hotels[i].rating,
                                    fare: hotelSearchRs.hotels[i].basePrice,
                                    currency: hotelSearchRs.hotels[i].currencyCode,
                                    description:hotelSearchRs.hotels[0].hotelDetails
                                });
                            }
                            var template = $('#hotel-item');
                            var compiledTemplate = Handlebars.compile(template.html());
                            var html = compiledTemplate(hotelList);
                            $('#hotelList-container').html(html);
                        }
                    }
                    if (hotelList.length == 0) {
                        alert("No Results Found");
                        window.location.href = "/index";
                    }
                },
                error: function (data) {
                    alert("Some Error Occured");
                    window.location.href = "/index";
                }
            });
        }
        catch (err) {
            alert("Sorry! Something Went Wrong Please Try After SomeTime");
        }
    }
});


function roomDetails(hotelDetail) {
    console.log(hotelDetail.value);
    var hotelName = hotelDetail.value;
    for (i = 0; i < hotelResult.hotels.length; i++) {
        var check = hotelResult.hotels[i].name.toString();
        if (hotelName.toString() == check) {
            var roomSearchRq =
                {
                    "SessionId": hotelResult.hotels[i].sessionId,
                    "ImgUrl": hotelResult.hotels[i].imgUrl,
                    "Name": hotelResult.hotels[i].name,
                    "Address": hotelResult.hotels[i].address,
                    "Rating": hotelResult.hotels[i].rating,
                    "GuidId": hotelResult.hotels[i].guidId,
                    "HotelId": hotelResult.hotels[i].hotelId,
                    "BasePrice": hotelResult.hotels[i].basePrice
                };
            $.ajax({
                type: "post",
                contentType: "application/json",
                url: "/api/hotel/roomSearch",
                data: JSON.stringify(roomSearchRq),
                dataType: 'json',
                crossDomain: true,
                success: function (roomSearchRs) {
                    sessionStorage.setItem('rooms', JSON.stringify(roomSearchRs));
                    window.location.href = "/rooms";
                },
                error: function (data) {
                    alert("Some Error Occured");
                    window.location.href = "/index";
                }
            });
        }
    }
}
