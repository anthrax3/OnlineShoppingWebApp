using OnlineShoppingWebApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShoppingWebApp.Account
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
           
            txtFirstName.CausesValidation = true;
            txtLastName.CausesValidation = true;
            txtUsername.CausesValidation = true;
            txtPassword.CausesValidation = true;
            txtConfirm.CausesValidation = true;
            txtEmail.CausesValidation = true;
            txtAddress.CausesValidation = true;
            txtCity.CausesValidation = true;
            txtCountry.CausesValidation = true;

            //Create new User

            User user = new User(txtFirstName.Text, txtLastName.Text, txtUsername.Text, txtPassword.Text, txtConfirm.Text, txtEmail.Text, txtAddress.Text,
                txtCity.Text, txtCountry.Text);
            //Check if user input is not null
            if(user != null)
            {
                lblResult.Text = ConnectionClass.RegisterUser(user);
            }
            else
            {
                lblResult.Text = "Input Is Missing!Input Again!";
            }
            
        }
    }
}