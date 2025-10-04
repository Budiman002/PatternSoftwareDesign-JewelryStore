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
    public partial class AddJewelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            bool isPriceValid = int.TryParse(txtPrice.Text.Trim(), out int price);
            bool isYearValid = int.TryParse(txtYear.Text.Trim(), out int year);

            string result = JewelController.AddJewel(
                name,
                int.Parse(ddlCategory.SelectedValue),
                int.Parse(ddlBrand.SelectedValue),
                isPriceValid ? price : -1,
                isYearValid ? year : -1
            );

            if (result == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else
            {
                lblError.Text = result;
            }
        }
    }
}