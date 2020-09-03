using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreShop.Presentation.Controllers
{
    [SessionTimeout]
    public class ControllerBase : Controller
    {
        public readonly IWebHostEnvironment _hostingEnvironment;
        public ControllerBase()
        {

        }

        public ControllerBase(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public static UserSessionModel GetUserSession()
        {
            return new UserSessionModel()
            {
                SessionUserId = SessionManager.UserId,
                SessionCustomerId = SessionManager.CustomerId
                //SessionStoreId = SessionManager.
            };
        }
    }
}
