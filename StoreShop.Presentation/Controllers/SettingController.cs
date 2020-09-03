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
        public SettingController(IStoreManagement storeManagement, ICustomerManagement customerManagement,
            IUserManagement userManagement)
        {
            _storeManagement = storeManagement;
            _customerManagement = customerManagement;
            _userManagement = userManagement;
        }
        public ActionResult Index()
        {           
            SettingModel settingModel = new SettingModel();            
            settingModel.StoreModels = _storeManagement.GetStores(SessionManager.CustomerId);
            settingModel.BrandModels = _customerManagement.GetBrands(SessionManager.CustomerId);            
            settingModel.ProductTypeModels = _customerManagement.GetProductTypes(SessionManager.CustomerId);
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

            //new Claim();

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
            return Json(true);
        }

        public IActionResult DeleteStore(int storeId)
        {
            _storeManagement.DeleteStore(storeId);

            return Json(true);
        }
        #endregion

        #region ProductType CRUD Controller methods
        public IActionResult ShowProductTypeWindow(int productTypeId)
        {
            ProductTypeModel model = new ProductTypeModel();
            if (productTypeId > 0)
            {
                model = _customerManagement.GetProductType(productTypeId);
            }

            return PartialView("~/Views/Setting/ProductType/_NewProductTypeWindow.cshtml", model);
        }

        public ActionResult SaveProductType(ProductTypeModel productTypeModel)
        {
            if (productTypeModel.ProductTypeId > 0)
                _customerManagement.UpdateProductType(productTypeModel);
            else
                _customerManagement.CreateProductType(productTypeModel);

            return Json(true);
        }
        public ActionResult DeleteProductType(int productTypeId)
        {
            _customerManagement.DeleteProductType(productTypeId);
            return Json(true);
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
                _customerManagement.CreateBrand(brandModel);

            return Json(true);
        }
        public ActionResult DeleteBrand(int brandId)
        {
            _customerManagement.DeleteBrand(brandId);
            return Json(true);
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
                _userManagement.UpdateUser(userModel);
            else
                _userManagement.CreateUser(userModel, SessionManager.CustomerId, SessionManager.UserId);
            return Json(true);
        }
        public ActionResult DeleteUser(int userId)
        {
            _userManagement.DeleteUser(userId);
            return Json(true);
        }
        #endregion
    }
}
