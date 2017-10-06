var result;

function importCardDetails() {

    var cardNumber = $("#cardNumber")[0].value;
    var cardHolder = $("#cardHolder")[0].value;
    var mm = $("#month")[0].value;
    var yy = $("#year")[0].value;
    var cvv = $("#cvv")[0].value;

    var data = {
        "CardNumber": cardNumber,
        "CardHolder": cardHolder,
        "Month": mm,
        "Year": yy,
        "Cvv": cvv
    };

    var modifiedData = JSON.stringify(data);

    $.ajax({
        url: '',
        type: 'post',
        contentType: "application/json",
        success: function (result) {
            alert(result);
        },
        data: modifiedData
    });
}