var ProductsObj = [];

$(document).ready(function () {
    $(".modal").modal();
    $("#products-row").hide();
    $('.chips').chips();
    getAllPurchaseOrders();
    getSuppliers();
});


$("#select-supplier").change(function () {
    var supplierId = $("#select-supplier").val();
    getProductsBySupplierId(supplierId);
});


$("#add-purchase-order").click(function () {
    var productsArray = fromatChips(M.Chips.getInstance($(".chips")));

    var orderCode = $("#order-code").val();
    var supplierCode = $("#select-supplier").val();
    var orderDescription = $("#order-description").val();

    if (orderCode !== "" && orderDescription !== "") {
        var totalPrice = 0;
        for (var i = 0; i < productsArray.length; i++) {
            totalPrice = totalPrice + productsArray[i].Price * productsArray[i].Quantity;
        }


        var body = {
            SupplierId: Number(supplierCode),
            OrderCode: orderCode,
            OrderDescription: orderDescription,
            TotalPrice: Number(totalPrice)
        };
        addPurchaseOrder(body, productsArray);
    }
    else {
        M.toast({ html: 'Required Fields' });
    }



});


function fromatChips(chipInstance) {
    var arr = [];
    for (var chipCount = 0; chipCount < chipInstance.chipsData.length; chipCount++) {
        var chipElements = chipInstance.chipsData[chipCount].tag;
        var element = chipElements.split(",");
        var chipobj = convertSelectedChip(element);
        arr.push(JSON.parse(chipobj));
    }
    return arr;
}


function convertSelectedChip(element) {
    var json = "{";
    for (var i = 0; i < element.length; i++) {
        var txt = element[i].split(":");
        json += "'" + txt[0] + "'" + ":";
        //Checking if the value is number or string
        if (txt[1] !== "") {
            json += isNaN(txt[1]) ? "'" + txt[1] + "'" : parseInt(txt[1]);
        }
        else {
            json += "''";
        }

        if ((i + 1) !== (element.length)) {
            json += ",";
        }
    }
    json += "}";
    json = json.replace(/'/g, '"');
    return json;
}

function addPurchaseOrder(body, productsArray) {
    var url = "/PurchaseOrders/AddPurchaseOrder";
    $.ajax({
        contentType: 'application/json',
        type: "POST",
        url: url,
        data: JSON.stringify(body),
        success: function (data) {

            for (var i = 0; i < productsArray.length; i++) {
                var productBody = {
                    PurchaseOrderId: data.response,
                    ProductId: productsArray[i].ProductId,
                    Quantity: productsArray[i].Quantity
                };
                addPurchaseOrderProducts(productBody);
                M.toast({ html: 'Puchase Order Added added' });
                location.reload();
            }

        },
        error: function (jqXHR) {
            M.toast({ html: 'Somthing went wrong' });
        }
    });
}


function addPurchaseOrderProducts(body) {
    var url = "/PurchaseOrders/AddPurchaseOrderProducts";
    $.ajax({
        contentType: 'application/json',
        type: "POST",
        url: url,
        data: JSON.stringify(body),
        success: function (data) {
            getAllPurchaseOrders();
        },
        error: function (jqXHR) {
            M.toast({ html: 'Somthing went wrong' });
        }
    });

}


//GetAll purchase Orders
function getAllPurchaseOrders() {
    var url = "/PurchaseOrders/GetAllPurchaseOrders";
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: url,
        success: function (data) {
            buildPurchaseOrdersTable(data.response);
        },
        error: function (jqXHR) {

        }
    });

}

function buildPurchaseOrdersTable(elements) {
    var html = "";
    for (var i = 0; i < elements.length; i++) {
        html += "<tr>\
                 <td>" + elements[i].id + "</td>\
                 <td>" + elements[i].orderCode + "</td>\
                 <td>" + elements[i].orderDescription + "</td>\
                 <td>" + elements[i].totalPrice + "</td>\
                 <td>" + elements[i].supplierName + "</td>\
                 <td>" + elements[i].createdDate + "</td>\
                 <td><a data-target='products-modal' onClick=\"triggerOpenProduct('"+ elements[i].id +"'); $('.modal').modal('open');\">View</a></td>\
                </tr>";
    }
    $("#purchase-orders-body").html(html);
}


function triggerOpenProduct(purchaseOrderId) {
    var url = "/PurchaseOrders/GetProductsForPurchaseOrder";
    var body = {
        PurchaseOrderId: Number(purchaseOrderId)
    };
    $.ajax({
        contentType: 'application/json',
        type: "POST",
        url: url,
        data: JSON.stringify(body),
        success: function (data) {
            buildProductsHtml(data.response);
        },
        error: function (jqXHR) {
            M.toast({ html: 'Somthing went wrong' });
        }
    });
}


function buildProductsHtml(elements) {

    var html = "";
    for (var i = 0; i < elements.length; i++) {
        html += "<tr>\
                 <td>" + elements[i].productName + "</td>\
                 <td>" + elements[i].unitPrice + "</td>\
                 <td>" + elements[i].quantity + "</td>\
                </tr>";
    }
    $("#product-orders-body").html(html);
}


//Suppliers 

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
    $("#select-supplier").empty();
    if (elements.length !== 0) {
        var html = "<option value='' disabled selected>Select Supplier</option>";
        for (var i = 0; i < elements.length; i++) {
            html += "<option value='" + elements[i].id + "'>" + elements[i].name + "</option>";
        }
        $("#select-supplier").append(html);
        $("#select-supplier").formSelect();
    }
    else {
        M.toast({ html: 'No Suppleirs founded , Please create supplier and products' });
    }

}


//Products
function getProductsBySupplierId(supplierId) {
    var url = "/Products/GetAllProductsBySupplierId";
    var body = {
        SupplierId: supplierId
    };
    $.ajax({
        contentType: 'application/json',
        type: "POST",
        url: url,
        data: JSON.stringify(body),
        success: function (data) {
            ProductsObj = data.response;
            builProductsSelectBox(data.response);
        },
        error: function (jqXHR) {

        }
    });
}


function builProductsSelectBox(elements) {
    $("#select-product").empty();
    if (elements.length !== 0) {
        $("#products-row").show();
        var html = "";
        for (var i = 0; i < elements.length; i++) {
            html += "<option value='" + elements[i].id + "'>" + elements[i].name + "</option>";
        }
        $("#select-product").append(html);
        $("#select-product").formSelect();
    }
    else {
        M.toast({ html: 'No Products founded for the selected Supplier, Please select another supplier' });
    }

}


$("#add-product-chip").click(function () {
    var sinstance = M.Chips.getInstance($("#select-product"));
    var productId = $("#select-product").val();
    var quantity = $("#product-quantity").val();
    var productName = $("#select-product").text();

    if (productName !== "" && quantity !== "") {
        var chipElem = $('.chips');
        var instance = M.Chips.getInstance(chipElem);
        instance.addChip({
            tag: "Name:" + productName + ",Quantity:" + quantity + ",ProductId:" + productId + ",Price:" + getPrice(productId),
            image: ''
        });

        $("#select-product").formSelect();
        $("#product-quantity").val("");
    }
    else {
        M.toast({ html: 'Required Fileds' });
    }
});


function getPrice(productId) {
    var price;
    for (var i = 0; i < ProductsObj.length; i++) {
        price = ProductsObj[i].price;
    }
    return price;
} 



