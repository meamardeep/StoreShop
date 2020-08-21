using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using System.Collections.Generic;

namespace StoreShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        //[ReesultfilterAttribute]
        //[ActionName("amardeep")]
        [Route("")]
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
