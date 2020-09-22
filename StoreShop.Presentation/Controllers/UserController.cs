using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using System;
using System.Collections.Generic;

namespace StoreShop.Presentation.Controllers
{
    
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        private readonly AccountController _accountController;
        public UserController(IUserManagement userManagement, AccountController accountController)
        {
            _userManagement = userManagement;
            _accountController = accountController;
        }
        
        public IActionResult GetUserProfile()
        {
            UserModel userModel = _userManagement.GetUser(SessionManager.UserId);
            return View("~/Views/User/UserProfile.cshtml", userModel);
        }

        public IActionResult SaveUserProfile(UserModel userModel)
        {
            if (userModel.UserId > 0)
            {
                _userManagement.UpdateUser(userModel, SessionManager.UserId);
                UserModel model = _userManagement.GetUser(SessionManager.UserId);
                _accountController.InitSession(model);
            }
            else
                _userManagement.CreateUser(userModel,SessionManager.CustomerId, SessionManager.UserId);

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
