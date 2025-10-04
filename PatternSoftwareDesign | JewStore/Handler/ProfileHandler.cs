using ProjectLabPSD.Repository;
using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Handler
{
    public class ProfileHandler
    {
        private static InterfaceUserRepository userRepo = new UserProfileRepository();

        public static MsUser GetUserById(int userId)
        {
            return userRepo.GetUserById(userId);
        }

        public static string ChangePassword(int userId, string oldPassword, string newPassword)
        {
            MsUser user = userRepo.GetUserById(userId);

            if (user == null) return "User not found.";

            if (user.UserPassword != oldPassword)
            {
                return "Old password is incorrect.";
            }

            userRepo.UpdatePassword(user, newPassword);
            return "Password changed successfully.";
        }
    }
}