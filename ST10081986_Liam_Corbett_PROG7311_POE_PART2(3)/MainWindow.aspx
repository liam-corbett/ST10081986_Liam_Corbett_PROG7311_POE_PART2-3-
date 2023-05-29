<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainWindow.aspx.cs" Inherits="ST10081986_Liam_Corbett_PROG7311_POE_PART2_3_.MainWindow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Window</title>
    <link href="~/Styles/LoginStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="center-container">
            <div class="container">
                <h2>Welcome</h2>
                <h2>Please Choose one of the Following</h2>
                <asp:Button ID="btnLogin" runat="server" class="btn-login" Text="Login" OnClick="btnLogin_Click" />

                <asp:Button ID="btnSignup" runat="server" class="btn-login" Text="SignUp" OnClick="btnSignUp_Click" Style="margin-top: 10px;" />

            </div>
        </div>
    </form>
</body>
</html>
