<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign-Up</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="formSignUp" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>Sign-Up</h2>
                <h2>As an Employee</h2>
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
                <div class="form-group">
                    <label for="txtUniqueCode">Unique Employee Code</label>
                    <input id="txtUniqueCode" runat="server" type="text" />
                </div>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="true" Text="" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnSignup" runat="server" class="btn-login" Text="SignUp" OnClick="btnSignUp_Click" />
            </div>
        </div>
    </form>
</body>
</html>
