using ProjectLabPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectLabPSD.Controller
{
    public class RegisterController
    {
        public static string ValidateEmail(string email)
        {
            const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrWhiteSpace(email)) return "Please insert your Email.";
            else if (!Regex.IsMatch(email, emailPattern)) return "Email format is invalid.";
            else if (MsUserRepository.GetUser(email) != null) return "Email is already in use.";
            return "";
        }
        public static string ValidateUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return "Please insert your Username.";
            else if (username.Length < 3 || username.Length > 25) return "Username must be between 3 to 25 characters (inclusive).";
            return "";
        }
        public static string ValidatePassword(string password)
        {
            const string passPattern = @"^[a-zA-Z0-9]+$";
            if (string.IsNullOrWhiteSpace(password)) return "Please insert your Password.";
            else if (Regex.IsMatch(password, passPattern) == false) return "Password must be alphanumeric";
            else if (password.Length < 8 || password.Length > 20) return "Password must be 8 to 20 characters (inclusive).";
            return "";
        }
        public static string ValidateConfirm(string password, string confirm)
        {
            if (string.IsNullOrWhiteSpace(confirm)) return "Please insert your Confirmation Passwor.";
            else if (String.Equals(password, confirm) == false) return "Confirmation password must be the same as password";
            return "";
        }
        public static string ValidateGender(string gender)
        {
            if (string.IsNullOrWhiteSpace(gender)) return "Please select your Gender.";
            else if (!(gender.Equals("male") || gender.Equals("female"))) return "Must be chosen using radio button and must be Male or Female.";
            return "";
        }
        public static string ValidateDob(string dob)
        {
            DateTime minDate = new DateTime(2010, 1, 1);
            DateTime dobConv;
            if (string.IsNullOrWhiteSpace(dob)) return "Please Choose your Date of Birth.";
            else if (!DateTime.TryParse(dob, out dobConv) || dobConv >= minDate) return "DOB must be earlier than 01/01/2010.";
            return "";
        }
    }
}