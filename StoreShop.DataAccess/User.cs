using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreShop.DataAccess
{
    [Table("UserDetails")]
    public class User
    { 
        [Key]
        public long UserId { get; set; }
        public  string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long CellNo { get; set; }
        public int? OTP { get; set; }
        public bool? LoginAttemptCounter { get; set; }
        public DateTime? DOB { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public int? GenderId { get; set; }
    }

    public class UserPhoto
    {
        [Key]
        public long ProfilePhotoId { get; set; }
        public  byte[] Photo {get;set;}
        public string PhotoName { get; set; }
        public long? UserId { get; set; }
        public string ProfilePhotoPath { get; set; }

    }
    public class UserStoreMapping
    {
        public long UserStoreMappingId { get; set; }
        
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }

    public class ExceptionLog
    {
        [Key]
        public long LogId { get; set; }
        public string Message { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
