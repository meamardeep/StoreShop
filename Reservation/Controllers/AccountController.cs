using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reservation.BusinessLogic;
using Reservation.Data;

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
            if(!ModelState.IsValid)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            UserModel userModel = _userManagement.GetUser(logOnModel.UserName, logOnModel.Password);

            InitSession(userModel);
            
            return View("~/Views/DashBoard/Index.cshtml");
        }

        public void InitSession(UserModel userModel)
        {
            
            SessionManager.UserName = userModel.UserName;
            SessionManager.FirstName = userModel.FirstName;
            SessionManager.LastName = userModel.LastName;
            SessionManager.UserId = userModel.UserId;

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); //clear all the value from session object but does nor delete object from server.
            //HttpContext.Session.Abondon();

            return View("~/Views/Account/Login.cshtml");
        }
        
    }
}
