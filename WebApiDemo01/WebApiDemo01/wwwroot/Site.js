const uri = "api/customer";
let customers = null;
function getCount(data) {
    const el = $("#counter");
    let name = "customer";
    if (data) {
        el.text(data + " Customers");
    } else {
        el.text("No Customers");
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#customers");

            $(tBody).empty();

            getCount(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    //.append(
                    //    $("<td></td>").append(
                    //        $("<input/>", {
                    //            type: "checkbox",
                    //            disabled: true,
                    //            checked: item.isComplete
                    //        })
                    //    )
                    //)
                    .append($("<td></td>").text(item.id))
                    .append($("<td></td>").text(item.firstname))
                    .append($("<td></td>").text(item.lastname))
                    .append(
                        $("<td></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    );

                tr.appendTo(tBody);
            });

            customers = data;
        }
    });
}

function addItem() {
    const item = {
        firstname: $("#add-firstname").val(),
        lastname: $("#add-lastname").val(),
        id: 999
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
            $("#add-firstname").val("");
            $("#add-lastname").val("");
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(customers, function (key, item) {
        if (item.id === id) {
            $("#edit-firstname").val(item.firstname);
            $("#edit-lastname").val(item.lastname);
            $("#edit-id").val(item.id);
        }
    });
    $("#spoiler").css({ display: "block" });
}

$(".my-form").on("submit", function () {
    const item = {
        firstname: $("#edit-firstname").val(),
        lastname: $("#edit-lastname").val(),
        id: $("#edit-id").val()
    };

    $.ajax({
        url: uri + "/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}
