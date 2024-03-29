﻿using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.Repository
{
    public interface ICustomerRepo
    {
        #region Address
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates(int countryId);
        IEnumerable<City> GetCities(int stateId);
        
        long CreateAddress(Address address);
        Address GetAddress(long addressId);
        void UpdateAddress(Address address);
        void DeleteAddress(Address address);
        #endregion

        #region Brand
        List<Brand> GetBrands(int customerId);
        Brand GetBrand(int brandId);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
        #endregion
    }
}
