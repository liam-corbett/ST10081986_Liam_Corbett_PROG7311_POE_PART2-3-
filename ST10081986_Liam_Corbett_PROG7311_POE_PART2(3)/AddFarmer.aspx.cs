using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_
{
    public partial class AddFarmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method for when the create farmer button is pressed
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Getting the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            //Declarations
            string username = txtUsername.Value.Trim();
            string name = txtName.Value.Trim();
            string surname = txtSurname.Value.Trim();
            string email = txtEmail.Value.Trim();
            string cellphone = txtCell.Value.Trim();
            string password = txtPassword.Value;
            string passwordConfirm = txtPasswordConfirm.Value;

            //Checking if the fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cellphone) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(passwordConfirm))
            {
                lblErrorMessage.Text = "Please fill in all fields.";
                return;
            }

            //Checking that the passwords match
            if (password != passwordConfirm)
            {
                lblErrorMessage.Text = "Passwords do not match.";
                return;
            }

            //Checking if the name and surname contain only letters
            if (!IsAllLetters(name) || !IsAllLetters(surname))
            {
                lblErrorMessage.Text = "Name and surname should only contain letters.";
                return;
            }

            //Checking if the cellphone doesn't contain letters
            if (!IsAllNumbers(cellphone))
            {
                lblErrorMessage.Text = "Cellphone should only contain numbers.";
                return;
            }

            //Checking if the username is already taken
            if (IsUsernameTaken(username))
            {
                lblErrorMessage.Text = "Username is already taken. Please choose a different username.";
                return;
            }

            try
            {
                //Creating a bool variable equal to the method
                bool userId = InsertUser(username, name, surname, email, cellphone, password);

                //If the method is a success
                if (userId)
                {
                    //Creating a bool variable equal to the method
                    bool farmerInserted = InsertFarmer(name, surname, email, cellphone);

                    //If the method is a success
                    if (farmerInserted)
                    {
                        Response.Redirect("EmployeeHomePage.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "Add Farmer failed. Please try again.";
                        
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Add Farmer failed.Please try again.";


                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        //Method to insert the farmer into the users table
        private bool InsertUser(string username, string name, string surname, string email, string cellphone, string password)
        {
            //Getting the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Users (Username, Name, Surname, Email, Cellphone, Password, UserRole) " +
                        "VALUES (@Username, @Name, @Surname, @Email, @Cellphone, @Password, 'farmer')";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Cellphone", cellphone);
                    command.Parameters.AddWithValue("@Password", password);

                    command.ExecuteScalar();
                }
                return true;
            }

            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
                return false;
            }
        
            
            
        }

        //Method to insert the farmer into the farmers table
        private bool InsertFarmer(string name, string surname, string email, string cellphone)
        {
            try
            {
                //Getting the conenction string
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Getting the userId based on the provided name from the Users table
                    string selectQuery = "SELECT UserID FROM Users WHERE Name = @Name";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@Name", name);

                    int userId = (int)selectCommand.ExecuteScalar();

                    //Inserting the farmer data into the Farmers table
                    string insertQuery = "INSERT INTO Farmers (UserID, Name, Surname, Email, Cellphone) " +
                                         "VALUES (@UserID, @Name, @Surname, @Email, @Cellphone)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@UserID", userId);
                    insertCommand.Parameters.AddWithValue("@Name", name);
                    insertCommand.Parameters.AddWithValue("@Surname", surname);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@Cellphone", cellphone);
                    
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
                return false;
            }
        }

        //Method to check if the username is already taken
        private bool IsUsernameTaken(string username)
        {
            //Getting the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE LOWER(Username) = LOWER(@Username)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();

                    return count > 0;
                }
            }
        }

        //Method to check if fields are all letters
        private bool IsAllLetters(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        //Method to check if the cell is all numbers
        private bool IsAllNumbers(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        //Method for when the home button is clicked
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeHomePage.aspx");
        }
    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}