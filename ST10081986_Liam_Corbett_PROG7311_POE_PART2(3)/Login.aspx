<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>Login</h2>
                <div class="form-group">
                    <label for="txtUsername">Username</label>
                    <input id="txtUsername" runat="server" type="text" />
                </div>
                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <input id="txtPassword" runat="server" type="password" />
                </div>

                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="true" Text="" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnLogin" runat="server" class="btn-login" Text="Login" OnClick="btnLogin_Click" />

            </div>
        </div>

    </form>
</body>
</html>
