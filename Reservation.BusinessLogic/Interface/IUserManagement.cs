using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Data;

namespace Reservation.BusinessLogic
{
    public interface IUserManagement
    {
        List<UserModel> GetUsers();
        UserModel GetUser();
        UserModel GetUser(string userName, string password);
        UserModel GetUser(long cellNo, int userOTP);
        bool ValidateCellNo(long cellNo);
        void UpdateUserDetail(long cellNo, int oTP);

        //default inteface method new featire in c#8.0
        UserModel GetUsers(int customerId)
        {
            Console.WriteLine();

            return new UserModel();
        }

        
    }
}
