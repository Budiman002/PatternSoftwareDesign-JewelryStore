using ProjectLabPSD.Controller;
using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                var user = (MsUser)Session["user"];
                LabelNavbarAdmin.Text = "Welcome, " + user.UserName + " (" + user.UserRole + ")";
                LabelNavbarCustomer.Text = "Welcome, " + user.UserName + " (" + user.UserRole + ")";
            }
        }

        protected void Loginpage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void RegisterPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }

        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void CartPage_Click(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
            {
                var customer = Session["Customer"];
                int userId = Convert.ToInt32(customer.GetType().GetProperty("UserID").GetValue(customer, null));

                Response.Redirect($"~/View/CartPage.aspx?userId={userId}");
            }
            else if (Request.Cookies["Customer_cookie"] != null)
            {
                string userIdStr = Request.Cookies["Customer_cookie"].Value;
                Response.Redirect($"~/View/CartPage.aspx?userId={userIdStr}");
            }
            else
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }
        }

        protected void MyOrderPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MyOrderPage.aspx");
        }

        protected void ProfilePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ProfilePage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            if (Request.Cookies.Count > 0)
            {
                foreach (string cookieName in Request.Cookies.AllKeys)
                {
                    HttpCookie cookie = new HttpCookie(cookieName);
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }
            }
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void AddJewelPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/AddJewelPage.aspx");
        }

        protected void ReportPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ReportPage.aspx");
        }

        protected void HandleOrderPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HandleOrderPage.aspx");
        }
    }
}