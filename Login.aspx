<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Learning.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="stylesheet" href="assets/css/bootstrap.min.css">

    <link rel="stylesheet" href="assets/plugins/fontawesome/css/fontawesome.min.css">
    <link rel="stylesheet" href="assets/plugins/fontawesome/css/all.min.css">

    <link rel="stylesheet" href="assets/css/style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="main-wrapper login-body">
                <div class="login-wrapper">
                    <div class="container">
                        <div class="loginbox">
                            <div class="login-right">
                                <div class="login-right-wrap">
                                    <h1>Login</h1>
                                    <p class="account-subtitle">Access to our dashboard</p>
                                        <div class="form-group">
                                            <label class="form-control-label">Email Address</label>
                                            <asp:TextBox ID="EmailTxt" class="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-control-label">Password</label>
                                            <div class="pass-group">
                                                <asp:TextBox ID="PasswordTxt" class="form-control pass-input" runat="server" TextMode="Password"></asp:TextBox>
                                                <span class="fas fa-eye toggle-password"></span>
                                            </div>
                                        </div>
                                        
                                    <asp:Button ID="loginBtn" class="btn btn-lg btn-block btn-primary" runat="server" Text="Login" OnClick="loginBtn_Click" />
                                        <div class="login-or">
                                            <span class="or-line"></span>
                                            <span class="span-or">or</span>
                                        </div>
                                        <div class="text-center dont-have">Don't have an account yet? <a href="#">Register</a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <script src="assets/js/jquery-3.5.1.min.js"></script>

            <script src="assets/js/popper.min.js"></script>
            <script src="assets/js/bootstrap.min.js"></script>

            <script src="assets/js/feather.min.js"></script>

            <script src="assets/js/script.js"></script>
        </div>
    </form>
</body>
</html>
