<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FarmerHomePage.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.FarmerHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Farmer Home Page</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="formFarmerHomePage" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>
                    <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label></h2>
                <div class="options">
                    <asp:Button ID="btnAddNewProduct" runat="server" Text="Add New Product" OnClick="btnAddNewProduct_Click" class="btn-login" />
                    <asp:Button ID="btnSignOut" runat="server" Text="SignOut" OnClick="btnSignOut_Click" class="btn-login" Style="margin-top: 10px;" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
