// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetRank(characterId, url) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json",
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: JSON.stringify(characterId),

    }).done(function (data) {
        BuildModalBody(data);
        $("#detailModal").modal({ show: true });
    }).fail(function (data) { alert(data.responseText); });
}

function BuildModalBody(data) {
    $("#detailModal").find(".modal-body").html(`<p id="characterParagraph"> <strong>${data.name}</strong> is the <strong>#${data.rank}</strong> Strongest character of this anime</p>`);
    $("#characterImg").html(`<img src="${data.imagePath}" alt="AnimeCharacter" width="200" height="200">`)
}