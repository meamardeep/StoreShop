
using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace StoreShop.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly StoreShopDataContext _database;
        public UserRepo(StoreShopDataContext storeshopDataContext )
        {
            _database = storeshopDataContext;
        }
       
        public User GetUser(string userName, string password)
        {
            var sql = from u in _database.Users
                      .Include(c=> c.Customer)
                      where u.UserName == userName && u.Password == password && u.IsActive == true
                      select u;

            //var sql2 = _database.Users.Where(u => u.UserId == 1);

            return sql.FirstOrDefault();
        }

        public User GetUser(long cellNo, int userOTP)
        {
            var sql = from u in _database.Users
                      where u.CellNo == cellNo && u.OTP == userOTP && u.IsActive == true
                      select u;
            return sql.FirstOrDefault();
        }

        public User GetUserByCellNo(long cellNo)
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
       

        #region USER CRUD
        public User GetUser(long userId)
        {
           return  _database.Users.Where(u => u.UserId == userId).Include(c=>c.Customer).FirstOrDefault();
        }
        public List<User> GetUsers(int customerId)
        {
            return _database.Users.Where(u => u.CustomerId == customerId).ToList();
        }

        public void CreateUser(User user)
        {
            _database.Users.Add(user).State = EntityState.Added;
            _database.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _database.Remove(user).State = EntityState.Deleted;
            _database.SaveChanges();
        }
        
        public void UpdateUser(User user)
        {
            _database.Entry(user).State = EntityState.Modified;
            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public long? CreateUserProfilePhoto(UserPhoto userPhoto)
        {
             _database.UserPhotos.Add(userPhoto);
            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return userPhoto.ProfilePhotoId;
        }
        public UserPhoto GetUserProfilePhoto(long userId)
        {
            return _database.UserPhotos.Where(p => p.UserId == userId).FirstOrDefault();
        }

        public void UpdateUserProfilePhoto(UserPhoto userPhoto)
        {
            _database.Entry(userPhoto).State = EntityState.Modified;
        }

        #endregion
    }
}
