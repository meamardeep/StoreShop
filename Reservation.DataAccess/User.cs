using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.DataAccess
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long CellNo { get; set; }
        public int? OTP { get; set; }
    }
}
