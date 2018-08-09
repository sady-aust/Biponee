function loadProduct() {
    var nameArray = [];
    $.ajax({
        type: "POST",
        url: '@Url.Action("allProduct", "User")',
        contentType: "application/json;charset=utf-8",

        dataType: "json",
        success: function (data) {

            if (data != null) {
                console.log(data);
                var nameArray = [];
                for (var i = 0; i < data.length; i++) {
                    nameArray.push(data[i].ProductName);
                }

            }

        }
    });





    return nameArray;
}

function getProductWidget(productName, price, imgLink) {
    var productWidgetDiv = document.createElement("div");
    productWidgetDiv.setAttribute("class", "product product-widget");

    var productThumb = document.createElement("div");
    productThumb.setAttribute("class", "product-thumb");

    var img = document.createElement("img");
    img.setAttribute("src", "/" + imgLink + ".jpeg");

    productThumb.appendChild(img);


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

    productWidgetDiv.appendChild(productThumb);
    productWidgetDiv.appendChild(bodyDiv);
    return productWidgetDiv;

}



$(window).on('load', function () {
    if (localStorage.getItem('status') == 'loggedIn') {
        console.log("Loggedin");
        document.getElementById("loginLink").setAttribute("style", "display: none;");
        document.getElementById("joinLink").setAttribute("style", "display: none;");
        document.getElementById("signOutLink").setAttribute("style", "display: block");
        document.getElementById("myProfileLink").setAttribute("style", "display: block");
        document.getElementById("myAccount").innerHTML = localStorage.getItem("FirstName");

    }
    var input = document.getElementById("myInputext");
    var awsomecomplete = new Awesomplete(input);


    $.ajax({
        type: "POST",
        url: '@Url.Action("allProduct", "User")',
        contentType: "application/json;charset=utf-8",

        dataType: "json",
        success: function (data) {

            if (data != null) {

                var nameArray = [];
                for (var i = 0; i < data.length; i++) {
                    nameArray.push(data[i].ProductName);
                }




            }
            awsomecomplete.list = nameArray;
        }

    });


    var JsonData = { UserID: parseInt(localStorage.getItem("userID")) }


    $.ajax({
        type: "POST",
        url: '@Url.Action("getAllCartItem", "User")',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(JsonData),
        dataType: "json",
        success: function (data) {

            if (data != null) {
                console.log(data);
                var shoppingCart = document.getElementById("userShoppingcart");
                console.log(shoppingCart);
                clearCartItem();
                showCartItem(data);
                $(".qty").text(data.length);



            }

        }
    });


});

$('#signOutLink').click(function () {
    document.getElementById("loginLink").setAttribute("style", "display: block;");
    document.getElementById("joinLink").setAttribute("style", "display: block;");
    document.getElementById("signOutLink").setAttribute("style", "display: none");
    document.getElementById("myProfileLink").setAttribute("style", "display: none");
    document.getElementById("myAccount").innerHTML = "My Account";
    localStorage.setItem('status', 'signout');
    localStorage.setItem('userID', null);
    localStorage.setItem('FirstName', null);

    clearCartItem();
    $(".qty").empty();

});
$("#loginBtn").click(function () {


    var email = $("#loginEmail").val();
    var password = $("#loginPassword").val();


    var jsonData = { Email: email, Password: password };
    $.ajax({
        type: "POST",
        url: '@Url.Action("userLogIn", "User")',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(jsonData),
        dataType: "json",
        success: function (data) {

            if (data != null) {

                localStorage.setItem('status', 'loggedIn');
                localStorage.setItem('userID', data.Id);
                localStorage.setItem('FirstName', data.FirstName);


                if (localStorage.getItem('status') == 'loggedIn') {
                    document.getElementById("loginLink").setAttribute("style", "display: none;");
                    document.getElementById("joinLink").setAttribute("style", "display: none;");
                    document.getElementById("signOutLink").setAttribute("style", "display: block");
                    document.getElementById("myProfileLink").setAttribute("style", "display: block");
                    document.getElementById("myAccount").innerHTML = data.FirstName + '<i class="fa fa - caret - down">';

                }
                $("#loginModal").modal('hide');

                var JsonData = { UserID: parseInt(localStorage.getItem("userID")) }


                $.ajax({
                    type: "POST",
                    url: '@Url.Action("getAllCartItem", "User")',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(JsonData),
                    dataType: "json",
                    success: function (data) {

                        if (data != null) {
                            console.log(data);
                            var shoppingCart = document.getElementById("userShoppingcart");
                            console.log(shoppingCart);

                            clearCartItem();
                            showCartItem(data);
                            $(".qty").text(data.length);

                        }

                    }
                });
            }
            else {
                alert("Email and password doesnot match");
            }
        }
    });
    // alert(name + " " + email);
    return false;
});


