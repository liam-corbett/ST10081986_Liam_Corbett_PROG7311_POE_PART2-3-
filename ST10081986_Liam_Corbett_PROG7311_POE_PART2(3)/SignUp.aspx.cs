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
    public partial class SignUp : System.Web.UI.Page
    {
        //Method for when the sign up button is pressed
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //Creating a variable that points to the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            //Declarations
            string username = txtUsername.Value.Trim();
            string name = txtName.Value.Trim();
            string surname = txtSurname.Value.Trim();
            string email = txtEmail.Value.Trim();
            string cellphone = txtCell.Value.Trim();
            string password = txtPassword.Value;
            string confirmPassword = txtPasswordConfirm.Value;
            string uniqueCode = txtUniqueCode.Value.Trim();

            //Checking if any of the fields are blank
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cellphone) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(uniqueCode))
            {
                lblErrorMessage.Text = "Please fill in all fields.";
                return;
            }

            //Checking if the name and surname contain only letters
            if (!IsAllLetters(name) || !IsAllLetters(surname))
            {
                lblErrorMessage.Text = "Name and surname should only contain letters.";
                return;
            }

            //Checking if the cellphone contains only numbers
            if (!IsAllNumbers(cellphone))
            {
                lblErrorMessage.Text = "Cellphone should only contain numbers.";
                return;
            }

            //Checking if the unique employee code is valid
            if (uniqueCode != "007")
            {
                lblErrorMessage.Text = "Invalid unique employee code.";
                return;
            }

            //Checking if the password and confirm password match
            if (password != confirmPassword)
            {
                lblErrorMessage.Text = "Passwords do not match.";
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Inserting the employee details into the database
                    string insertQuery = "INSERT INTO Users (Username, Name, Surname, Email, Cellphone, Password, UserRole) " +
                        "VALUES (@Username, @Name, @Surname, @Email, @Cellphone, @Password, 'employee')";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Cellphone", cellphone);
                    command.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    //Successful sign-up
                    if (rowsAffected > 0)
                    {
                        
                        Response.Redirect("Login.aspx");
                    }

                    //Unsuccessful sign-up
                    else
                    {
                        lblErrorMessage.Text = "Sign-up failed. Please try again.";
                    }
                }

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        //Method to check if the name and surname contain only letters
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

        //Method to check if the cellphone contains only numbers
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

    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}