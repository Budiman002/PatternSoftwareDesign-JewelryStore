using ProjectLabPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class HandleOrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrders();
            }
        }

        private void BindOrders()
        {
            gvOrders.DataSource = TransactionController.GetUnfinishedTransactions();
            gvOrders.DataBind();
        }

        protected void gvOrders_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChangeStatus")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                TransactionController.AdvanceTransactionStatus(transactionId);
                BindOrders();
            }
        }

        public string GetActionText(string status)
        {
            if (status == "Payment Pending") return "Confirm Payment";
            if (status == "Shipment Pending") return "Ship Package";
            return "";
        }
    }
}