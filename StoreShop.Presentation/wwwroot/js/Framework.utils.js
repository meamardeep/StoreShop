function setDropDownItem(selector, dataCollection,defaultDropDownItem) {
    $(selector).empty();
    $(selector).append($("<option></option>").val(0).html(defaultDropDownItem));
    $.each(dataCollection, function (index, item) {
        $(selector).append($("<option></option>").val(item.value).html(item.text));
    });
}
