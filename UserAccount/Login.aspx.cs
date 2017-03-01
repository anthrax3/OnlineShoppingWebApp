using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShoppingWebApp.BusinessLayer;

namespace OnlineShoppingWebApp.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            rfvUserName.Enabled = true;
            rfvPassword.Enabled = true;
            rfvUserName.Validate();
            rfvPassword.Validate();
            //passing login data from loginpage to UserLogin method of ConnectionClass
            User user = ConnectionClass.UserLogin(txtUserName.Text, txtPassword.Text);

            if(user != null)
            {
                Session["Username"] = user.LastName;

                //Starts
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblError.Text = "Login failed! Check Username and Password again!!";
            }
        }
    }
}