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
        try {
            $.ajax({
                type: "post",
                url: "/api/search/hotel",
                contentType: "application/json",
                data: JSON.stringify(result1),
                success: function (hotel) {
                    hotelResult = hotel;
                    var hotelList = [];
                    var urlImage = "";
                    for (i = 0; i < hotel.hotels.length; i++) {
                        console.log(hotel.hotels[i].supplier.toString());
                        if (hotel.hotels[i].supplier == "HotelBeds Test" || hotel.hotels[i].supplier == "TouricoTGSTest")
                        {
                            {
                                hotelList.push({
                                    image: hotel.hotels[i].imgUrl,
                                    name: hotel.hotels[i].name,
                                    address: hotel.hotels[i].address,
                                    stars: hotel.hotels[i].rating,
                                    fare: hotel.hotels[i].basePrice
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
                }
            });
        }
        catch (err) {
            alert("Sorry! Something Went Wrong Please Try After SomeTime");
        }
    }
});


function roomDetails(data) {
    console.log(data.value);
    var hotelName = data.value;
    for (i = 0; i < hotelResult.hotels.length; i++) {
        var check = hotelResult.hotels[i].name.toString();
        if (hotelName.toString() == check) {
            var data1 =
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
                url: "/api/search/room",
                data: JSON.stringify(data1),
                dataType: 'json',
                crossDomain: true,
                success: function (room) {
                    sessionStorage.setItem('rooms', JSON.stringify(room));
                    window.location.href = "/rooms";
                },
                statusCode: {
                    404: function () {
                        alert("Page Not Found");
                        window.location.href = "/index";
                    },
                    402: function () {
                        alert("Bad GatewaY Error");
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
