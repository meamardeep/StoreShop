using Reservation.DataAccess;
using System.Collections;
using System.Collections.Generic;

namespace Reservation.Repository
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();
        User GetUser(string userName, string password);
        User GetUser(long cellNo, int userOTP);
        User GetUser(long cellNo);
        void UpdateUserDetail(User user);
    }
}
