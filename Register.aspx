<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="E_Learning.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
    <title>E-Learning</title>
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
                                    <h1>Register</h1>
                                    <p class="account-subtitle">Access to our dashboard</p>

                                        <div class="form-group">
                                            <label class="form-control-label">Name</label>
                                            <asp:TextBox ID="NameTxt" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-control-label">Email Address</label>
                                            <asp:TextBox ID="EmailTxt" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    <div class="form-group">
                                        <label class="form-control-label">Contact No</label>
                                        <asp:TextBox ID="contactTxt" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-control-label">Emergency Contact No</label>
                                        <asp:TextBox ID="eContactTxt" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                        <div class="form-group">
                                            <label class="form-control-label">Password</label>
                                            <asp:TextBox ID="PasswordTxt" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group mb-0">
                                            <asp:Button ID="RegisBtn" runat="server" class="btn btn-lg btn-block btn-primary" Text="Register" OnClick="RegisBtn_Click" />
                                        </div>

                                    <div class="login-or">
                                        <span class="or-line"></span>
                                        <span class="span-or">or</span>
                                    </div>

                                    <div class="text-center dont-have">Already have an account? <a href="Login.aspx">Login</a></div>
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
