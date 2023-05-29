using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method for when the add product button is pressed
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Getting the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            //Declarations
            string productName = txtProductName.Value.Trim();
            string productType = txtProductType.Value.Trim();
            string supplyDate = txtSupplyDate.Text.Trim();

            //Checking to see if the fields are emnpty
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productType) || string.IsNullOrEmpty(supplyDate))
            {
                lblErrorMessage.Text = "Please fill in all fields.";
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Getting the logged-in farmer's ID
                    int farmerId = GetLoggedInFarmerId(); 

                    //Inserting the product details into the database
                    string insertQuery = "INSERT INTO Products (FarmerID, ProductName, ProductType, SupplyDate) " +
                                         "VALUES (@FarmerId, @ProductName, @ProductType, @SupplyDate)";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@FarmerId", farmerId);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ProductType", productType);
                    command.Parameters.AddWithValue("@SupplyDate", supplyDate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {                    
                        Response.Redirect("FarmerHomePage.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "Product addition failed. Please try again.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        //Method to get the logged in farmers ID
        private int GetLoggedInFarmerId()
        {
            //Getting the farmers authentication ticket
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                //Decrypting the authentication ticket
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                //Getting the username from the authentication ticket
                string username = ticket.Name;

                //Declaring the farmer ID
                int farmerId = 0;

                try
                {
                    //Establishing a database connection
                    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        //Retrieving the farmerID from the database
                        string query = "SELECT FarmerID FROM Farmers INNER JOIN Users ON Farmers.UserID = Users.UserID WHERE Users.Username = @Username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Username", username);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            farmerId = Convert.ToInt32(result);
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Error: " + ex;
                }

                //Returning the logged-in farmer's ID
                return farmerId;
            }

            //Returning 0 if the user is not logged in or the authentication cookie is not found
            return 0;
        }

        //Method to turn the visibility of the calander off
        protected void btnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            calSupplyDate.Visible = !calSupplyDate.Visible;
        }

        //Method to move the text from the calander to the calander text field
        protected void calSupplyDate_SelectionChanged(object sender, EventArgs e)
        {
            txtSupplyDate.Text = calSupplyDate.SelectedDate.ToShortDateString();
            calSupplyDate.Visible = false;
        }

        //Method for when the home button is clicked
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("FarmerHomePage.aspx");
        }
    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}
