using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreShop.Data;

namespace StoreShop.Presentation.Controllers
{
    public class DashboardController :ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
