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
    public partial class UpdateJewelPage : System.Web.UI.Page
    {
        private int jewelId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!int.TryParse(Request.QueryString["JewelID"], out jewelId))
            {
                lblError.Text = "Invalid Jewel ID.";
                return;
            }

            if (!IsPostBack)
            {

                ddlCategory.DataSource = JewelController.GetAllCategories();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                ddlBrand.DataSource = JewelController.GetAllBrands();
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();

                MsJewel jewel = JewelController.GetJewelById(jewelId);
                if (jewel == null) Response.Redirect("~/HomePage.aspx");

                txtName.Text = jewel.JewelName;
                txtPrice.Text = jewel.JewelPrice.ToString();
                txtYear.Text = jewel.JewelReleaseYear.ToString();
                ddlCategory.SelectedValue = jewel.CategoryID.ToString();
                ddlBrand.SelectedValue = jewel.BrandID.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            bool isPriceValid = int.TryParse(txtPrice.Text.Trim(), out int price);
            bool isYearValid = int.TryParse(txtYear.Text.Trim(), out int year);

            string result = JewelController.UpdateJewel(jewelId, name, int.Parse(ddlCategory.SelectedValue), int.Parse(ddlBrand.SelectedValue),
                isPriceValid ? price : -1, isYearValid ? year : -1);

            if (result == null)
            {
                Response.Redirect("~/View/DetailJewelPage.aspx?JewelID=" + jewelId);
            }
            else
            {
                lblError.Text = result;
            }
        }
    }
}