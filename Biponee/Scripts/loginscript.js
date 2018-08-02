$("#loginBtn").click(function () {
    console.log('clicked');

    var email = $("#loginEmail").val();
    var password = $("#loginPassword").val();

    console.log(email);
    var jsonData = { Email: email, Password: password };
    $.ajax({
        type: "POST",
        url: '@Url.Action("userLogIn", "User")',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(jsonData),
        dataType: "json",
        success: function (data) {

            console.log(data)
            /*   if (data != null) {
                   document.getElementById("loginLink").setAttribute("style", "display: none;");
                   document.getElementById("joinLink").setAttribute("style", "display: none;")
                   document.getElementById("myAccount").innerHTML = data.FirstName + '<i class="fa fa - caret - down">';
                   sessionStorage.setItem('status', 'loggedIn');
                   sessionStorage.setItem('userID', data.Id);

                   if (sessionStorage.getItem('status') == 'loggedIn') {
                       document.getElementById("signUpLink").setAttribute("style", "display: block;");
                   }
                   $("#loginModal").modal('hide');
               }
               else {
                   alert("Email and password doesnot match");
               }*/
        }
    });
    // alert(name + " " + email);
    return false;
});