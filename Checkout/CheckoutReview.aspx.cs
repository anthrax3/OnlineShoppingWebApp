using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingWebApp.BusinessLayer;
using System.Data;
using OnlineShoppingWebApp.DataLayer;
using OnlineShoppingWebApp.Admin;
using OnlineShoppingWebApp;
using System.Globalization;


namespace OnlineShoppingWebApp.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                
                NVPAPICaller payPalCaller = new NVPAPICaller();

                string retMsg = "";
                string token = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();
                token = Session["token"].ToString();

                bool ret = payPalCaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    Session["payerId"] = PayerID;

                    var myOrder = new Order1();
                    myOrder.OrderDate = Convert.ToDateTime(decoder["TIMESTAMP"].ToString());
                    myOrder.Username = User.Identity.Name;
                    myOrder.FirstName = decoder["FIRSTNAME"].ToString();
                    myOrder.LastName = decoder["LASTNAME"].ToString();
                    myOrder.Address = decoder["SHIPTOSTREET"].ToString();
                    myOrder.City = decoder["SHIPTOCITY"].ToString();
                    myOrder.State = decoder["SHIPTOSTATE"].ToString();
                    myOrder.PostalCode = decoder["SHIPTOZIP"].ToString();
                    myOrder.Country = decoder["SHIPTOCOUNTRYCODE"].ToString();
                    myOrder.Email = decoder["EMAIL"].ToString();
                    // myOrder.Total = Convert.ToDecimal(decoder["AMT"].ToString());
                    //myOrder.Total = decimal.Parse(decoder["AMT"].ToString());
                    var culture = CultureInfo.InvariantCulture;

                    
                 //   int total = Convert.ToInt32(decoder["AMT"].ToString());
                    myOrder.Total = Decimal.Parse(decoder["AMT"].ToString(), culture);


                    // Verify total payment amount as set on CheckoutStart.aspx.
                    try
                    {
                        decimal paymentAmountOnCheckout = Convert.ToDecimal(Session["TotalPrice"].ToString());
                        //  decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
                        decimal paymentAmountFromPayPal = myOrder.Total;
                        if (paymentAmountOnCheckout != paymentAmountFromPayPal)
                        {
                            Response.Redirect("~/Checkout/CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("~/Checkout/CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                    }

                    //// Calling ShoppingCart object here
                   
                    ShoppingCart k = new ShoppingCart();

                    //// Save orderDetails  and CustomerDetails to the DB.
                  
                    k.SaveOrderDetails(myOrder);
                    k.SaveCustomerDetails();

                    //Set OrderId.
                    

                    string currentOrderId = ConnectionClass.GetMaxOrderId();

                    Session["currentOrderId"] = currentOrderId;

                   
                    // Get the Shopping Cart Products
                    DataTable dt = (DataTable)Session["MyCart"];
             
                  
                    DataTable myOrderDetail = new DataTable();
                    myOrderDetail.Columns.Add("ProductID", typeof(string));
                    myOrderDetail.Columns.Add("ProductName", typeof(string));
                    myOrderDetail.Columns.Add("ProductPrice", typeof(string));
                    myOrderDetail.Columns.Add("ProductQuantity", typeof(string));

                    DataRow dr = myOrderDetail.NewRow();

                    // Display OrderDetail information to the Review page for each product purchased.
                    for (int i = 0; i < dt.Rows.Count; i++)
                        {
                      
                            dr["ProductID"] = Convert.ToInt32(dt.Rows[i]["ProductID"]);
                            dr["ProductName"] = dt.Rows[i]["Name"].ToString();
                            dr["ProductPrice"] = dt.Rows[i]["Price"].ToString();
                            dr["ProductQuantity"] = Convert.ToInt32(dt.Rows[i]["ProductQuantity"]);

                        myOrderDetail.Rows.Add(dr);
                   
                    }

                  
                    // Display OrderDetails.
                    OrderItemList.DataSource = myOrderDetail;
                    OrderItemList.DataBind();

                    // Add OrderDetail information to the DB for each product purchased.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        // Create a new OrderDetail object.
                          ShoppingCart orderDetail = new ShoppingCart()
                          {

                            ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]),
                            ProductName = dt.Rows[i]["Name"].ToString(),
                            ProductPrice = dt.Rows[i]["Price"].ToString(),
                            ProductQuantity = Convert.ToInt32(dt.Rows[i]["ProductQuantity"])

                           };

                           orderDetail.AddOrders();
                    }




                    // Display Order information.

                    List<Order1> orderList = new List<Order1>();
                    orderList.Add(myOrder);
                    ShipInfo.DataSource = orderList;
                    ShipInfo.DataBind();

                    
                   

                   
                }
                else
                {
                    Response.Redirect("~/Checkout/CheckoutError.aspx?" + retMsg);
                }
            }
            
        }
    
        protected void CheckoutConfirm_Click(object sender, EventArgs e)
        {
            
            Session["userCheckoutCompleted"] = "true";
            Response.Redirect("~/Checkout/CheckoutComplete.aspx");
        }

        protected void btnCancel_Order(object sender, EventArgs e)
        {
            Session["userCheckoutCompleted"] = "false";
            Response.Redirect("~/Default.aspx");
        }

    }     
  }


