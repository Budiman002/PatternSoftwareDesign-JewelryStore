using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Repository
{
    public class UserProfileRepository : InterfaceUserRepository
    {
        private DatabaseJawelEntities db = new DatabaseJawelEntities();

        public MsUser GetUserById(int userId)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserID == userId);
        }

        public void UpdatePassword(MsUser user, string newPassword)
        {
            user.UserPassword = newPassword;
            db.SaveChanges();
        }
    }
}