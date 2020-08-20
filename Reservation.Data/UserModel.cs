using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Reservation.Data
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get;  set; }

        public long CellNo { get; set; }

        public int CountryCode { get; set; }

        public List<int> CountryCodes { get; set; }

        public string Password { get; set; }


    }
}
