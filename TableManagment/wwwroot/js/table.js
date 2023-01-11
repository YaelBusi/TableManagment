

$(document).ready(function () {
    fetch("../api/Color")
        .then(res => {
            if (res.ok == true)
                return res.json();
            else if (res.status == 204)
                throw new Error("status code is " + res.status);
        })
        .then(data => {
            if (data) {
                data.forEach(color => drawColor(color));
                $("#count").text(data.length);
            }
            else {
                alert("there is no colors in store");
            }
        });
});



function drawColor(color) {
    let trCopy = $("#tmpTr").clone();
    $("#tmpTr").hide();
    trCopy.find(".desc").text(color.desc);
    trCopy.find(".price").text(color.price);
    trCopy.find(".color").text(color.color1);
    trCopy.find(".order").text(color.order);
    trCopy.find(".operations").find(".deleteBtn").click(() => {
        toDelete(color.id)
    })
    trCopy.find(".operations").find(".editBtn").click(() => {
        toEdit(color.id)
    })
    trCopy.show();
    $("#bobyTable").append(trCopy);
}

function toDelete(id) {
    fetch('../api/Color?id=' + id,
        {
            method: 'DELETE',
        })
        .then(data => {
            if (!data.ok)
                throw new Error();
            alert("The color is deleted sucsses!");
            window.location.replace("table.html");
        })
        .catch(e => alert("Have a some problem, Sorry..."));
}

function toEdit(id) {
    fetch("../api/Color/"+id)
    .then(res => {
        if (res.ok == true)
            return res.json();
        else if (res.status == 204)
            throw new Error("status code is " + res.status);
    })
    .then(data => {
        if (data) {
            sessionStorage.setItem('color', JSON.stringify(data));
            window.location.replace("editColor.html");
        }
        else {
            alert("there is no color with id");
        }
    });
}
