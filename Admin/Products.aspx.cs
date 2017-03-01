using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingWebApp.BusinessLayer;
using System.Data.SqlClient;

namespace OnlineShoppingWebApp.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProducts(0);//Get All Products

            }
        }

        private void GetProducts(int CategoryID)
        {
            ShoppingCart k = new ShoppingCart()
            {
                CategoryID = CategoryID
            };

            gvAvailableProducts.DataSource = null;
            gvAvailableProducts.DataSource = k.GetAllProducts();
            gvAvailableProducts.DataBind();

        }

        //protected void gv1_RowDeleting(Object sender, GridViewDeletedEventArgs e)
        //{
        //    gvAvailableProducts.Attributes.Add("OnClick", "return confirm('Really Want to Delete?');");

        //    //Logic to delete 


           

        //}

        protected void DeleteProduct(int ProductID)
        {
            ShoppingCart k = new ShoppingCart()
            {
                ProductID = ProductID
            };


            gvAvailableProducts.DataSource = k.DeleteProducts();
            gvAvailableProducts.DataBind();
        }

    }
}
