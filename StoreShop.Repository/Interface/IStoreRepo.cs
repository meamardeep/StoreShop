using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.Repository
{
    public interface IStoreRepo
    {
        IEnumerable<Store> GetStores(int customerId);
        Store GetStore(int storeId);
        void CreateStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Store store);
        
    }
}
