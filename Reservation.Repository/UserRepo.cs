
using Reservation.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Repository
{
    public class UserRepo : IUser
    {
        private readonly ReservationDataContext _database;
        public UserRepo(ReservationDataContext reservationDataContext )
        {
            _database = reservationDataContext;
        }


        public User GetUser(string userName, string password)
        {
            var sql = from u in _database.Users
                      where u.UserName == userName && u.Password == password && u.IsActive == true
                      select u;
            return sql.FirstOrDefault();
        }

        public User GetUser(long cellNo, int userOTP)
        {
            var sql = from u in _database.Users
                      where u.CellNo == cellNo && u.OTP == userOTP && u.IsActive == true
                      select u;
            return sql.FirstOrDefault();
        }

        public User GetUser(long cellNo)
        {
            var sql = from u in _database.Users
                      where u.CellNo == cellNo && u.IsActive == true
                      select u;
            return sql.FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            var sql = from u in _database.Users
                      select u;

            return sql;
        }

        public void UpdateUserDetail(User user)
        {
            _database.Add(user).State = EntityState.Modified;
            try
            {
                _database.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
