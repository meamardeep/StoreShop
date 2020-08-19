using AutoMapper;
using Reservation.Data;
using Reservation.DataAccess;
using Reservation.Repository;
using System.Collections.Generic;

namespace Reservation.BusinessLogic
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
            _userRepo.UpdateUserDetail(user);
        }

        public bool ValidateCellNo(long cellNo)
        {
            User user = _userRepo.GetUser(cellNo);
            return user != null ? true : false;
        }
    }
}
