using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreShop.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreShopDataContext _database;
        public ProductRepo(StoreShopDataContext storeshopDataContext)
        {
            _database = storeshopDataContext;
        }
        public IEnumerable<MasProductType> GetMasProductTypes()
        {
            var sql = from m in _database.MasProductTypes
                      select m ;
            return sql;
        }

        #region Product Type
        public List<CustomerProductType> GetProductTypes(int customerId)
        {
            return _database.CustomerProductTypes
                .Include(m => m.MasProductType)
                .Where(p => p.CustomerId == customerId).ToList();
        }

        public CustomerProductType GetProductType(int productTypeId)
        {
            return _database.CustomerProductTypes.Where(p => p.CustomerProductTypeId == productTypeId).FirstOrDefault();
        }

        public void CreateProductType(CustomerProductType productType)
        {
            _database.CustomerProductTypes.Add(productType);
            try
            {
                _database.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductType(CustomerProductType productType)
        {
            _database.Entry(productType).State = EntityState.Modified;
            try
            {
                _database.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProductType(CustomerProductType productType)
        {
            _database.Remove(productType).State = EntityState.Deleted;
            try
            {
                _database.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Clothing
        
        #endregion



        #region Electrnics

        #endregion



        #region Mobile

        #endregion


        #region Laptop

        #endregion

    }
}
