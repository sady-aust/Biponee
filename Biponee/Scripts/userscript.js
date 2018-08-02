$(window).on('load', function () {
    if (sessionStorage.getItem('status') == 'loggedIn') {
        document.getElementById("loginLink").setAttribute("style", "display: block;");
        document.getElementById("joinLink").setAttribute("style", "display: block;");
        sessionStorage.setItem('status', 'logged out')
    }
});
function getProductWidget(productName, price) {
    var productWidgetDiv = document.createElement("div");
    productWidgetDiv.setAttribute("class", "product product-widget");

    var bodyDiv = document.createElement("div");
    bodyDiv.setAttribute("class", "product-body");

    var h5 = document.createElement("h5");
    h5.innerHTML = "Price " + price + " Tk"

    var Qh5 = document.createElement("h5");
    Qh5.innerHTML = "Quanity " + "1";
    var nmaeh5 = document.createElement("h5");
    nmaeh5.innerHTML = productName;

    bodyDiv.appendChild(h5);
    bodyDiv.appendChild(Qh5);
    bodyDiv.appendChild(nmaeh5);

    productWidgetDiv.appendChild(bodyDiv);
    return productWidgetDiv;
}


function showItems() {
    document.location = '@Url.Action("Products", "User")' + '?' + 'id=' + parseInt(document.getElementById("sectionId").value);
}

function goToProductPage(id) {
    document.location = '@Url.Action("ProductPage", "User")' + '?' + 'id=' + parseInt(id);
}
function goToCart() {
    document.location = '@Url.Action("Cart", "User")' + '?' + 'userId=' + parseInt(sessionStorage.getItem('userID'));
}


function addToCart(id, img, PriceP) {
    if ((sessionStorage.getItem('status') != 'loggedIn')) {
        alert("Please Log in First");
    }
    else {
        console.log("can add");
        var productId = parseInt(id);
        var quantity = 1;
        var userId = sessionStorage.getItem('userID');
        var status = 0;
        var imgLink = img;
        var price = PriceP;

        var JsonData = { ProductId: productId, Qunaity: quantity, UserID: userId, Status: status, ImageLink: imgLink, Price: price }
        console.log(JsonData);

        $.ajax({
            type: "POST",
            url: '@Url.Action("insertCartItem", "User")',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(JsonData),
            dataType: "json",
            success: function (data) {

                if (data != false) {
                    var shoppingCart = document.getElementById("shoppingCart");

                    while (shoppingCart.firstChild) {
                        shoppingCart.removeChild(shoppingCart.firstChild);
                    }
                    for (var i = 0; i < data.length; i++) {
                        var cartWid = getProductWidget(data[i].ImageLink, data[i].Price);
                        shoppingCart.appendChild(cartWid);

                    }
                }
                else {
                    alert("Can't add into cart");
                }
            }
        });

    }

    return false;
}

$(document).ready(function () {
    $("#joinbtn").click(function () {

        var firstName = $("#firstName").val();
        var lastName = $("#lastName").val();
        var email = $("#email").val();
        var password = $("#password").val();


        var jsonData = { FirstName: firstName, LastName: lastName, Email: email, Password: password };
        $.ajax({
            type: "POST",
            url: '@Url.Action("userSignUp", "User")',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(jsonData),
            dataType: "json",
            success: function (data) {



                if (data) {
                    console.log(data);
                    document.getElementById("loginLink").setAttribute("style", "display: none;");
                    document.getElementById("joinLink").setAttribute("style", "display: none;")
                    document.getElementById("myAccount").innerHTML = firstName + '<i class="fa fa - caret - down">';
                    sessionStorage.setItem('status', 'loggedIn');

                    if (sessionStorage.getItem('status') == 'loggedIn') {
                        document.getElementById("signUpLink").setAttribute("style", "display: block;");
                    }
                }
                else {

                }
            }
        });
        // alert(name + " " + email);
        return false;
    });



   



});


