using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        //Method for when the page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            //If the page is loaded successfully
            if (!IsPostBack)
            {
                //Calling the methods to populate
                gridProducts.Visible = false;
                PopulateFarmersDropdown();
                PopulateProductTypesDropdown();
                
            }
        }

        //Method to populate the drop down list for the farmers
        private void PopulateFarmersDropdown()
        {
            //Getting the connection string and formulating the query
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT DISTINCT Name FROM Farmers ORDER BY Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string farmerName = reader["Name"].ToString();
                        txtFarmers.Items.Add(new ListItem(farmerName));
                    }
                }
            }
        }

        //Method to populate the product type drop down list
        private void PopulateProductTypesDropdown()
        {
            txtProductType.Items.Add(new ListItem("All", ""));
            txtProductType.Items.Add(new ListItem("Fruits", "Fruits"));
            txtProductType.Items.Add(new ListItem("Vegetables", "Vegetables"));
            txtProductType.Items.Add(new ListItem("Spices and Seasonings", "Spices and Seasonings"));
            txtProductType.Items.Add(new ListItem("Vegan Products", "Vegan Products"));
            txtProductType.Items.Add(new ListItem("Dairy Products", "Dairy Products"));
            txtProductType.Items.Add(new ListItem("Meat and Poultry", "Meat and Poultry"));
            txtProductType.Items.Add(new ListItem("Grains and Cereals", "Grains and Cereals"));
            txtProductType.Items.Add(new ListItem("Organic Products", "Organic Products"));
        }

        //Method to bind the data from the database products to the table
        private void BindProductData(string farmer, string startDate, string endDate, string productType)
        {
            //Getting the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductName, ProductType, CONVERT(date, SupplyDate) AS SupplyDate FROM Products WHERE ";

                //Applying the filter conditions to this list
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(farmer))
                {
                    conditions.Add("FarmerID = @FarmerID");
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    conditions.Add("SupplyDate >= @StartDate");
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    conditions.Add("SupplyDate <= @EndDate");
                }
                if (!string.IsNullOrEmpty(productType))
                {
                    conditions.Add("ProductType = @ProductType");
                }

                //Adding to the query and joining the conditions
                query += string.Join(" AND ", conditions);

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //Setting the parameter values
                    if (!string.IsNullOrEmpty(farmer))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", farmer);
                    }
                    if (!string.IsNullOrEmpty(startDate))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(startDate));
                    }
                    if (!string.IsNullOrEmpty(endDate))
                    {
                        cmd.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(endDate));
                    }
                    if (!string.IsNullOrEmpty(productType))
                    {
                        cmd.Parameters.AddWithValue("@ProductType", productType);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //Setting the data source
                    gridProducts.DataSource = dt;
                    gridProducts.DataBind();
                }
            }
        }

        //Method to get the farmer ID
        private int GetFarmerID(string farmerName)
        {
            //Declaring the farmerID
            int farmerID = 0;

            //Getting the farmerID based on the farmer name
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT FarmerID FROM Farmers WHERE Name = @FarmerName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandTimeout = 120;
                    cmd.Parameters.AddWithValue("@FarmerName", farmerName);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        farmerID = id;
                    }
                }
            }

            return farmerID;
        }

        //Method for when the filter button is clicked
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //Declarations
            string farmerName = txtFarmers.SelectedValue;
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            string productType = txtProductType.SelectedValue;

            //Getting the farmer ID from the farmer name
            int farmerID = GetFarmerID(farmerName);
            string farmerIDString = farmerID.ToString(); 

            //Calling the method
            BindProductData(farmerIDString, startDate, endDate, productType);

            //Showing the Grid View the GridView
            gridProducts.Visible = true;
        }

        //Method to set the calander start date text field
        protected void calStartDate_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = calStartDate.SelectedDate;
            txtStartDate.Text = selectedDate.ToShortDateString();
            calStartDate.Visible = false;
        }

        //Method to make the calander tool visable
        protected void btnStartDateCalendar_Click(object sender, ImageClickEventArgs e)
        {
            calStartDate.Visible = !calStartDate.Visible;
        }

        //Method to set the calander end date text field
        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = calEndDate.SelectedDate;
            txtEndDate.Text = selectedDate.ToShortDateString();
            calEndDate.Visible = false;
        }

        //Method to make the calander tool visable
        protected void btnEndDateCalendar_Click(object sender, ImageClickEventArgs e)
        {
            calEndDate.Visible = !calEndDate.Visible;
        }

        //Method for when the home button is clicked
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeHomePage.aspx");
        }
    }
    //----------------------------------------...ooo000 END OF CLASS 000ooo...--------------------------------------------------//
}
