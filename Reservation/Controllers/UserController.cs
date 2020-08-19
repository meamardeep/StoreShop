using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Reservation.BusinessLogic;
using Reservation.Data;
using System.Collections.Generic;

namespace Reservation.Presentation.Controllers
{
    [Route("amardeep")]
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        //[ReesultfilterAttribute]
        //[ActionName("amardeep")]
        public IActionResult GetUser()
        {
            
            List<UserModel> userModel = _userManagement.GetUsers();
            
            return View("~/Views/User/Index.cshtml", userModel);
        }
    }
}
