$(document).ready(function () {
    getAllProducts();
    getSuppliers();
});


function getAllProducts() {
    var url = "/Products/GetAllProducts";
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: url,
        success: function (data) {
            buildProductsTable(data.response);
        },
        error: function (jqXHR) {

        }
    });

}

function buildProductsTable(elements) {
    var html = "";
    for (var i = 0; i < elements.length; i++) {
        html += "<tr>\
                 <td>" + elements[i].id + "</td>\
                 <td>" + elements[i].name + "</td>\
                 <td>" + elements[i].code + "</td>\
                 <td>" + elements[i].price + "</td>\
                 <td>" + elements[i].description + "</td>\
                 <td>" + elements[i].supplierName + "</td>\
                </tr>";
    }
    $("#products-body").html(html);
}

$("#add-product").click(function () {
    var pName = $("#product-name").val();
    var pCode = $("#product-code").val();
    var pPrice = $("#product-price").val();
    var pDescription = $("#product-description").val();
    var pSupId = $("#select-supplier").val();


    if (pName !== "" && pCode !== "" && pPrice !== "" && pDescription !== "" && pSupId !== "") {
        var body = {
            Name: pName,
            Code: pCode,
            Price: pPrice,
            Description: pDescription,
            SupplierId: Number(pSupId)
        };
        addProduct(body);
    }
    else {
        M.toast({ html: 'Required fileds' });
    }
});

function addProduct(body) {
    var url = "/Products/AddProduct";
    $.ajax({
        contentType: 'application/json',
        type: "POST",
        url: url,
        data: JSON.stringify(body),
        success: function (data) {

            M.toast({ html: 'Product added' });
            getSuppliers();
        },
        error: function (jqXHR) {
            M.toast({ html: 'Somthing went wrong' });
        }
    });

}


function getSuppliers() {
    var url = "/Suppliers/GetAllSuppliers";
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: url,
        success: function (data) {
            buildSuppliersSelectBox(data.response);
        },
        error: function (jqXHR) {

        }
    });
}

function buildSuppliersSelectBox(elements) {
    var html = "<option disabled selected>Select Supplier</option>";
    for (var i = 0; i < elements.length; i++) {
        html += "<option value='" + elements[i].id + "'>" + elements[i].name + "</option>";
    }
    $("#select-supplier").append(html);
    $("#select-supplier").formSelect();
}
