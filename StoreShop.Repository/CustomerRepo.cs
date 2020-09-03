using StoreShop.DataAccess;
using StoreShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace StoreShop.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly StoreShopDataContext _database;
        public CustomerRepo(StoreShopDataContext storeShopDataContext)
        {
            _database = storeShopDataContext;
        }

        #region Address CRUD
        public IEnumerable<Country> GetCountries()
        {
            var sql = from c in _database.Countries select c;
            return sql;
        }
        public IEnumerable<State> GetStates(int countryId)
        {
            var sql = from s in _database.States where s.CountryId == countryId select s;
            return sql;
        }
        public IEnumerable<City> GetCities(int stateId)
        {
            var sql = from c in _database.Cities where c.StateId == stateId select c;
            return sql;
        }

        public long CreateAddress(Address address)
        {
             _database.Addresses.Add(address);
            try
            {
                _database.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return address.AddressId;
        }
        public Address GetAddress(long addressId)
        {
            //Method: 1
            return  _database.Addresses.Where(a => a.AddressId == addressId).FirstOrDefault();
            
            //Method: 2
            //var sql = from a in _database.Addresses
            //          where a.AddressId == addressId
            //          select a;
            //return sql.FirstOrDefault();
        }
        public void UpdateAddress(Address address)
        {
            _database.Entry(address).State = EntityState.Modified;
            _database.SaveChanges();
        }
        public void DeleteAddress(Address address)
        {
            _database.Remove(address).State = EntityState.Deleted;
            _database.SaveChanges();
        }
        #endregion


        #region Product Type
        public List<ProductType> GetProductTypes(int customerId)
        {
            return _database.ProductTypes.Where(p=>p.CustomerId == customerId).ToList();
        }

        public ProductType GetProductType(int productTypeId)
        {
              return _database.ProductTypes.Where(p => p.ProductTypeId == productTypeId).FirstOrDefault();
        }

        public void CreateProductType(ProductType productType)
        {
            _database.ProductTypes.Add(productType);
            try
            {
                _database.SaveChanges();

            }
            catch (Exception) {
                throw;
            }
        }

        public void UpdateProductType(ProductType productType)
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

        public void DeleteProductType(ProductType productType)
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

        #region
        public List<Brand> GetBrands(int customerId)
        {
            return _database.Brands.Where(b => b.CustomerId == customerId).ToList();
        }

        public Brand GetBrand(int brandId)
        {
            return _database.Brands.Where(p => p.BrandId == brandId).FirstOrDefault();
        }

        public void CreateBrand(Brand brand)
        {
            _database.Brands.Add(brand);
            _database.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            _database.Entry(brand).State = EntityState.Modified;
            try
            {
                _database.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBrand(Brand brand)
        {
            _database.Remove(brand).State = EntityState.Deleted;
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


    }
}
