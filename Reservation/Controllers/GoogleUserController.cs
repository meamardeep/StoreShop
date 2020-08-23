using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreShop.Presentation.Controllers
{
    public class GoogleUserController :Controller
    {
        public GoogleUserController()
        { 
        
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
