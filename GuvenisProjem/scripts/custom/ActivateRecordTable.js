function Post(url, id) {
    $.ajax({
        url: url + id,
        //data:id
        type: "POST",
        success: function (result) {
            $("#a_" + id).fadeOut();
        }
    })

}