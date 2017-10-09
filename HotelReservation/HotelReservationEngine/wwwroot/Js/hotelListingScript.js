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
                
                for (i = 0; i < hotel.hotelResults.length; i++)
                {
                    hotelList.push({
                        image: hotel.hotelResults[i].imageUrl,
                        name: hotel.hotelResults[i].name,
                        address: hotel.hotelResults[i].address,
                        price: hotel.hotelResults[i].minPrice
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
  