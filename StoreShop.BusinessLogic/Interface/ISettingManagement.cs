using System;
using System.Collections.Generic;
using System.Text;
using StoreShop.Data;
namespace StoreShop.BusinessLogic
{
    public interface ISettingManagement
    {
        List<StoreModel> GetStores(int customerId);
        StoreModel GetStore(int storeId);
        void CreateStore(StoreModel storeModel);
        void UpdateStore(StoreModel storeModel);
        void DeleteStore(int storeId);
    }
}
