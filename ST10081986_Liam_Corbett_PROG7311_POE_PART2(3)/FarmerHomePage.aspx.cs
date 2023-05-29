using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_
{
    public partial class FarmerHomePage : System.Web.UI.Page
    {
        //Method for when the page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            //If the page is loaded successfully
            if (!IsPostBack)
            {
                //Checking if the user is logged in and then getting the authentication ticket
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    //Decrypting the authentication ticket
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    //Getting the username from the authentication ticket
                    string username = ticket.Name;

                    lblWelcome.Text = "Welcome, " + username;
                }
                else
                {
                    lblWelcome.Text = "Welcome, Farmer";
                }
            }
        }

        //Method for when the add new product button is clicked
        protected void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        //Method for when the SignOut button is pressed
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainWindow.aspx");
        }
    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}