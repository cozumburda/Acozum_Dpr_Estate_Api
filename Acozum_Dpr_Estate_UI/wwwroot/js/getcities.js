$("#pCategoryId").change(function () {
    var id = $("#pCategoryId").val();
    $.get("/Property/GetCityList/" + id, function (data) {
        $("#pCity").html(data);
    });
    console.log(id)
});