$(window).on('load', function () {
    if (localStorage.getItem('status') == 'loggedIn') {
        console.log("Loggedin");
        document.getElementById("loginLink").setAttribute("style", "display: none;");
        document.getElementById("joinLink").setAttribute("style", "display: none;");
        document.getElementById("signOutLink").setAttribute("style", "display: block");
        document.getElementById("myProfileLink").setAttribute("style", "display: block");
        document.getElementById("myAccount").innerHTML = localStorage.getItem("FirstName");

    }
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

});
$("#loginBtn").click(function () {

    console.log("Clicked");
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

            console.log(data);

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
            }
            else {
                alert("Email and password doesnot match");
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
