using Microsoft.AspNetCore.Mvc;
using StoreShop.Data;
using System;
using System.Collections.Generic;

namespace StoreShop.Presentation.Controllers
{
    public class SettingController : Controller
    {
        public SettingController()
        {

        }
        public ActionResult Index()
        {
            SettingModel settingModel = new SettingModel();
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
            settingModel.StoreModels = new List<StoreModel>()
            {
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },

             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 },
             new StoreModel(){StoreId = 1, StoreName = "BTM, Bangalore", CustomerId = 1, IsActive = true, AddressId = 1 }

            };
            settingModel.UserModels = new List<UserModel>()
            {
               new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", StoreId = 1, CountryCode = 91   },

                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", StoreId = 1, CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", StoreId = 1, CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", StoreId = 1, CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", StoreId = 1, CountryCode = 91   },
                 new UserModel(){ UserId = 1, UserName = "meamardeep", CellNo = 8088506025, FirstName = "Amardeep",
                    LastName = "Kumar", StoreId = 1, CountryCode = 91   }
            };
            return View(settingModel);
        }
    }
}
