namespace StoreShop.Presentation.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _productManagement;
        UserSessionModel userSessionModel;
        public ProductController( IProductManagement productManagement)
        {
            _productManagement = productManagement;
            userSessionModel = GetUserSession();
        }
        //public IActionResult Index()  //Display all cards
        //{
        //    List<ProductModel> models = new List<ProductModel>();
        //    return View("~/Views/Product/Index.cshtml", models);
        //}

        #region
        public IActionResult ShowProductDetail()
        {
            return View("~/Views/Product/Product.cshtml");
        }
        #endregion 

        #region Mobile
        public IActionResult ShowMobileCards()  //Display all cards
        {
            List<MobileCardModel> models = new List<MobileCardModel>();
            return View("~/Views/Product/Mobile/MobileIndex.cshtml", models);
        }
        #endregion

        #region Laptop
        public IActionResult ShowLaptopCards()  //Display all cards
        {
            List<LaptopCardModel> models = new List<LaptopCardModel>();
            return View("~/Views/Product/Laptop/LaptopIndex.cshtml", models);
        }
        #endregion

        #region Television
        public IActionResult ShowTelevisionCards()  //Display all cards
        {
            List<TelevisionCardModel> models = new List<TelevisionCardModel>();
            return View("~/Views/Product/Television/TelevisionIndex.cshtml", models);
        }
        #endregion

        #region Clothing
        public IActionResult ShowClothingCards()  //Display all cards
        {
            List<ClothingCardModel> models = new List<ClothingCardModel>();
            return View("~/Views/Product/Clothing/ClothingIndex.cshtml", models);
        }

        public IActionResult GetCloths()
        {
            List< ProductModel> models = new List<ProductModel>();
            models = _productManagement.GetProducts(Convert.ToInt32(ProductType.Shirts), userSessionModel.SessionCustomerId,
                    userSessionModel.SessionUserId);
            return View("~/Views/Product/Clothing/ClothingIndex.cshtml", models);
        }
        #endregion
    }
}
