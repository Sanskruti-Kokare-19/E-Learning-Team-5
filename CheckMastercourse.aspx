<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckMastercourse.aspx.cs" Inherits="Elearning.CheckMastercourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Course Details</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Master Course Details</h2>
            <div class="form-group">
                <label for="DropDownList1">Course Master:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="DropDownList2">Course Name:</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Submit" />
            <div class="mt-3">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateColumns="True">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
