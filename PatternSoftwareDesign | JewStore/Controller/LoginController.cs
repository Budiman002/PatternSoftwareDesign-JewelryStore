using ProjectLabPSD.Handler;
using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_PSD.Controller
{
    public class LoginController
    {
        private static MsUser user;
        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "Please insert your Email.";
            else
            {
                user = AuthenticationHandler.GetUser(email);
                if (user == null) return "Email not found.";
            }
            return "";

        }
        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return "Please insert your Password.";
            else if (password.Equals(user.UserPassword) == false) return "Password Incorrect.";
            return "";
        }
    }
}