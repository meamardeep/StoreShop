using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.DataAccess
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public Address AddressModel { get; set; }
    }

    [Table("Addresses")]
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressText { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }

    [Table("Countries")]
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    [Table("States")]
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    [Table("Cities")]
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }

}
