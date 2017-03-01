using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingWebApp.BusinessLayer;
using OnlineShoppingWebApp.DataLayer;
using System.Data;

namespace OnlineShoppingWebApp.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Diagnostics.Debug.Write("Session[\"userCheckoutCompleted\"]"+Session["userCheckoutCompleted"]);
                // Verify user has completed the checkout process.
                if ((string)Session["userCheckoutCompleted"] != "true")
                {
                    Session["userCheckoutCompleted"] = string.Empty;
                    Response.Redirect("~/Checkout/CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                }

                NVPAPICaller payPalCaller = new NVPAPICaller();

                string retMsg = "";
                string token = "";
                string finalPaymentAmount = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();

                token = Session["token"].ToString();
                PayerID = Session["payerId"].ToString();
               
                finalPaymentAmount = Session["TotalPrice"].ToString();

                bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);

                Console.WriteLine(retMsg);
                Console.WriteLine(finalPaymentAmount);

                if (ret)
                {
                    // Retrieve PayPal confirmation value.
                    string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();
                    TransactionId.Text = PaymentConfirmation;
                    //  lblTransactionNo.Text= "Your Order No :-" + dtResult.Rows[0][0];
                    OrderNo.Text = Session["OrderNo"].ToString();
                    // Get the current order id.
                    int currentOrderId =-1;

                    if (Session["currentOrderId"] != null)
                    {
                        currentOrderId = Convert.ToInt32(Session["currentOrderId"]);
                        if (currentOrderId >= 0)
                        {

                            ConnectionClass.UpdateOrderDetails(currentOrderId, PaymentConfirmation);

                        }
                    }


                    // Clear order id.
                    Session["currentOrderId"] = string.Empty;
                }
                else
                {
                    Response.Redirect("~/Checkout/CheckoutError.aspx?" + retMsg);
                }
            }
        
        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}