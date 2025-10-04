using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Repository
{
    public interface InterfaceUserRepository
    {
        MsUser GetUserById(int userId);
        void UpdatePassword(MsUser user, string newPassword);
    }
}