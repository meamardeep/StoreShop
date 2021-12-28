using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreShop.Data;
using StoreShop.DataAccess;
using StoreShop.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Linq;
using StoreShop.Storage;

namespace StoreShop.BusinessLogic
{
    public class UserManagement : IUserManagement
    {
        private IUserRepo _userRepo;
        private IMapper _mapper;
        private UserSessionModel userSession;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AzureBlobStorageHelper _azureStorageHelper;
        private readonly AzureQueueStorageHelper _azureQueueStorageHelper;
        public UserManagement(IUserRepo user, IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _userRepo = user;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            //userSession = ControllerBase.
            _azureStorageHelper = new AzureBlobStorageHelper();
            _azureQueueStorageHelper = new AzureQueueStorageHelper();
        }

        public UserModel GetUser(string userName, string password)
        {
            User user = _userRepo.GetUser(userName, password);
            UserModel model = _mapper.Map<UserModel>(user);
            
            return model;
        }

        public UserModel GetUser(long cellNo, int userOTP)
        {
            User user = _userRepo.GetUser(cellNo, userOTP);
            UserModel model = _mapper.Map<UserModel>(user);          
            return model;
        }

        public UserModel GetUser()
        {
            throw new System.NotImplementedException();
        }

        public List<UserModel> GetUsers()
        {
            IEnumerable<User> users = _userRepo.GetUsers();
            List<UserModel> models = _mapper.Map<List<UserModel>>(users);
            return models;
        }

        public void UpdateUserOTP(long cellNo, int oTP)
        {
            User user = _userRepo.GetUserByCellNo(cellNo);
            user.OTP = oTP;
            user.LoginAttemptCounter = false;
            _userRepo.UpdateUser(user);
        }

        public bool ValidateCellNo(long cellNo)
        {
            User user = _userRepo.GetUserByCellNo(cellNo);
            return user != null ? true : false;
        }

        public string SendSMS(long cellNo, int OTP)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(91.ToString());
            sb.Append(cellNo.ToString());

            String message = HttpUtility.UrlEncode("Your verification code for storeshop is : " + OTP);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "MLrSb+hVVXA-6wN7LnB88GDPNMKWTR62eYftKfoB6R"},
                {"numbers" , sb.ToString()},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }

        #region User CRUD
        public List<UserModel> GetUsers(int customerId)
        {
           
                //int val = 0, sum = 0;
                //int dividend = sum / val;
            
            
            List<User> users = _userRepo.GetUsers(customerId);
            return _mapper.Map<List<UserModel>>(users);            
        }

        public UserModel GetUser(long userId)
        {

            User user = _userRepo.GetUser(userId);
            return _mapper.Map<UserModel>(user);
        }

        public void CreateUser(UserModel model,int sessionCustomerId, long sessionUserId)
        {
            User user = _mapper.Map<User>(model);
            user.CreatedDate = DateTime.Now;
            user.CustomerId = sessionCustomerId;
            user.IsActive = true;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = sessionUserId;

            _userRepo.CreateUser(user);
        }

        public void UpdateUser(UserModel model,long sessionUserId)
        {
            User user = _userRepo.GetUser(model.UserId);
            string guid ="";
            if (model.ProfilePhoto != null)
            {
                guid = _azureStorageHelper.CreateBlob(UtilityModel.PROFILE_CONTAINER, model.ProfilePhoto.FileName, model.ProfilePhoto.OpenReadStream());
            }
                UserPhoto userPhoto = _userRepo.GetUserProfilePhoto(user.UserId);
                if (userPhoto != null)
                {
                    userPhoto.FileName = model.ProfilePhoto.FileName;
                    userPhoto.Guid = guid;
                    user.ProfilePhotoId = _userRepo.UpdateUserProfilePhoto(userPhoto);
                }
                else {
                    userPhoto = new UserPhoto();
                    userPhoto.FileName = model.ProfilePhoto.FileName;
                    userPhoto.Guid = guid;
                    userPhoto.UserId = model.UserId;
                    user.ProfilePhotoId =  _userRepo.CreateUserProfilePhoto(userPhoto);
                }               
            

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.GenderId = model.GenderId;
            user.CellNo = model.CellNo;
            //user.DOB = model.DOB;
            user.ModifiedBy = sessionUserId;
            user.ModifiedDate = DateTime.Now;
            _userRepo.UpdateUser(user);
        }

        public string GetUserProfilePhoto(long userId)
        {
            UserPhoto userPhoto = _userRepo.GetUserProfilePhoto(userId);
            return _azureStorageHelper.GetBlob(UtilityModel.PROFILE_CONTAINER, userPhoto.Guid + Path.GetExtension(userPhoto.FileName));
        }

        public void DeleteUser(long userId)
        {
            User user = _userRepo.GetUser(userId);
            _userRepo.DeleteUser(user);
        }

        #endregion

        public void CreateExceptionLog(ExceptionLogModel model)
        {
            ExceptionLog log = _mapper.Map<ExceptionLog>(model);
            _userRepo.CreateExceptionLog(log);
        }

        public void SendProfileAccessNotification(string userName)
        {
            SMS sMS = new SMS() 
            { IsSent= false, ModifiedDate = DateTime.Now, 
              Message = $"Dear {userName}, You have accessed your user profile.",
              Phone = "+91-8088506025"
            };
             _userRepo.SaveSMS(sMS);

            AddSMSToQueue(sMS);
        }

        private void AddSMSToQueue(SMS sMS)
        {
            string message = JsonSerializer.Serialize(sMS);
            _azureQueueStorageHelper.AddMessageToQueue(UtilityModel.SMS_QUEUE, message);
        }

    }
}
