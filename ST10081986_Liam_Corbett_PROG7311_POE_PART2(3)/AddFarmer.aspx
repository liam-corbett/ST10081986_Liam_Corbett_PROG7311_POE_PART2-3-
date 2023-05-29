<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFarmer.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.AddFarmer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddFarmer</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="formAddFarmer" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>Add a new Farmer</h2>
                <div class="form-group">
                    <label for="txtUsername">Username</label>
                    <input id="txtUsername" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtName">Name</label>
                    <input id="txtName" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtSurname">Surname</label>
                    <input id="txtSurname" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtEmail">Email</label>
                    <input id="txtEmail" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtCell">Cell#</label>
                    <input id="txtCell" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <input id="txtPassword" runat="server" type="password" />
                </div>
                <div class="form-group">
                    <label for="txtPasswordConfirm">Confirm Password</label>
                    <input id="txtPasswordConfirm" runat="server" type="password" />
                </div>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="true" Text="" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnCreate" runat="server" class="btn-login" Text="Create" OnClick="btnCreate_Click" />
                 <asp:Button ID="btnHome" runat="server" class="btn-login" Text="Home" OnClick="btnHome_Click" Style="margin-top: 10px;"/>
            </div>
        </div>
    </form>
</body>
</html>
