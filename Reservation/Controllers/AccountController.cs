using Microsoft.AspNetCore.Mvc;
using Reservation.BusinessLogic;
using Reservation.Data;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Reservation.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagement _userManagement;
        public AccountController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

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

            if (userModel.UserId > 0)
            {
                InitSession(userModel);
                return View("~/Views/DashBoard/Index.cshtml");
            }
            else
            {
                return View("~/Views/Account/Login.cshtml");
            }
        }

        public void InitSession(UserModel userModel)
        {

            SessionManager.UserName = userModel.UserName;
            SessionManager.FirstName = userModel.FirstName;
            SessionManager.LastName = userModel.LastName;
            SessionManager.UserId = userModel.UserId;

        }

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
                    return Json(true);
                }
                return Json(new { message = "Validation code can not be send at this time"});
            }
            return Json(new { message = "Please enter valid mobile number." });
        }

        public bool GenerateOTP(long cellNo)
        {            
            Random _random = new Random();
            int OTP =  _random.Next(1000, 9999);

            try
            {
                var response = SendSMS(cellNo, OTP);
            }
            catch (Exception)
            {
                return false;
            }
            _userManagement.UpdateUserDetail(cellNo, OTP);
            
            return true;
        }

        public string SendSMS(long cellNo, int OTP)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(91.ToString());
            sb.Append(cellNo.ToString());

            //cellNo = Convert.ToInt64(sb);

            String message = HttpUtility.UrlEncode("Your verification code for reservation is : " +OTP);
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
                return View("~/Views/DashBoard/Index.cshtml");
            }
            else
                return View("~/Views/Account/OTPLogin.cshtml");

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); //clear all the value from session object but does nor delete object from server.
            //HttpContext.Session.Abondon();

            return View("~/Views/Account/Login.cshtml");
        }

    }
}
