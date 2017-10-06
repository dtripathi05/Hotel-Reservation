$(function () {

    $("#place").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "http://portal.dev-rovia.com/Services/api/Content/GetAutoCompleteDataGroups?type=poi",
                dataType: "jsonp",
                data: {
                    query: request.term
                },
                success: function (data) {
                    var data = data[0].ItemList;
                    var hotelList = [];
                    for (var i = 0; i < data.length; i++) {
                        hotelList.push({
                            value: data[i].CulturedText,
                            data: data[i]
                        });
                    }
                    response(hotelList);
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
           console.log(ui);
        }
    });
});
