using System;
using System.Collections.Generic;

namespace StoreShop.Data
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Headquarters { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }

    public class StoreModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public bool IsActive { get; set; }
        public long AddressId { get; set; }
        public AddressModel Address { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        public List<DropDownItem> Countries { get; set; }
        public List<DropDownItem> States { get; set; }
        public List<DropDownItem> Cities { get; set; }


    }



    public class AddressModel
    {
        public long AddressId { get; set; }
        public string AddressText { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        public CountryModel CountryModel { get; set; }
        public StateModel StateModel { get; set; }
        public CityModel CityModel { get; set; }
    }

    public class CountryModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public CountryModel CountryModel { get; set; }
    }

    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public StateModel StateModel { get; set; }
    }
}
