using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace StoreShop.Data
{
    public class AccountModel
    {

    }

    public class LogOnModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }

    public class OTPLogOnModel
    {
        public long CellNo { get; set; }

        public int OTP { get; set; }
    }
}
