using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingWebApp.BusinessLayer;
using System.Data;

namespace OnlineShoppingWebApp.Checkout
{
    public partial class CheckoutStart : System.Web.UI.Page
    {
        public DataTable dtResult { get; set; }
     //   public List<OrderDetail> myListOrder { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            NVPAPICaller payPalCaller = new NVPAPICaller();
            string retMsg = "";
            string token = "";

            if (Session["TotalPrice"] != null)
            {
                string amt = Session["TotalPrice"].ToString();

                //  int amount = Convert.ToInt32(amt);

             
                //   bool ret = payPalCaller.ShortcutExpressCheckout(amt, ref token, ref retMsg, dtResult);
                bool ret = payPalCaller.ShortcutExpressCheckout(amt, ref token, ref retMsg, dtResult);
                if (ret)
                {
                    Session["token"] = token;
                    Response.Redirect(retMsg);
                }
                else
                {
                    Response.Redirect("~/Checkout/CheckoutError.aspx?" + retMsg);
                }
            }
            else
            {
                Response.Redirect("~/Checkout/CheckoutError.aspx?ErrorCode=AmtMissing");
            }
        }
    }
}