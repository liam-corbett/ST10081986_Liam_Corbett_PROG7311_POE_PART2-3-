using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method for when the login button is pressed
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Decalrations
            string username = txtUsername.Value.Trim();
            string password = txtPassword.Value;

            //Checking is the Username and Passwords are not blank
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Text = ("Ensure both fields are filled.");
                return;
            }

            //Checking the user credentials against those in the database and getting user role
            string userRole = AuthenticateAndGetUserRole(username, password);

            //If the username and password is invalid
            if (string.IsNullOrEmpty(userRole))
            {
                lblErrorMessage.Text = ("Invalid username or password.");
                return;
            }

            //Creating an authentication ticket
            CreateAuthenticationTicket(username, userRole);

            //Redirect based on user role
            if (userRole == "employee")
            {
                Response.Redirect("EmployeeHomePage.aspx");
            }
            else if (userRole == "farmer")
            {
                Response.Redirect("FarmerHomePage.aspx");
            }
            else
            {
                lblErrorMessage.Text = ("Invalid user role.");
            }
        }

        //Method to authenticate the user and get the user role
        private string AuthenticateAndGetUserRole(string username, string password)
        {
            //Database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserRole FROM Users WHERE LOWER(Username) = LOWER(@Username) AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    return result?.ToString();
                }
            }
        }


        //Method to create an authentication ticket in order to authenticate and track the user accross the webapp
        private void CreateAuthenticationTicket(string username, string userRole)
        {
            //Creating an authentication ticket with the username as the name and user role as the data
            var ticket = new FormsAuthenticationTicket
            (
                1,                                  //Version
                username,                           //Username
                DateTime.Now,                       //Issue date
                DateTime.Now.AddMinutes(30),        //Expiration date
                false,                              //Persistent cookie
                userRole                            //User role
            );

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            //Creating a new authentication cookie and adding it to the response
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
        }
    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}