using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.Repository
{
    public interface ICustomerRepo
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates(int countryId);
        IEnumerable<City> GetCities(int stateId);
        long CreateAddress(Address address);
    }
}
