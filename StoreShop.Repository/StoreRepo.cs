using Microsoft.EntityFrameworkCore;
using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreShop.Repository
{
    public class StoreRepo : IStoreRepo
    {

        private readonly StoreShopDataContext _database;
        public StoreRepo(StoreShopDataContext storeshopDataContext )
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
            var sql = from s in _database.Stores 
                      .Include(a=>a.Address).ThenInclude(c=>c.City).ThenInclude(s=>s.State).ThenInclude(c=>c.Country)
                      where s.CustomerId == customerId select s;
            return sql;                      
        }

        public void CreateStore(Store store)
        {
            _database.Stores.Add(store).State = EntityState.Added; //_database.Stores.Add(store);
            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void DeleteStore(Store store)
        {
            _database.Stores.Remove(store);
            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateStore(Store store)
        {
            _database.Entry(store).State = EntityState.Modified;

            //_database.Stores.Update(store).State = EntityState.Modified;
            try 
            {
                _database.SaveChanges();
            }

            catch( Exception)
            {
                throw;
            }
        }
    }
}
