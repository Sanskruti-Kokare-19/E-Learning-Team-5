<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="Elearning.Topic" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Topic</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card shadow-sm">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title mb-0">Add Topic</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="DropDownList1">Course Name</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="TextBox1">Topic Name</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter topic name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="TextBoxUrl">YouTube URL</label>
                        <asp:TextBox ID="TextBoxUrl" runat="server" CssClass="form-control" placeholder="Enter YouTube URL"></asp:TextBox>
                    </div>
                    <div class="text-left">
                        <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.4.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
