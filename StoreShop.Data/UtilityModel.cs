using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.Data
{
    public class UtilityModel
    {
    }

    public class DropDownItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public enum UserRole
    {
        SuperAdmin = 1, StoreAdmin, EndUser
    }

    public enum Module
    {
        Setting = 1
    }

    public enum ProductType
    {
        Referigerator = 1,
        Mobile = 2,
        Shirts = 3
    }

    public enum ProductCategaryType
    {
        Appliances = 1,
        Electroni = 2,
        Clothing = 3,
        Groceries = 4
    }
    public class ExceptionLogModel
    {
        public long LogId { get; set; }
        public string Message { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
