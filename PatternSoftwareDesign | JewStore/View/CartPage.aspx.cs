using ProjectLabPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class Cart : System.Web.UI.Page
    {
        private int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            userId = Convert.ToInt32(Session["UserID"]);

            if (!IsPostBack)
            {
                BindCart();
                ddlPayment.Items.Add("Credit Card");
                ddlPayment.Items.Add("PayPal");
                ddlPayment.Items.Add("Visa");
                ddlPayment.Items.Add("Gopay");
                ddlPayment.Items.Add("Ovo");
                ddlPayment.Items.Add("BTC");
                ddlPayment.Items.Add("Qris");
                ddlPayment.Items.Add("Bank Transfer");
            }
        }

        private void BindCart()
        {
            var cart = CartController.GetCart(userId);
            gvCart.DataSource = cart;
            gvCart.DataBind();
            lblTotal.Text = CartController.GetCartTotal(cart).ToString("C");
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int jewelId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateQty")
            {
                GridViewRow row = ((Control)e.CommandSource).NamingContainer as GridViewRow;
                TextBox txtQty = row.FindControl("txtQty") as TextBox;

                if (int.TryParse(txtQty.Text, out int qty) && qty > 0)
                {
                    CartController.UpdateCartItem(userId, jewelId, qty);
                    BindCart();
                }
                else
                {
                    lblError.Text = "Quantity must be a number > 0.";
                }
            }

            if (e.CommandName == "RemoveItem")
            {
                CartController.RemoveCartItem(userId, jewelId);
                BindCart();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            CartController.ClearCart(userId);
            BindCart();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (ddlPayment.SelectedIndex < 0)
            {
                lblError.Text = "Please select a payment method.";
                return;
            }

            CartController.Checkout(userId, ddlPayment.SelectedValue);
            Response.Redirect("MyOrderPage.aspx");
        }
    }
}