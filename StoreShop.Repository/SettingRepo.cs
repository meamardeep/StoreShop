using Microsoft.EntityFrameworkCore;
using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreShop.Repository
{
    public class SettingRepo : ISettingRepo
    {

        private readonly StoreShopDataContext _database;
        public SettingRepo(StoreShopDataContext storeshopDataContext )
        {
            _database = storeshopDataContext;
        }
        
        public Store GetStore(int storeId)
        {
            var sql = from s in _database.Stores 
                      .Include(a=>a.Address)//.ThenInclude(c=>c.Country).ThenInclude(s=>s.)
                      where s.StoreId == storeId select s;
            return sql.FirstOrDefault();
        }

        public IEnumerable<Store> GetStores(int customerId)
        {
            var sql = from s in _database.Stores where s.CustomerId == customerId select s;
            return sql;                      
        }

        public void CreateStore(Store store)
        {
            _database.Stores.Add(store);
            _database.SaveChanges();
        }

        public void DeleteStore(Store store)
        {
            _database.Stores.Remove(store);
        }

        public void UpdateStore(Store store)
        {
            _database.Stores.Add(store).State = EntityState.Modified;
            _database.SaveChanges();
        }
    }
}
