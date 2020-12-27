using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using StoreShop.Models;
using StoreShop.Presentation;

namespace StoreShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManagement _userManagement;
        public HomeController(ILogger<HomeController> logger, IUserManagement userManagement)
        {
            _logger = logger;
            _userManagement = userManagement; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.SessionUsename = SessionManager.UserName;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ExceptionLogModel model = new ExceptionLogModel();
            model.Message = $" the path has  {exceptionDetail.Path} has thrown exception {exceptionDetail.Error}";
            model.ModifiedDate = DateTime.Now;

            _userManagement.CreateExceptionLog(model);
            _logger.LogError($" the path has  {exceptionDetail.Path} has thrown exception {exceptionDetail.Error}");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
