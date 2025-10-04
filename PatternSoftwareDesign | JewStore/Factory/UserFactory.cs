using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Factory
{
    public class UserFactory
    {
        public static MsUser CreateUser(string name, string pass, string email, DateTime dob, string gender, string role = "Customer")
        {
            return new MsUser
            {
                UserName = name,
                UserPassword = pass,
                UserEmail = email,
                UserDOB = dob.Date,
                UserGender = gender,
                UserRole = role
            };
        }
    }
}