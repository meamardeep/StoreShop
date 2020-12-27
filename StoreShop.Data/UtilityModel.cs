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

     public enum Role
    {
        SuperAdmin = 1,StoreAdmin,EndUser
    }

    public enum Module
    { 
        Setting = 1
    }

    public class ExceptionLogModel
    {
        public long LogId { get; set; }
        public string Message { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
