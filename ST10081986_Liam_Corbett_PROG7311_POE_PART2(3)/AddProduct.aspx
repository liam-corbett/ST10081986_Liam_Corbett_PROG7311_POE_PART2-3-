<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.AddProduct" %>
<%@ Assembly Name="System" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddFarmer</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
    <style>
        .calendar-icon 
        {
            background-color: #c0c0c0;
            padding: 5px;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="formAddProduct" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>Add a new Product</h2>
                <div class="form-group">
                    <label for="txtProductName">Product Name</label>
                    <input id="txtProductName" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtProductType">Product Type</label>
                    <select id="txtProductType" runat="server">
                        <option value="Fruits">Fruits</option>
                        <option value="Vegetables">Vegetables</option>
                        <option value="Spices and Seasonings">Spices and Seasonings</option>
                        <option value="Vegan Products">Vegan Products</option>
                        <option value="Dairy Products">Dairy Products</option>
                        <option value="Meat and Poultry">Meat and Poultry</option>
                        <option value="Grains and Cereals">Grains and Cereals</option>
                        <option value="Organic Products">Organic Products</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtSupplyDate">Supply Date</label>
                    <asp:TextBox ID="txtSupplyDate" runat="server" Enabled="false"></asp:TextBox>
                    <asp:Calendar ID="calSupplyDate" runat="server" Visible="false" OnSelectionChanged="calSupplyDate_SelectionChanged"></asp:Calendar>
                    <div class="form-group">

                        <asp:ImageButton ID="btnCalendar" runat="server" ImageUrl="~/Images/calanderPNG.png" AlternateText="Select Date" OnClick="btnCalendar_Click" CssClass="calendar-icon" Height="37px" Width="49px" Margin-Right="40px" />

                    </div>

                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="true" Text="" ForeColor="Red"></asp:Label>
                    <asp:Button ID="btnAdd" runat="server" class="btn-login" Text="Add Product" OnClick="btnAdd_Click" />
                      <asp:Button ID="btnHome" runat="server" class="btn-login" Text="Home" OnClick="btnHome_Click" Style="margin-top: 10px;"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
