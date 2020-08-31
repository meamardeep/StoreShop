using StoreShop.DataAccess;
using System.Collections;
using System.Collections.Generic;

namespace StoreShop.Repository
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUser(string userName, string password);
        User GetUser(long cellNo, int userOTP);
        User GetUser(long cellNo);
        void UpdateUserDetail(User user);
    }
}
