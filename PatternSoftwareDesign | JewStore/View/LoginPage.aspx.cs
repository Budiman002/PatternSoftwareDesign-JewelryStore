using Final_Project_PSD.Controller;
using ProjectLabPSD.Handler;
using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Text;
            bool remember = rememberMe.Checked;

            EmailError.Text = LoginController.ValidateEmail(email);
            PasswordError.Text = LoginController.ValidatePassword(password);

            if (!string.IsNullOrEmpty(EmailError.Text) ||
                !string.IsNullOrEmpty(PasswordError.Text)) return;

            MsUser user = AuthenticationHandler.GetUser(email, password);
            if (remember)
            {
                HttpCookie cookie = new HttpCookie($"{user.UserRole}_cookie")
                {
                    HttpOnly = true,
                    Secure = true,
                    Value = user.UserID.ToString(),
                    Expires = DateTime.Now.AddDays(3)
                };
                Response.Cookies.Add(cookie);
            }

            if (user != null)
            {
                Session["user"] = user;
                Session["UserID"] = user.UserID;
                Session["UserRole"] = user.UserRole;
                Session[user.UserRole] = user;
                Response.Redirect("~/View/HomePage.aspx");
            }
        }
    }
}