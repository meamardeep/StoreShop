
using Reservation.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Reservation.Repository
{
    public class UserRepo : IUser
    {
        private readonly ReservationDataContext _database;
        public UserRepo(ReservationDataContext reservationDataContext )
        {
            _database = reservationDataContext;
        }

        public IEnumerable<User> GetUsers()
        {
           var sql = from u in _database.Users
                        select u;
            
            return sql;
        }

        public User GetUser(string userName, string password)
        {
            var sql = from u in _database.Users
                      where u.UserName == userName && u.Password == password && u.IsActive == true
                      select u;
            return sql.FirstOrDefault();
        }
    }
}
