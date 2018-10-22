



$(window).on('load', function () {
    if (localStorage.getItem('status') == 'loggedIn') {
        console.log("Loggedin");
        document.getElementById("loginLink").setAttribute("style", "display: none;");
        document.getElementById("joinLink").setAttribute("style", "display: none;");
        document.getElementById("signOutLink").setAttribute("style", "display: block");
        document.getElementById("myProfileLink").setAttribute("style", "display: block");
        document.getElementById("myAccount").innerHTML = localStorage.getItem("FirstName");

    }
   


    showCartItem(JSON.parse(localStorage.getItem('cart')).products);
    showSelectedItem();


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

    localStorage.clear();
    clearCartItem();
    $(".qty").empty();
    document.location = '@Url.Action("Index", "User")'

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
                    document.getElementById("viewOrdersLink").setAttribute("style", "display: block");
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

function addToCart(id, name, img, price) {
    if ((localStorage.getItem('status') != 'loggedIn')) {
        alert("Please Log in First");
    }
    else {

        var productId = parseInt(id);
        var quantity = 1;
        var userId = localStorage.getItem('userID');
        var status = 0;
        var size = null;


        var JsonData = { ProductId: productId, ProductName: name, Image: img, Price: price, Qunaity: quantity, UserID: userId, Status: status, Size: size }

        if (localStorage && localStorage.getItem('cart')) {
            var cart = JSON.parse(localStorage.getItem('cart'));
            cart.products.push(JsonData);

            localStorage.setItem('cart', JSON.stringify(cart));

            console.log(localStorage.getItem('cart'));
            showCartItem(JSON.parse(localStorage.getItem('cart')).products);
        }
        else {
            console.log("Not define");
        }

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


   
    $(".qty").text(data.length);
}

function showSelectedItem() {
    var tableBody = document.getElementById("tableBody");
    var cartItem = JSON.parse(localStorage.getItem('cart')).products;
   
    for (var i = 0; i < cartItem.length; i++) {

        if (cartItem[i].Size == null) {
            tableBody.innerHTML += `<tr>
                                     <td>
                                        <img src =`+ cartItem[i].Image + ` height = "50" widht = "50">   
                                     </td>
                                    <td>` + cartItem[i].ProductId + `</td>
                                   <td>`+ cartItem[i].ProductName + `</td>
                                    <td>Not Applicable</td>
                                    <td>
                                   <input type = "number" onchange="updateInput(this.value,`+ i + `)" min= "1" value =` + cartItem[i].Qunaity + `>
                                </td>
                                 <td>`+ cartItem[i].Price + `</td></tr>`
        }
        else {
            tableBody.innerHTML += `<tr>
                                     <td>
                                        <img src =`+ cartItem[i].Image + ` height = "50" widht = "50">   
                                     </td>
                                    <td>` + cartItem[i].ProductId + `</td>
                                   <td>`+ cartItem[i].ProductName + `</td>
                                    <td>`+ cartItem[i].Size + `</td>
                                    <td>
                                    <input type = "number" onchange="updateInput(this.value,`+ i + `)" min= "1" value =` + cartItem[i].Qunaity + `>
                                </td>
                                    <td>`+ cartItem[i].Price + `</td></tr>`
        }
    }

    tableBody.innerHTML += `<tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><button class="primary-btn" onclick="proceedCheckout()">Proceed to checkout</button></td>
                            </tr>`;

    

}

function updateInput(value, index) {
    var cart = JSON.parse(localStorage.getItem('cart'));
    cart.products[index].Qunaity = value;
    localStorage.setItem('cart', JSON.stringify(cart));

}



