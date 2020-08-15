using Reservation.Data;
using Reservation.DataAccess;
using Reservation.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reservation.BusinessLogic
{
    public class UserManagement : IUserManagement
    {
        private IUser _userRepo;

        public UserManagement(IUser user)
        {
            _userRepo = user;

        }

        public UserModel GetUser(string userName, string password)
        {
            User user = _userRepo.GetUser(userName, password);
            UserModel model = new UserModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return model;
        }

        public List<UserModel> GetUsers()
        {
            IEnumerable<User> users = _userRepo.GetUsers();
            List<UserModel> models = new List<UserModel>();
            foreach(var user in users)
            {
                models.Add(new UserModel()
                { UserId = user.UserId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName

                });
               
            }
                      
            return models;
        }
    }
}
