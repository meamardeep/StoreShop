using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreShop.DataAccess
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsActive { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }

    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
   

    [Table("Addresses")]
    public class Address
    {
        [Key]
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
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }
    }

    [Table("States")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }

}
