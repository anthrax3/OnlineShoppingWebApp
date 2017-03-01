using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingWebApp.BusinessLayer;
using System.Data;

namespace OnlineShoppingWebApp.Admin
{
    public partial class AddEditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            ShoppingCart K = new ShoppingCart
            {
                CategoryName = txtCategoryName.Text
            };

            K.AddNewCategory();
            txtCategoryName.Text = string.Empty;
            Response.Redirect("~/Admin/AddNewProducts.aspx");
        }
    }
}