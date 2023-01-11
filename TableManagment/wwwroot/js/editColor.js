

let color = JSON.parse(sessionStorage.getItem('color')) || null;

$(document).ready(function () {
    if (color != null) {
        $("#name").val(color.desc);
        $("#price").val(color.price);
        $("#color").val(color.color1);
        $("#order").val(color.order);
    } else {
        color = { desc: "", price: "", color1: "", order: "" };
    }
    $("#submit").click(async function () {
        await submitForm();
    })
    $("#add").click(function () {
        sessionStorage.removeItem("color");
        window.location.replace("editColor.html");
    })

    $('.elements').change(function () {
        color.desc = $('#name').val();
        color.price = $('#price').val();
        color.color1 = $('#color').val();
        color.order = $("#order").val();
    });
})


async function submitForm() {
    let ID;
    if (color.id == undefined)
        ID = -1;
    else
        ID = color.id;
    fetch("https://localhost:7225/api/Color/" +ID, {
        headers: {
            "Content-Type": "application/json; charset=utf-8"
        },
        method: 'PUT',
        body: JSON.stringify(color)
    }).then(res => {
        return res.json()
    }).
        then(data => {
            sessionStorage.setItem("color", JSON.stringify(data));
            window.location.replace("table.html");
        })
}