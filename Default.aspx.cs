using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OnlineShoppingWebApp.BusinessLayer;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Collections;
using OnlineShoppingWebApp.Checkout;

namespace OnlineShoppingWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCategoryName.Text = "Popular Products ";
                GetCategory();//Get all Category
                GetProducts(0);//Get all Products
            }
            lblAvailableStockAlert.Text = string.Empty;

            //check if username exists, then 
            //change the login text
            if(Session["Username"] != null)
            {
                lblLogin.Text = "Welcome" + Session["Username"].ToString();
                lblLogin.Visible = true;
                btnLogin.Text = "Logout";
            }
            else
            {
                lblLogin.Visible = false;
                btnLogin.Text = "Login";
            }
        }

        //Method for getting all the Categories
        private void GetCategory()
        {
            ShoppingCart k = new ShoppingCart();
            dlCategories.DataSource = null;
            dlCategories.DataSource = k.GetCategories();
            dlCategories.DataBind();
        }
        //this method will return all the products with 
        // the selected CategoryID
        private void GetProducts(int CategoryID)
        {
            ShoppingCart k = new ShoppingCart()
            {
                CategoryID = CategoryID
            };

            dlProducts.DataSource = null;
            dlProducts.DataSource = k.GetAllProducts();
            dlProducts.DataBind();
        }
        // this method will filter the search box with the given name 
        //and will display only the searched items
        private void GetProducts(string ProductNameSearched)
        {
            ShoppingCart k = new ShoppingCart()
            {
                ProductName = ProductNameSearched
            };

            dlProducts.DataSource = null;
            dlProducts.DataSource = k.GetAllProductsBySearch();
            dlProducts.DataBind();
        }

        //private void GetProducts(string CategoryName)
        //{
        //    ShoppingCart k = new ShoppingCart()
        //    {
        //        CategoryName = CategoryName
        //    };

        //    dlProducts.DataSource = null;
        //    dlProducts.DataSource = k.GetAllProductsBySearch();
        //    dlProducts.DataBind();
        //}
        
            //this method will display products when a specific Categori is clicked
        protected void lbtnCategory_Click(object sender, EventArgs e)
        {
            pnlMyCart.Visible = false;
            pnlProducts.Visible = true;
            int CategoryID = Convert.ToInt16((((LinkButton)sender).CommandArgument));
            GetProducts(CategoryID);
             HighlightCartProducts();
        }

        // Redirect to the Default page
        protected void lblLogo_Click(object sender, EventArgs e)
        {
            lblCategoryName.Text = "Popular Products";
            lblProducts.Text = "Product Categories";

            pnlCategories.Visible = true;
            pnlProducts.Visible = true;
            pnlMyCart.Visible = false;
            pnlCheckOut.Visible = false;
            pnlEmptyCart.Visible = false;
            pnlOrderPlacedSuccessfully.Visible = false;

            GetProducts(0);
             HighlightCartProducts();
        }

        //Method which add a product to the shopping cart
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            string ProductQuantity = "1";

            DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;

            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                var checkProduct = dt.AsEnumerable().Where(r => r.Field<string>("ProductID") == ProductID);
                if (checkProduct.Count() == 0)
                {
                    string query = "select * from Products where ProductID = " + ProductID + "";
                    DataTable dtProducts = GetData(query);

                    DataRow dr = dt.NewRow();
                    dr["ProductID"] = ProductID;
                    dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                    dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                    dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                    dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                    dr["ProductQuantity"] = ProductQuantity;
                    dr["AvailableStock"] = lblAvailableStock.Text;
                    dt.Rows.Add(dr);

                    Session["MyCart"] = dt;
                    btnShoppingCart.Text = dt.Rows.Count.ToString();
                }
            }
            else
            {
                string query = "select * from Products where ProductID = " + ProductID + "";
                DataTable dtProducts = GetData(query);

                DataTable dt = new DataTable();

                dt.Columns.Add("ProductID", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Price", typeof(string));
                dt.Columns.Add("ImageUrl", typeof(string));
                dt.Columns.Add("ProductQuantity", typeof(string));
                dt.Columns.Add("AvailableStock", typeof(string));

                DataRow dr = dt.NewRow();
                dr["ProductID"] = ProductID;
                dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                dr["ProductQuantity"] = ProductQuantity;
                dr["AvailableStock"] = lblAvailableStock.Text;
                dt.Rows.Add(dr);

                Session["MyCart"] = dt;
                btnShoppingCart.Text = dt.Rows.Count.ToString();
            }

               HighlightCartProducts();
        }

        //When Add to Cart is clicked, this method will change the back color of the button and 
        //text will be changed as well
        private void HighlightCartProducts()
        {
            if (Session["MyCart"] != null)
            {
                DataTable dtProductsAddedToCart = (DataTable)Session["MyCart"];
                if (dtProductsAddedToCart.Rows.Count > 0)
                {
                    foreach (DataListItem item in dlProducts.Items)
                    {
                        HiddenField hfProductID = item.FindControl("hfProductID") as HiddenField;//hfProductId replace to ProductID
                        if (dtProductsAddedToCart.AsEnumerable().Any(row => hfProductID.Value == row.Field<string>("ProductID")))
                        {
                            //item.BackColor = System.Drawing.Color.Red;
                            Button btnAddToCart = item.FindControl("btnAddToCart") as Button;
                            btnAddToCart.BackColor = System.Drawing.Color.Green;
                            btnAddToCart.Text = "Added To Cart";

                            Image imgGreenStar = item.FindControl("imgStar") as Image;
                            imgGreenStar.Visible = true;
                        }
                    }
                }
            }
        }

        //Method to display Shopping cart products
        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            
           
            GetMyCart();//Display all added products from the shopping cart
            GenerateReview();//Review the product and price
            lblCategoryName.Text = "Your Shopping Cart Products";
            lblProducts.Text = "Customer Details";
           
        }

        //Method to make connection to the database
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string Conn = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection con = new SqlConnection(Conn);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            con.Close();
            return dt;
        }

        // Review shopping cart products and price
        private void GenerateReview()
        {
            long TotalPrice = 0;
            long TotalProducts = 0;
            int productQuantity = 0;
            string productName = "";
            long TotalProductPrice = 0;
            long ProductPrice = 0;



                DataTable dtProducts;
                if (Session["MyCart"] != null)
                {
                    dtProducts = (DataTable)Session["MyCart"];
                }
                else
                {
                    dtProducts = new DataTable();
                }

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<h3>Please review your order!</h3>");

            //Here we generate a row for each order
            if (dtProducts.Rows.Count > 0)
            {
                pnlCheckOut.DataBind();
                dlCartProducts.DataSource = dtProducts;
                dlCartProducts.DataBind();
                foreach (DataListItem item in dlCartProducts.Items)
                {
                    Label ProductName = item.FindControl("lblProductName") as Label;
                    productName = Convert.ToString(ProductName.Text);

                    Label PriceLabel = item.FindControl("lblPrice") as Label;
                    ProductPrice = Convert.ToInt64(PriceLabel.Text);
                    TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox;
                    productQuantity = Convert.ToInt32(ProductQuantity.Text);
                   
                     TotalProductPrice = Convert.ToInt64(PriceLabel.Text) * Convert.ToInt64(ProductQuantity.Text);
                    TotalPrice = TotalPrice + TotalProductPrice;
                    TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);

                    sb.Append(string.Format(@"<tr>
                             <td width = '200px'>{0} * {1}</td>
                            <td>{2}</td><td>€</td>
                            </tr)", productQuantity, productName, TotalProductPrice));
                    sb.Append(string.Format(@"<br/>"));

                }

              
            }
            

            //Here we generate a row for total amount
            sb.Append(string.Format(@"<tr>
                                        <td><b>Total To Pay: </b></td>
                                        <td><b>{0} € </b></td>
                                  </tr>", TotalPrice));

            sb.Append("</table>");



            Session["TotalPrice"] = TotalPrice;
            //Here we export data and make order visible
            lblResult.Text = sb.ToString();
            lblResult.Visible = true;
           
        }

        //Getting data from Database
        private void GetMyCart()
        {
            

            DataTable dtProducts;
            if (Session["MyCart"] != null)
            {
                dtProducts = (DataTable)Session["MyCart"];
            }
            else
            {
                dtProducts = new DataTable();
            }

          

            if (dtProducts.Rows.Count > 0)
            {
                txtTotalProducts.Text = dtProducts.Rows.Count.ToString();
               
              
                btnShoppingCart.Text = dtProducts.Rows.Count.ToString();
                dlCartProducts.DataSource = dtProducts;
                dlCartProducts.DataBind();

                foreach (DataListItem item in dlCartProducts.Items)
                {
                    Label ProductName = item.FindControl("lblProductName") as Label;
                   
                    txtProductName.Text = Convert.ToString(ProductName.Text);
                }
                
                UpdateTotalBill();
              
                pnlMyCart.Visible = true;
                pnlCheckOut.Visible = true;
                pnlEmptyCart.Visible = false;
                pnlCategories.Visible = false;
                pnlProducts.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;

            }
            else
            {
                pnlEmptyCart.Visible = true;
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;

                pnlCategories.Visible = false;
                pnlProducts.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;

                dlCartProducts.DataSource = null;
                dlCartProducts.DataBind();
                txtTotalProducts.Text = "0";
                txtTotalPrice.Text = "0";
                btnShoppingCart.Text = "0";
                txtProductName.Text = "";
            }

          
        }

        //Method to update the total price of the cart products
        private void UpdateTotalBill()
        {
            long TotalPrice = 0;
            long TotalProducts = 0;

            foreach (DataListItem item in dlCartProducts.Items)
            {
                Label PriceLabel = item.FindControl("lblPrice") as Label;
                TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox;
                long ProductPrice = Convert.ToInt64(PriceLabel.Text) * Convert.ToInt64(ProductQuantity.Text);
                TotalPrice = TotalPrice + ProductPrice;
                TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);
            }

            txtTotalPrice.Text = Convert.ToString(TotalPrice);
            txtTotalProducts.Text = Convert.ToString(TotalProducts);

        }

        //Method to increse or decrese the product quantity Which is added to the shopping cart
        protected void txtProductQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txtQuantity = (sender as TextBox);

            DataListItem currentItem = (sender as TextBox).NamingContainer as DataListItem;
            HiddenField ProductID = currentItem.FindControl("hfProductID") as HiddenField;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;

            if (txtQuantity.Text == string.Empty || txtQuantity.Text == "0" || txtQuantity.Text == "1")
            {
                txtQuantity.Text = "1";
            }
            else
            {
                if (Session["MyCart"] != null)
                {
                    if (Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(lblAvailableStock.Text))
                    {
                        DataTable dt = (DataTable)Session["MyCart"];

                        DataRow[] rows = dt.Select("ProductID='" + ProductID.Value + "'");

                        int index = dt.Rows.IndexOf(rows[0]);

                        dt.Rows[index]["ProductQuantity"] = txtQuantity.Text;

                        Session["MyCart"] = dt;
                    }
                    else
                    {
                        lblAvailableStockAlert.Text = "Alert: Product Buyout should not be More than AvailableStock!!";
                        txtQuantity.Text = "1";
                    }
                }
            }

            UpdateTotalBill();

        }

        // Removing product from shopping cart
        protected void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();

            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];

                DataRow drr = dt.Select("ProductID=" + ProductID + " ").FirstOrDefault();

                if (drr != null)
                    dt.Rows.Remove(drr);

                Session["MyCart"] = dt;
            }

            GetMyCart();
        }


      

        //This method will send an Email notification to the User's email address with Order details
        private void SendOrderPlaceAlert(String CustomerName, String CustomerEmailID, string TransactionNo)
        {
            string body = this.PopulateOrderEmailBody(CustomerName, TransactionNo);
            EmailEngine.SendEmail(CustomerEmailID, "24HOURSSHOPPING: Your OrderDetails", body);
        }

        //This method is to track Order status with the transaction number if the Webpage is online
        private string PopulateOrderEmailBody(string customerName, string transactionNo)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/OrderTemplate.htm")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{CustomerName}", customerName);
            body = body.Replace("{OrderNo}", transactionNo);
            body = body.Replace("{TransactionURL}", "http://www.24hourshopping.tk/TrackYourOrder.aspx?ID=" + transactionNo);

            return body;

        }

        //This method is used for Login purpose, user must be logged in before processing payment

        private void AuthenticateUser()
        {   
            if(Session["Username"]== null)//Check if User is not logged in.
            {
                Response.Redirect("~/UserAccount/Login.aspx");//Redirecting page to the Login page
            }
           
        }

        //Here We declare a method for Paypal checkout process
        protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        {
           

            //Authenticate user signin first
            AuthenticateUser();

            // Paypal process starts here
            NVPAPICaller nvpapicaller = new NVPAPICaller();

            string token = "";
            //string PayerID = "";
            string retMsg = "";
            string productids = string.Empty;

            
            DataTable dt;

            if (Session["MyCart"] != null)
            {
                dt = (DataTable)Session["MyCart"];

                ShoppingCart k = new ShoppingCart()
                {
                    CustomerName = txtCustomerName.Text,
                    CustomerEmailID = txtCustomerEmailID.Text,
                    CustomerAddress = txtCustomerAddress.Text,
                    CustomerPhoneNo = txtCustomerPhoneNo.Text,
                    TotalProducts = Convert.ToInt32(txtTotalProducts.Text),
                    TotalPrice = Convert.ToInt32(txtTotalPrice.Text),
                    ProductList = productids,
                    PaymentMethod = rblPaymentMethod.SelectedItem.Text,
                    ProductName = txtProductName.Text
                };

                DataTable dtResult = k.SaveCustomerDetails();
               

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ShoppingCart SaveProducts = new ShoppingCart()
                    {
                        CustomerID = Convert.ToInt32(dtResult.Rows[0][0]),
                        ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]),
                        TotalProducts = Convert.ToInt32(dt.Rows[i]["ProductQuantity"])
                        
                    };

                   SaveProducts.SaveCustomerProducts();

                }

                SendOrderPlaceAlert(txtCustomerName.Text, txtCustomerEmailID.Text, Convert.ToString(dtResult.Rows[0][0]));

                Session["OrderNo"] = Convert.ToString(dtResult.Rows[0][0]);

                txtCustomerAddress.Text = string.Empty;
                txtCustomerEmailID.Text = string.Empty;
                txtCustomerName.Text = string.Empty;
                txtCustomerPhoneNo.Text = string.Empty;
                txtTotalPrice.Text = "0";
                txtTotalProducts.Text = "0";
                txtProductName.Text = string.Empty;

               
                Session["TotalPrice"] = k.TotalPrice;

                if (Session["TotalPrice"] != null)
                {
                    string totalAmount = Session["TotalPrice"].ToString();

                     bool ret = nvpapicaller.ShortcutExpressCheckout(totalAmount, ref token, ref retMsg, dt);
                 

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


                Response.Redirect("~/Checkout/CheckoutStart.aspx");
            }
        }

        // It will redirect to the Default page
        protected void Continue_Click(object sender, EventArgs e)
        {
            lblCategoryName.Text = "Popular Products";
            lblProducts.Text = "Product Categories";

            pnlCategories.Visible = true;
            pnlProducts.Visible = true;
            pnlMyCart.Visible = false;
            pnlCheckOut.Visible = false;
            pnlEmptyCart.Visible = false;
            pnlOrderPlacedSuccessfully.Visible = false;

            GetProducts(0);
            HighlightCartProducts();
        }


        //Button click method for searching product from search box
        protected void btnSearchProduct_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                string ProductNameSearched = txtSearch.Text;//need correction here
            
                GetProducts(ProductNameSearched);
                txtSearch.Text = "";
                lblCategoryName.Text = "Products By Search ";
                lblProducts.Text = "Product Categories";

                pnlCategories.Visible = true;
                pnlProducts.Visible = true;
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;
          
                HighlightCartProducts();
            }
            else
            {
                lblCategoryName.Text = "No Search Word Found In Search Box";             
                lblProducts.Text = "Product Categories";

                pnlCategories.Visible = true;
                pnlProducts.Visible = true;
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;               
                HighlightCartProducts();
            }
        }


        ////OnClick login method
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            

            if (btnLogin.Text == "Login")
            {
                Response.Redirect("~/UserAccount/Login.aspx");
               
                pnlCategories.Visible = false;
                pnlProducts.Visible = false;
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UserAccount/Login.aspx");
                
                pnlCategories.Visible = false;
                pnlProducts.Visible = false;
                pnlMyCart.Visible = false;
                pnlCheckOut.Visible = false;
                pnlEmptyCart.Visible = false;
                pnlOrderPlacedSuccessfully.Visible = false;
            }
        }

        ////OnClickRegistration method
        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            lblTest.Text = "SIGN UP";
            Response.Redirect("~/UserAccount/Registration.aspx");

            pnlCategories.Visible = false;
            pnlProducts.Visible = false;
            pnlMyCart.Visible = false;
            pnlCheckOut.Visible = false;
            pnlEmptyCart.Visible = false;
            pnlOrderPlacedSuccessfully.Visible = false;

            
        }


    }
}