using ProjectLabPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class MyOrderPage : System.Web.UI.Page
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
                BindOrders();
            }
        }

        private void BindOrders()
        {
            gvOrders.DataSource = TransactionController.GetUserTransactions(userId);
            gvOrders.DataBind();
        }

        protected void gvOrders_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int trxId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ViewDetail")
            {
                Response.Redirect("TransactionDetailPage.aspx?TransactionID=" + trxId);
            }
            else if (e.CommandName == "Confirm")
            {
                TransactionController.UpdateTransactionStatus(trxId, "Done");
                BindOrders();
            }
            else if (e.CommandName == "Reject")
            {
                TransactionController.UpdateTransactionStatus(trxId, "Rejected");
                BindOrders();
            }
        }
    }
}