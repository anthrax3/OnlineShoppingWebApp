using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShoppingWebApp
{
    public partial class TrackYourOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                string TransactionNo = Request.QueryString["Id"];
                ucCustomerOrder1.TransactionNoText = TransactionNo;
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Session["OnlineShoppingWebAppAdmin"])))
            {
                ucCustomerOrder1.IsAuthorizedToAddStatus = true;
            }
            else
            {
                ucCustomerOrder1.IsAuthorizedToAddStatus = false;
               // ucCustomerOrder1.Visible = false;

            }
        }
    }
}