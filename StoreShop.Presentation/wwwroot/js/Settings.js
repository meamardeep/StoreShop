
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
    var url = "/setting/ShowStoreWindow?storeId=" + storeId;
    //$("#btnCreate").click(function (event) {
    $.get(url).done(function (data) {
        $("#divPopupWindow").html(data);
        $("#divPopupWindow").find('.modal').modal('show');

        if (storeId > 0)
            $("#modaltitle").html("Edit stote");

    });
    // });
}

function saveStore() {
    debugger
    var storeModel = new StoreModel();
//alert(JSON.stringify(storeModel));
    var url = "/setting/SaveStore";
    $.post(url, storeModel, function (data) {
        if (data) {
            $("#btnclose").add("class","close");
        }
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
    this.AddressId = $("#AddressId").val();
    this.Address = new function () {
        this.AddressId = $("#Address_AddressId").val();
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

//-------------------------------------Product Type-------------------------

function showProductTypeWindow(productTypeId) {
    debugger
    var url = "/setting/showProductTypeWindow?productTypeId=" + productTypeId;
    $.get(url).done(function (data) {
        $("#divPopupWindow").html(data);
        $("#divPopupWindow").find('.modal').modal('show');
       if (productTypeId > 0)
            $("#modaltitle").html("Edit Product Type");

    });
}

function saveProductType() {
    var productTypeModel = new function () {
        this.ProductTypeId = $("#ProductTypeId").val();
        this.ProductTypeName = $("#ProductTypeName").val();
    }
    var url = "/setting/saveProductType";
    $.post(url, productTypeModel, function (data) {

    });
}

//-----------------------Brand setting script-----------------------
function showBrandWindow(brandId) {
    
    var url = "/setting/showBrandWindow?brandId=" + brandId;
    $.get(url).done(function (data) {
        $("#divPopupWindow").html(data);
        $("#divPopupWindow").find('.modal').modal('show');
        if (brandId > 0)
            $("#modaltitle").html("Edit Brand");

    });
}

function saveBrand() {
    var brandModel = new function () {
        this.BrandId = $("#BrandId").val();
        this.BrandName = $("#BrandName").val();
    }
    var url = "/setting/saveBrand";
    $.post(url, brandModel, function (data) {

    });
}

//-----------------------User setting script-----------------------
function showUserWindow(userId) {
    debugger
    var url = "/setting/showUserWindow?userId=" + userId;
    $.get(url).done(function (data) {
        $("#divPopupWindow").html(data);
        $("#divPopupWindow").find('.modal').modal('show');
        if (userId > 0)
            $("#modaltitle").html("Edit User");

    });
}

function saveUser() {
    var userModel = new function () {
        this.UserId = $("#UserId").val();
        this.BrandName = $("#UserName").val();
    }
    var url = "/setting/saveUser";
    $.post(url, userModel, function (data) {

    });
}