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
        private readonly ISettingManagement _settingManagement;
        private readonly ICustomerManagement _customerManagement;
        public SettingController(ISettingManagement settingManagement, ICustomerManagement customerManagement,
            IWebHostEnvironment webHostEnvironment)
        {
            _settingManagement = settingManagement;
            _customerManagement = customerManagement;
            //base.GetUserSession();
        }
        public ActionResult Index()
        {           

            SettingModel settingModel = new SettingModel();
            
            settingModel.StoreModels = _settingManagement.GetStores(SessionManager.CustomerId);

            settingModel.BrandModels = new List<BrandModel>()
            {
                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1},

                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1},
                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1},
                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1},
                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1},
                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1},
                new BrandModel(){BrandName = "Xiaomi", BrandId = 1, IsActive = true, StoreId = 1}
            };
            settingModel.ProductTypeModels = new List<ProductTypeModel>()
            {
             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true},

             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true},
             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true},
             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true},
             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true},
             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true},
             new ProductTypeModel(){ProductTypeId = 1, ProductTypeName ="TV", IsActive = true}
            };
            settingModel.UserModels = new List<UserModel>()
            {
               new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar",  CountryCode = 91   }
            };
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
            model.Countries = _customerManagement.GetCountries(); //new List<DropDownItem>();
            model.States = new List<DropDownItem>();
            model.Cities = new List<DropDownItem>();

            if (storeId > 0)
                model =  _settingManagement.GetStore(storeId);

            return PartialView("~/Views/Setting/Stores/_NewStoreWindow.cshtml", model);
        }

        public IActionResult SaveStore(StoreModel storeModel)
        {
            if (storeModel.StoreId > 0)
                _settingManagement.UpdateStore(storeModel);
            else
                _settingManagement.CreateStore(storeModel);
            return Json(true);
        }

        public IActionResult DeleteStore(int storeId)
        {
            _settingManagement.DeleteStore(storeId);

            return Json(true);
        }
        #endregion
    }
}
