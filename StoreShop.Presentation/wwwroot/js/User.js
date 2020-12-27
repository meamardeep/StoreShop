
function SaveUserProfile() {
    var data = new FormData();
    data.append("ProfilePhoto", document.getElementById("ProfilePhoto").files[0]); // $("#ProfilePhoto")[0].file[0];
    data.append("UserId", $("#UserId").val());
    data.append("UserName", $("#UserName").val());
    data.append("Password", $("#Password").val());
    data.append("FirstName", $("#FirstName").val());
    data.append("LastName", $("#LastName").val());
    data.append("GenderId", $("#GenderId").val());
    data.append("CellNo", $("#CellNo").val());
    data.append("DOB", $("#DOB").val());

    var url = "/user/saveUserProfile";
    $.ajax({
        type: "POST",
        url: url,
        contentType: false,
        processData: false,
        data: data,
        success: function (message) {
            toastr.success("User saved successfully.", 'Success', {timeOut :3000});
        },
        error: function () {
            alert("There was an error uploading the file!");
        }
    });
    
}