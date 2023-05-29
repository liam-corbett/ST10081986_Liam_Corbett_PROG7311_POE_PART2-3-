<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.ViewProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products</title>
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
    <form id="formViewFarmer" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>View Products</h2>
                <div class="form-group">
                    <label for="txtFarmers">Select Farmer</label>
                    <asp:DropDownList ID="txtFarmers" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtStartDate">Start Date</label>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    <asp:Calendar ID="calStartDate" runat="server" Visible="false" OnSelectionChanged="calStartDate_SelectionChanged"></asp:Calendar>
                    <div class="form-group">
                        <asp:ImageButton ID="btnStartDateCalendar" runat="server" ImageUrl="~/Images/calanderPNG.png" AlternateText="Select Start Date" OnClick="btnStartDateCalendar_Click" CssClass="calendar-icon" Height="37px" Width="49px" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtEndDate">End Date</label>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    <asp:Calendar ID="calEndDate" runat="server" Visible="false" OnSelectionChanged="calEndDate_SelectionChanged"></asp:Calendar>
                    <div class="form-group">
                        <asp:ImageButton ID="btnEndDateCalendar" runat="server" ImageUrl="~/Images/calanderPNG.png" AlternateText="Select End Date" OnClick="btnEndDateCalendar_Click" CssClass="calendar-icon" Height="37px" Width="49px" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtProductType">Product Type</label>
                    <asp:DropDownList ID="txtProductType" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnFilter" runat="server" class="btn-login" Text="Filter" OnClick="btnFilter_Click" />
                 <asp:Button ID="btnHome" runat="server" class="btn-login" Text="Home" OnClick="btnHome_Click" Style="margin-top: 10px;"/>
                <br />
                <br />
                <asp:GridView ID="gridProducts" runat="server" CssClass="table table-striped" Visible="false" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="ProductType" HeaderText="Product Type" />
                        <asp:BoundField DataField="SupplyDate" HeaderText="Supply Date" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
