function setDropDownItem(selector, dataCollection, defaultDropDownItem) {
    debugger
    $(selector).empty();
    $(selector).append($("<option></option>").val(0).html(defaultDropDownItem));
    $.each(dataCollection, function (index, item) {
        $(selector).append($("<option></option>").val(item.value).html(item.text));
    });
}


function showConfirm(message) {
    swal({
        title: "Confirm delete",
        text: message,//"Your will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
      },
        function () {
            swal("Deleted!", "Record deleted", "success");
        }
    );
}