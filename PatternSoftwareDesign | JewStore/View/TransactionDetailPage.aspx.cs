using ProjectLabPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["TransactionID"], out int transactionId))
            {
                Response.Redirect("MyOrderPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                var header = TransactionController.GetTransactionHeader(transactionId);
                if (header == null)
                {
                    Response.Redirect("MyOrderPage.aspx");
                    return;
                }

                lblID.Text = header.TransactionID.ToString();
                lblDate.Text = header.TransactionDate.ToString("dd MMM yyyy");
                lblStatus.Text = header.TransactionStatus;

                var details = TransactionController.GetTransactionDetails(transactionId);
                gvDetails.DataSource = details;
                gvDetails.DataBind();

                lblTotal.Text = details.Sum(d => d.Subtotal).ToString("C");
            }
        }
    }
}