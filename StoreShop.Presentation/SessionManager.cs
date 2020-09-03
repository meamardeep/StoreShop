using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreShop.Data;
using System;
using System.Text.Json;
//using Newtonsoft.Json;


namespace StoreShop.Presentation
{
    public static class SessionManager
    {

        public const string SESSION_USER_NAME_Key = "UserName";
        public const string SESSION_USER_ID_KEY = "User_Id";
        public const string SESSION_FIRST_NAME_KEY = "First_Name";
        public const string SESSION_LAST_NAME_KEY = "Last_Name";
        public const string SESSION_USER_ROLE_ID_KEY = "User_Role_Id";
        public const string SESSION_STORE_ID_KEY = "Store_Id";
        public const string SESSION_CUSTOMER_ID_KEY = "Customer_Id";
        public const string SESSION_CUSTOMER_NAME_KEY = "Customer_Name";

        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        //private readonly IHttpContextAccessor httpContextAccessor;
        public static HttpContext Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        #region User Attribute
        public static string UserName
        {
            get => Current.Session.GetFromSession<string>(SESSION_USER_NAME_Key);
            set => Current.Session.SetInSession<string>(SESSION_USER_NAME_Key, value);
        }

        public static string FirstName
        {
            get => Current.Session.GetFromSession<string>(SESSION_FIRST_NAME_KEY);
            set => Current.Session.SetInSession<string>(SESSION_FIRST_NAME_KEY, value);
        }
        public static string LastName
        {
            get => Current.Session.GetFromSession<string>(SESSION_LAST_NAME_KEY);
            set => Current.Session.SetInSession<string>(SESSION_LAST_NAME_KEY, value);
        }
        public static long UserId
        {
            get => Current.Session.GetFromSession<long>(SESSION_USER_ID_KEY);
            set => Current.Session.SetInSession<long>(SESSION_USER_ID_KEY, value);
        }
        public static int RoleId
        {
            get => Current.Session.GetFromSession<int>(SESSION_USER_ROLE_ID_KEY);
            set => Current.Session.SetInSession<int>(SESSION_USER_ROLE_ID_KEY, value);
        }
        #endregion

        #region Customer Attribute
        public static int CustomerId 
        {
            get => Current.Session.GetFromSession<int>(SESSION_CUSTOMER_ID_KEY);
            set => Current.Session.SetInSession<int>(SESSION_CUSTOMER_ID_KEY, value);
        }

        public static string CustomerName
        {
            get => Current.Session.GetFromSession<string>(SESSION_CUSTOMER_NAME_KEY);
            set => Current.Session.SetInSession<string>(SESSION_CUSTOMER_NAME_KEY, value);
        }
        public static int? StoreId 
        {
            get => Current.Session.GetFromSession<int>(SESSION_STORE_ID_KEY);
            set => Current.Session.SetInSession<int>(SESSION_STORE_ID_KEY, (int)value);
        }
        #endregion

        
        public static bool IsSessionAlive
        {
            get
            {
                bool sessionAlive = SessionManager.UserName != null ? true : false;
                //bool sessionAlive = Current.Session.GetFromSession<object>("UserName") != null && Current.Session.GetFromSession<object>("UserName").ToString() != "" ? true : false;
                return sessionAlive;
            }
        }

    }

    public static class SessionExtensions
    {
        public static void SetInSession<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetFromSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }

    /// <summary>
    /// Check for session before executing any action method
    /// </summary>
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!SessionManager.IsSessionAlive)
            {
                filterContext.Result = new RedirectResult("~/account/index?a=to");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

       
    }

    [AttributeUsage(AttributeTargets.Method /*| AttributeTargets.Field*/)]
    public class ReesultfilterAttribute: ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }

    }

}