$("#signUpbtn").click(function () {

    console.log("Clicked");
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



            if (data != 'false') {

                localStorage.setItem('status', 'loggedIn');
                localStorage.setItem('userID', data.Id);
                localStorage.setItem('FirstName', data.FirstName);


                if (localStorage.getItem('status') == 'loggedIn') {
                    document.getElementById("loginLink").setAttribute("style", "display: none;");
                    document.getElementById("joinLink").setAttribute("style", "display: none;");
                    document.getElementById("signOutLink").setAttribute("style", "display: block");
                    document.getElementById("myProfileLink").setAttribute("style", "display: block");
                    document.getElementById("myAccount").innerHTML = data.FirstName + '<i class="fa fa - caret - down">';

                }
                $("#signupmodal").modal('hide');

            }
            else {
                alert("Please Try again");
            }
        }
    });
    // alert(name + " " + email);
    return false;
});

function showItems() {
    document.location = '@Url.Action("Products", "User")' + '?' + 'id=' + parseInt(document.getElementById("sectionId").value);
}

function goToProductPage(id) {
    document.location = '@Url.Action("ProductPage", "User")' + '?' + 'id=' + parseInt(id);
}
function serachResult() {
    var productName = document.getElementById("myInputext").value;
    if (productName == "" || productName == null) {
        alert("Please enter a product name");
    }
    else {
        document.location = '@Url.Action("Products", "User")' + '?' + 'id=-1&' + 'ProductName=' + productName;
    }

}

function gotoSection(id) {
    document.location = '@Url.Action("Products", "User")' + '?' + 'id=' + parseInt(id);
}

function searchByCategory(sectionid, category) {
    // alert("Clicked");

    document.location = '@Url.Action("Products", "User")' + '?' + 'id=' + parseInt(sectionid) + "&category=" + category + "&searchInCategory=true";
}

function addToCart(id) {
    if ((localStorage.getItem('status') != 'loggedIn')) {
        alert("Please Log in First");
    }
    else {

        var productId = parseInt(id);
        var quantity = 1;
        var userId = localStorage.getItem('userID');
        var status = 0;
        var size = null;


        var JsonData = { ProductId: productId, Qunaity: quantity, UserID: userId, Status: status, Size: size }


        $.ajax({
            type: "POST",
            url: '@Url.Action("insertCartItem", "User")',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(JsonData),
            dataType: "json",
            success: function (data) {

                if (data != false) {
                    showCartItem(data);
                }
                else {
                    alert("Can't add into cart");
                }
            }
        });

    }

    return false;
}


function clearCartItem() {
    $("#userShoppingcart").empty();
}

function showCartItem(data) {

    console.log(data)
    var shoppingCart = document.getElementById("userShoppingcart");
    console.log(shoppingCart);
    clearCartItem();
    $(".qty").text(data.length);


    for (var i = 0; i < data.length; i++) {

        var cartWid = getProductWidget(data[i].ProductName, data[i].Price, data[i].ImageLink);
        shoppingCart.appendChild(cartWid);


    }

    $(".qty").text(data.length);
}


