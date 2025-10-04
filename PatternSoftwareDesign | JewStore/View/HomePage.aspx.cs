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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MsJewel> jewels = JewelHandler.GetAllJewels();

                JewelGridView.DataSource = jewels;
                JewelGridView.DataBind();
            }
        }

        protected void JewelGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            JewelGridView.PageIndex = e.NewPageIndex;

            List<MsJewel> jewels = JewelHandler.GetAllJewels();

            JewelGridView.DataSource = jewels;
            JewelGridView.DataBind();
        }
    }
}