
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
    let title = storeId > 0 ? "Edit store" : "New Store";
    showAjaxPopup(url, title);
}

function saveStore() {
    var storeModel = new StoreModel();
    var url = "/setting/SaveStore";
    $.post(url, storeModel, function (data) {
        if (data) {
            closePopup();
            showToastMessage("Store saved successfully");
        }
    });  
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
    let url = "/setting/showProductTypeWindow?productTypeId=" + productTypeId;
    let title = productTypeId > 0 ? "Edit Product Type" : "New Product Type"
    showAjaxPopup(url, title);
}

function saveProductType() {
    var productTypeModel = new function () {
        this.ProductTypeId = $("#ProductTypeId").val();
        this.ProductTypeName = $("#ProductTypeName").val();
    }
    var url = "/setting/saveProductType";
    $.post(url, productTypeModel, function (data) {
        closePopup();
        showToastMessage("Product Type saved successfully");
        $("#divProductTypeList").html(data);
    });
}

//-----------------------Brand setting script-----------------------
function showBrandWindow(brandId) { 
    var url = "/setting/showBrandWindow?brandId=" + brandId;
    let title = brandId > 0 ? "Edit Brand" : "New Brand";
    showAjaxPopup(url, title);
}

function saveBrand() {
    var brandModel = new function () {
        this.BrandId = $("#BrandId").val();
        this.BrandName = $("#BrandName").val();
    }
    var url = "/setting/saveBrand";
    $.post(url, brandModel, function (data) {
        closePopup();
        showToastMessage("Brand saved successfully");
    });
}

function deleteBrand(brandId) {
    showConfirm("Are you sure want to delete this brand");
}
//-----------------------User setting script-----------------------

function showUserWindow(userId) {
    let url = "/setting/showUserWindow?userId=" + userId;
    let title = userId > 0 ? "Edit User" : "New User";
    showAjaxPopup(url, title); 
}

function saveUser() {
    var userModel = new function () {
        this.UserId = $("#UserId").val();
        this.BrandName = $("#UserName").val();
    }
    var url = "/setting/saveUser";
    $.post(url, userModel, function (data) {
        closePopup();
        showToastMessage("User saved successfully");
    });
}




