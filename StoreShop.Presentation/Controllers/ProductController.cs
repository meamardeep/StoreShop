using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreShop.Presentation.Controllers
{
    public class ProductController : ControllerBase
    {
        public IActionResult Index()
        {
            return View("~/Views/ProductInfo/Index.cshtml");
        }
    }
}
