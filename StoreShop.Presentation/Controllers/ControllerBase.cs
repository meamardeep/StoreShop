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
