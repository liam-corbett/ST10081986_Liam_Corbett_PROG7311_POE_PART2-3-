using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_
{
    public partial class MainWindow : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method for when the login button is pressed
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //Method for when the sign up button is pressed
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}