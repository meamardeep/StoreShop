using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreShop.BusinessLogic;
using StoreShop.Data;

namespace StoreShop.Presentation.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly ICartManagement _cartManagement;
        UserSessionModel UserSession;
        public CartController(ICartManagement cartManagement)
        {
            _cartManagement = cartManagement;
            UserSession = GetUserSession();
        }
        public IActionResult Index()
        {
            List<CartItemModel> models = _cartManagement.GetCartItems(UserSession.SessionUserId);
            return View(models) ;
        }
    }
}
