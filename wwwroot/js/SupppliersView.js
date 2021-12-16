$(document).ready(function () {
    getAllSuppliers();
});


function getAllSuppliers() {
    var url = "/Suppliers/GetAllSuppliers";
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: url,
        success: function (data) {
            buildSuppliersTable(data.response);
        },
        error: function (jqXHR) {

        }
    });

}

function buildSuppliersTable(elements) {
    var html = "";

    for (var i = 0; i < elements.length; i++) {
        html += "<tr><td>" + elements[i].id + "</td><td>" + elements[i].name + "</td><td>" + elements[i].createdDate + "</td></tr>";
    }

    $("#suppliers-body").html(html);
}

$("#add-supplier").click(function () {
    var supplierName = $("#supplier-name").val();
    if (supplierName !== "") {
        var body = {
            Name: supplierName
        };
        addSupplier(body);
    }
    else {
        M.toast({ html: 'Required fileds' });
    }
});

function addSupplier(body) {
    var url = "/Suppliers/AddSupplier";
    $.ajax({
        contentType: 'application/json',
        type: "POST",
        url: url,
        data: JSON.stringify(body),
        success: function (data) {
                M.toast({ html: 'Supplier added' });
                getAllSuppliers();
                $("#supplier-name").val("");
        },
        error: function (jqXHR) {
            M.toast({ html: 'Somthing went wrong' });
        }
    });

}

