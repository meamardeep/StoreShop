using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace StoreShop.Presentation.Controllers
{
    public class SettingController : ControllerBase
    {
        private readonly IStoreManagement _storeManagement;
        private readonly ICustomerManagement _customerManagement;
        private readonly IUserManagement _userManagement;
        private readonly IProductManagement _productManagement;

        private readonly MasterDataController masterDataController;
        UserSessionModel userSessionModel;
        public SettingController(IStoreManagement storeManagement, ICustomerManagement customerManagement,
            IUserManagement userManagement,IProductManagement productManagement, MasterDataController masterDataController)
        {
            _storeManagement = storeManagement;
            _customerManagement = customerManagement;
            _userManagement = userManagement;
            _productManagement = productManagement;
            this.masterDataController = masterDataController;
            userSessionModel = GetUserSession();
        }
        public ActionResult Index()
        {
            SettingModel settingModel = new SettingModel();            
            settingModel.StoreModels = _storeManagement.GetStores(SessionManager.CustomerId);
            settingModel.BrandModels = _customerManagement.GetBrands(SessionManager.CustomerId);            
            settingModel.ProductTypeModels = _productManagement.GetProductTypes(SessionManager.CustomerId);
            settingModel.UserModels = _userManagement.GetUsers(SessionManager.CustomerId);
            return View(settingModel);
        }

        public List<UserModel> DatatableView()
        {
            List<UserModel> userModels= new List<UserModel>()
            {
               new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },

                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", CountryCode = 91   }
            };
            return userModels;
        }

        public List<DropDownItem> GetStates(int countryId)
        {
             List<DropDownItem> states = _customerManagement.GetStates(countryId);
            return states;
        }
        public List<DropDownItem> GetCities(int stateId)
        {
            List<DropDownItem> states = _customerManagement.GetCities(stateId);
            return states;
        }

        #region Store CRUD
        public ActionResult ShowStoreWindow(int storeId)
        {
            StoreModel model = new StoreModel();
            model.States = new List<DropDownItem>();
            model.Cities = new List<DropDownItem>();

            if (storeId > 0)
            {
                model = _storeManagement.GetStore(storeId);
                model.States = _customerManagement.GetStates(model.Address.CountryId);
                model.Cities = _customerManagement.GetCities(model.Address.StateId);
            }
            model.Countries = _customerManagement.GetCountries(); //new List<DropDownItem>();

            return PartialView("~/Views/Setting/Stores/_NewStoreWindow.cshtml", model);
        }

        public IActionResult SaveStore(StoreModel storeModel)
        {
            if (storeModel.StoreId > 0)
                _storeManagement.UpdateStore(storeModel);
            else
                _storeManagement.CreateStore(storeModel, ControllerBase.GetUserSession());

            List<StoreModel> storeModels = _storeManagement.GetStores(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/Stores/_StoreList.cshtml", storeModels);
        }

        public IActionResult DeleteStore(int storeId)
        {
            _storeManagement.DeleteStore(storeId);
            List<StoreModel> storeModels = _storeManagement.GetStores(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/Stores/_StoreList.cshtml", storeModels);
        }
        #endregion

        #region ProductType CRUD Controller methods
        public IActionResult ShowProductTypeWindow(int productTypeId)
        {
            CustomerProductTypeModel model = new CustomerProductTypeModel();
            model.ProductTypes = _productManagement.GetMasProductTypes();
            //if (productTypeId > 0)
            //{
            //    model = _customerManagement.GetProductType(productTypeId);
            //}

            return PartialView("~/Views/Setting/ProductType/_NewProductTypeWindow.cshtml", model);
        }

        public ActionResult SaveProductType(CustomerProductTypeModel productTypeModel)
        {
            if (productTypeModel.CustomerProductTypeId > 0)
                _productManagement.UpdateProductType(productTypeModel);
            else
            {
                productTypeModel.CustomerId = SessionManager.CustomerId;
                _productManagement.CreateProductType(productTypeModel);
            }
            List<CustomerProductTypeModel> productTypeModels = _productManagement.GetProductTypes(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/ProductType/_ProductTypeList.cshtml", productTypeModels);
        }
        public ActionResult DeleteProductType(int productTypeId)
        {
            _productManagement.DeleteProductType(productTypeId);
            List<CustomerProductTypeModel> productTypeModels = _productManagement.GetProductTypes(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/ProductType/_ProductTypeList.cshtml", productTypeModels);
        }
        #endregion

        #region Brand CRUD Controller methods
        public IActionResult ShowBrandWindow(int brandId)
        {
            BrandModel model = new BrandModel();
            if (brandId > 0)
            {
                model = _customerManagement.GetBrand(brandId);
            }

            return PartialView("~/Views/Setting/Brand/_NewBrandWindow.cshtml", model);
        }

        public ActionResult SaveBrand(BrandModel brandModel)
        {
            if (brandModel.BrandId > 0)
                _customerManagement.UpdateBrand(brandModel);
            else
            {
                brandModel.CustomerId = userSessionModel.SessionCustomerId;
                _customerManagement.CreateBrand(brandModel);
            }
            List<BrandModel> brandModels = _customerManagement.GetBrands(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/Brand/_BrandList.cshtml", brandModels);
        }
        public ActionResult DeleteBrand(int brandId)
        {
            _customerManagement.DeleteBrand(brandId);

            List<BrandModel> brandModels = _customerManagement.GetBrands(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/Brand/_BrandList.cshtml", brandModels);
        }
        #endregion

        #region User Setting CRUD
        public ActionResult ShowUserWindow(long userId)
        {
            UserModel model = new UserModel();
            if (userId > 0)
                model = _userManagement.GetUser(userId);
            return PartialView("~/Views/Setting/User/_NewUserWindow.cshtml", model);
        }

        public ActionResult SaveUser(UserModel userModel)
        {
            if (userModel.UserId > 0)
                _userManagement.UpdateUser(userModel,SessionManager.UserId);
            else
                _userManagement.CreateUser(userModel, SessionManager.CustomerId, SessionManager.UserId);

            List<UserModel> userModels = _userManagement.GetUsers(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/User/_UserList.cshtml", userModels);
        }
        public ActionResult DeleteUser(int userId)
        {
            _userManagement.DeleteUser(userId);
            List<UserModel> userModels = _userManagement.GetUsers(SessionManager.CustomerId);
            return PartialView("~/Views/Setting/User/_UserList.cshtml", userModels);
        }
        #endregion

        #region New product
        public IActionResult ShowNewProductWindow(long productId)
        {
            ProductModel model = new ProductModel();
            
            return PartialView("~/Views/Setting/Product/_NewProductWindow.cshtml", model);
        }
        #endregion
    }
}
