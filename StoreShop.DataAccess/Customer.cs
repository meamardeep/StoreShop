namespace StoreShop.DataAccess
{
    [Table("CustomerDetails")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Headquarters { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }

    [Table("StoreDetails")]
    public class Store
    {
       // [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public bool IsActive { get; set; }

        //[ForeignKey("Address")]
        public long AddressId { get; set; }
        public Address Address { get; set; }

        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
   

    [Table("Addresses")]
    public class Address
    {
        //[Key]
        public long AddressId { get; set; }
        public string AddressText { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [ForeignKey("City")]
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
