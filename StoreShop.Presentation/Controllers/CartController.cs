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
