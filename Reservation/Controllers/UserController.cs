using Microsoft.AspNetCore.Mvc;
using Reservation.BusinessLogic;
using Reservation.Data;
using System.Collections.Generic;

namespace Reservation.Presentation.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }
        public IActionResult GetUser()
        {
            List<UserModel> userModel = _userManagement.GetUsers();
            
            return View("~/Views/User/Index.cshtml", userModel);
        }
    }
}
