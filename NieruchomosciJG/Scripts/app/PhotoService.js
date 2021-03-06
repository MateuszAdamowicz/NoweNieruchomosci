﻿var createOption = function(id) {
    var opt = document.createElement("option");
    $(opt).addClass("toSelect");
    opt.text = id;
    opt.value = id;
    return opt;
};


var removeOption = function(id) {
    for (var i = 0; i < $("#PhotosToSave")[0].length; i++) {
        if ($("#PhotosToSave")[0].options[[i]].value === id) {
            var index = i;
            break;
        }
    }

    var photos = $(".image");
    for (var i = 0; i < photos.length; i++) {
        if ($(photos[i]).attr("data-id") === id) {
            photos[i].remove();
        }
    }

    $("#PhotosToSave")[0].remove(index);
};

var removeImage = function(id) {
    $.ajax({
        url: "/api/Photo/RemovePhoto",
        data: id,
        contentType: 'application/json; charset=utf-8',
        type: "POST"
    });
};

var addImg = function (path, id) {
    $("#PhotosToSave")[0].add(createOption(id));
    $(".toSelect").attr("selected", true);

    $("<div data-id='"+id+"' class='col-md-3 image'><img data-id='"+id+"' class='borderedImage' src='" + path + "'/><span class='glyphicon glyphicon-remove-sign removeImage' data-id='" + id + "'></span></div>").insertBefore(
        $("#btndiv")
        );
};

var addBtnDiv = function () {
    $(".gallery").prepend(
        "<div class='col-md-3' id='btndiv'>" +
                                "<span class='btn btn-success btn-file'>" +
                                    "<span class='glyphicon glyphicon-camera'></span>" +
                                    "<input type='file' id='Photos' accept='image/*' />" +
                                "</span>" +
                            "</div>"
    );
};

var success = function (result, status, xhr) {
    jQuery.each(result, function (i) {
        addImg(result[i].GetPath, result[i].Id);
    });
    $("#btndiv").show();
    $("#spinnerdiv").hide();
};

var error = function (xhr, status, error) {
    $("#btndiv").show();
    $("#spinnerdiv").hide();
};

var sendPhoto = function (data) {
    $.ajax({
        url: "/api/Photo/AddPhoto",
        data: data,
        type: "POST",
        success: success,
        error: error,
        processData: false,
        contentType: false,
    });
    $("#Photos")[0].value = "";
}