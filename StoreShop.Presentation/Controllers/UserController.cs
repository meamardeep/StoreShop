using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using System.Collections.Generic;

namespace StoreShop.Presentation.Controllers
{
    
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }
        
        public IActionResult GetUserProfile()
        {
            UserModel userModel = _userManagement.GetUser(SessionManager.UserId);
            return View("~/Views/User/UserProfile.cshtml", userModel);
        }

        public IActionResult SaveUserProfile(UserModel userModel)
        {
            if (userModel.UserId > 0)
                _userManagement.UpdateUser(userModel, SessionManager.UserId);
            //else
            //    _userManagement.CreateUser(userModel);
            
            return Json(true);
        }
        public IActionResult GetUser()
        {
            
            List<UserModel> userModel = _userManagement.GetUsers();
            
            return View("~/Views/User/Index.cshtml", userModel);
        }       

        [Route("/Display")]
        public ActionResult DisplayUser()
        {
            return Json(new { Name = "amardeep", dateOfBirth = "19/12/1995" });
        }
    }
}
