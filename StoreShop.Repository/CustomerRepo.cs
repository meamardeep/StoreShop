using StoreShop.DataAccess;
using StoreShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreShop.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly StoreShopDataContext _database;
        public CustomerRepo(StoreShopDataContext storeShopDataContext)
        {
            _database = storeShopDataContext;
        }
       
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
            _database.SaveChanges();
            return address.AddressId;
        }

    }
}
