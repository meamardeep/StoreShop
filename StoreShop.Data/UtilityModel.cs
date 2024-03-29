﻿global using Microsoft.AspNetCore.Authentication;
global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Http;

namespace StoreShop.Data
{
    public static class UtilityModel
    {
        public const string PROFILE_CONTAINER = "profile-pics";
        public const string SMS_QUEUE = "storeshopsmsqueue";
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
