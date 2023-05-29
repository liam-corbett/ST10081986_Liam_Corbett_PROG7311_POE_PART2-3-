<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeHomePage.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.EmployeeHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Home Page</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="formEmployeeHomePage" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>
                    <asp:Label ID="lblWelcome" runat="server" Text="" Visible="true"></asp:Label></h2>
                <div class="form-group">
                    <asp:Button ID="btnAddNewFarmer" runat="server" Text="Add New Farmer" OnClick="btnAddNewFarmer_Click" class="btn-login" />
                    <asp:Button ID="btnViewProductsByFarmer" runat="server" Text="View Products by Farmer" OnClick="btnViewProductsByFarmer_Click" class="btn-login" Style="margin-top: 10px;" />
                    <asp:Button ID="btnSignOut" runat="server" Text="SignOut" OnClick="btnSignOut_Click" class="btn-login" Style="margin-top: 10px;" />

                </div>
            </div>
        </div>
    </form>
</body>
</html>
