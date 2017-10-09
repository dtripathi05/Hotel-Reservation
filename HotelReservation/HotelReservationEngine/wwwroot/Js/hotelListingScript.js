$(function ()
{
    var result = sessionStorage.getItem('SearchResponse');
    result = JSON.parse(result);
    var hotelList = new Array();
    for (i = 0; i < result.length; i++) {
        hotelList.push({
            image: result[i].Itinerary.ImageUrl,
            name: result[i].Itinerary.Name,
            address: result[i].Itinerary.Address,
            price: result[i].Itinerary.MinPrice
        });
    }
    var template = $('#hotel-item');

    var compiledTemplate = Handlebars.compile(template.html());

    var html = compiledTemplate(result);

    $('#hotelList-container').html(html);

});
  