using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreShop.DataAccess
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long CellNo { get; set; }
        public int? OTP { get; set; }
        public bool LoginAttemptCounter { get; set; }

        //[ForeignKey("Store")]
        //public int StoreId { get; set; }
        //public Store Store { get; set; }
    }
}
