namespace StoreShop.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagement _userManagement;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(IUserManagement userManagement, SignInManager<IdentityUser> signInManager)
        {
            _userManagement = userManagement;
            _signInManager = signInManager;
        }

        #region Email authentication
        public IActionResult Index()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        public IActionResult LogOn(LogOnModel logOnModel)
        {
             
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            UserModel userModel = _userManagement.GetUser(logOnModel.UserName, logOnModel.Password);

            if (userModel != null && userModel.UserId > 0)
            {
                InitSession(userModel);
                return RedirectToAction("Index", "Dashboard");
                //return View("~/Views/DashBoard/Index.cshtml");
            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
        }

        #endregion        

        #region OTP Login authentication
        public IActionResult OTPLoginPage()
        {
            return View("~/Views/Account/OTPLogin.cshtml");
        }

        public ActionResult GetOTP(long cellNo)
        {
            bool isCellNoExist = _userManagement.ValidateCellNo(cellNo);
            if (isCellNoExist)
            {
                bool response = GenerateOTP(cellNo);

                if (response)
                {
                    return Json(new { message = "OTP sent successfully.", sent = true });
                }
                return Json(new { message = "Validation code can not be send at this time.", sent = false });
            }
            return Json(new { message = "Mobile number is not registered.", sent = false });
        }

        public bool GenerateOTP(long cellNo)
        {
            Random _random = new Random();
            int OTP = _random.Next(1000, 9999);

            try
            {
                var response = /*_userManagement.*/SendSMS(cellNo, OTP);
            }
            catch (Exception)
            {
                return false;
            }
            _userManagement.UpdateUserOTP(cellNo, OTP);

            return true;
        }

        public string SendSMS(long cellNo, int OTP)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(91.ToString());
            sb.Append(cellNo.ToString());

            String message = HttpUtility.UrlEncode("Your verification code for storeshop is : " + OTP);
            //String message = HttpUtility.UrlEncode("Dear Kotak user, ur A/cX6578 debited by Rs5000.0 on 10Sep20 RefNo 0998403210.Download https://www.kotak.com/");

            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "MLrSb+hVVXA-6wN7LnB88GDPNMKWTR62eYftKfoB6R"},
                {"numbers" , sb.ToString()},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }

        public IActionResult LogOnWithOTP(OTPLogOnModel OTPModel)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/OTPLogin.cshtml");
            }
            UserModel userModel = _userManagement.GetUser(OTPModel.CellNo, OTPModel.OTP);

            if (userModel.UserId > 0)
            {
                InitSession(userModel);
                return View("~/Views/Dashboard/Index.cshtml");
            }
            else
                return View("~/Views/Account/OTPLogin.cshtml");

        }

        #endregion

        #region Google authentication
        public async Task<ActionResult> ShowSignUpOptions()
        {
            LogOnModel model = new LogOnModel();
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View("~/Views/Account/SignupOptions.cshtml", model);
        }

        public IActionResult ShowGoogleLoginPage(string provider = "Google")
        {
            string returnUrl = Url.Content("https://localhost:44302/Home");
            var redirectUrl = Url.Action("GoogleResponse", "Account", new { ReturnUrl = returnUrl });
            
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> GoogleResponse(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LogOnModel logOnModel = new LogOnModel()
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            var userInfo = await _signInManager.GetExternalLoginInfoAsync();

            UserModel userModel = new UserModel();
            userModel.FirstName = userInfo.Principal.FindFirstValue(ClaimTypes.GivenName);
            userModel.LastName = userInfo.Principal.FindFirstValue(ClaimTypes.Surname);
            userModel.UserName = userInfo.Principal.FindFirstValue(ClaimTypes.Email);


            return View("~/Views/Account/ExternalUserDetails.cshtml", userModel);
        }
        #endregion

        #region Register New user
        public ActionResult ShowSignUpPage()
        {
            UserModel model = new UserModel();
            model.CountryCodes = new List<int>() { }; 
            return View("~/Views/Account/SignUp.cshtml",model);
            
        }        

        public ActionResult Signup(UserModel model)
        {
            return Json(true);
        }

        #endregion



        public void InitSession(UserModel userModel)
        {
            SessionManager.UserName = userModel.UserName;
            SessionManager.FirstName = userModel.FirstName;
            SessionManager.LastName = userModel.LastName;
            SessionManager.UserId = userModel.UserId;
            SessionManager.RoleId = userModel.RoleId;
            SessionManager.CustomerId = userModel.CustomerId;
            SessionManager.CustomerName = userModel.Customer.CustomerName;
            SessionManager.UserProfilePhotoPath = _userManagement.GetUserProfilePhoto(userModel.UserId);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); //clear all the value from session object but does nor delete object from server.
            //HttpContext.Session.Abondon();

            return View("~/Views/Account/Login.cshtml");
        }

        

    }
}
