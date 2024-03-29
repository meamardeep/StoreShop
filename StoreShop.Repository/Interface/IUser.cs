﻿using StoreShop.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace StoreShop.Repository
{
    public interface IUserRepo
    {
        IQueryable<User> GetUsers();
        User GetUser(string userName, string password);
        User GetUser(long cellNo, int userOTP);
        User GetUserByCellNo(long cellNo);

        #region User CRUD
        List<User> GetUsers(int customerId);
        User GetUser(long userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        long? CreateUserProfilePhoto(UserPhoto userPhoto);
        UserPhoto GetUserProfilePhoto(long userId);
        long? UpdateUserProfilePhoto(UserPhoto userPhoto);
        #endregion
        void CreateExceptionLog(ExceptionLog log);
        void SaveSMS(SMS sMS);
    }
}
