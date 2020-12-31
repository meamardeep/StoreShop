using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreShop.Data;
namespace StoreShop.Presentation.Controllers
{
    public class ProductController : ControllerBase
    {
        //public IActionResult Index()  //Display all cards
        //{
        //    List<ProductModel> models = new List<ProductModel>();
        //    return View("~/Views/Product/Index.cshtml", models);
        //}
       
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
        #endregion
    }
}
