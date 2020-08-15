using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Data
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public AddressModel AddressModel { get; set; }
    }

    public class AddressModel
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        
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
