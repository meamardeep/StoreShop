using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace StoreShop.Data
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public long CellNo { get; set; }
        public int? OTP { get; set; }
        public bool? LoginAttemptCounter { get; set; }
        public int RoleId { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        
        public int CountryCode { get; set; }                
        public List<int> CountryCodes { get; set; }
        
    }

    public class UserStoreMapping
    {
        public long UserStoreMappingId { get; set; }
        public long UserId { get; set; }
        public int StoreId { get; set; }

        public UserModel User { get; set; }
        public StoreModel Store { get; set; }
    }

    public class UserSessionModel
    {
       public int SessionCustomerId { get; set; }
        public long SessionUserId { get; set; }
        //public int SessionStoreId { get; set; }
    }

}
