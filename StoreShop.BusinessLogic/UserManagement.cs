using AutoMapper;
using StoreShop.Data;
using StoreShop.DataAccess;
using StoreShop.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

namespace StoreShop.BusinessLogic
{
    public class UserManagement : IUserManagement
    {
        private IUser _userRepo;
        private IMapper _mapper;

        public UserManagement(IUser user, IMapper mapper)
        {
            _userRepo = user;
            _mapper = mapper;

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

        public void UpdateUserDetail(long cellNo, int oTP)
        {
            User user = _userRepo.GetUser(cellNo);
            user.OTP = oTP;
            user.LoginAttemptCounter = false;
            _userRepo.UpdateUserDetail(user);
        }

        public bool ValidateCellNo(long cellNo)
        {
            User user = _userRepo.GetUser(cellNo);
            return user != null ? true : false;
        }

        public string SendSMS(long cellNo, int OTP)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(91.ToString());
            sb.Append(cellNo.ToString());

            String message = HttpUtility.UrlEncode("Your verification code for reservation is : " + OTP);
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
    }
}
