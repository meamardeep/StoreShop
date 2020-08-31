using StoreShop.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.BusinessLogic
{
    public interface ICustomerManagement
    {
        List<DropDownItem> GetStates(int countryId);
        List<DropDownItem> GetCities(int stateId);
        List<DropDownItem> GetCountries();
        long CreateAddress(AddressModel addressModel);

    }
}
