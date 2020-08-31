///<reference/>

function showSettingData() {
    $.post("/setting/DatatableView", null, function (response) {
        alert();
        $("#tablSettingId").dataTable({
            data: response,
            column: [
                { data: "userName" },
                { data: "cellNo" },
                { data: "firstName" }
            ]
        });
    });
}

//------------------------------------------store setting-------------------------------------------------------
function showStoreWindow(storeId) {
    if (storeId > 0)
        $("#modaltitle").html("Edit stote");

    var url = "/setting/ShowStoreWindow?storeId=" + storeId;

    //$("#btnCreate").click(function (event) {
    $.get(url).done(function (data) {
        $("#divStoreWindow").html(data);
        $("#divStoreWindow").find('.modal').modal('show');
    });
    // });
}

function saveStore() {
    debugger
    var storeModel = new StoreModel();

    alert(JSON.stringify(storeModel));
    var url = "/setting/SaveStore";
    $.post(url, storeModel, function () {
    });
    
    //$.ajax({
    //    type: "POST",
    //    url: url,
    //    contentType: false,
    //    processData: false,
    //    data: storeModel,
    //    success: function (message) {
    //    },
    //    error: function () {
    //        alert("There was error uploading files!");
    //    }
    //});
}


function StoreModel() {
    this.StoreId = $("#StoreId").val();
    this.StoreName = $("#StoreName").val();
    this.Address = new function () {
        this.AddressText = $("#Address_AddressText").val();
        this.CountryId = $("#Address_CountryId").val();
        this.StateId = $("#Address_StateId").val();
        this.CityId = $("#Address_CityId").val();
    }
}


function deleteStore(StoreId) {

}

function getStates() {

    var countryId = $("#Address_CountryId").val();
    $.post("/setting/GetStates", { countryId: countryId }, function (dropDownData) {
        //alert(JSON.stringify(dropDownData));
        setDropDownItem("#Address_StateId", dropDownData, "--Select State--");
    })
}
function getCities() {
    var stateId = $("#Address_StateId").val();
    $.post("/setting/GetCities", { stateId: stateId }, function (dropDownData) {
        //alert(JSON.stringify(dropDownData));
        setDropDownItem("#Address_CityId", dropDownData, "--Select City--");
    })
}