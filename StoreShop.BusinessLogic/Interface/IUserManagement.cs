﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using StoreShop.Data;

namespace StoreShop.BusinessLogic
{
    public interface IUserManagement
    {
        List<UserModel> GetUsers();
        UserModel GetUser();
        UserModel GetUser(string userName, string password);
        UserModel GetUser(long cellNo, int userOTP);
        bool ValidateCellNo(long cellNo);
        void UpdateUserDetail(long cellNo, int oTP);

        #region User CRUD
        List<UserModel> GetUsers(int customerId);
        UserModel GetUser(long userId);
        void CreateUser(UserModel model, int sessionCustomerId, long sessionUserId);
        void UpdateUser(UserModel model, long sessionUserId);
        void DeleteUser(long userId);
        string GetUserProfilePhoto(long userId);
        #endregion

        //string SendSMS(long cellNo, int oTP);
    }
}
