<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendNotification.aspx.cs" Inherits="E_Learning.SendNotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <h2>Send Notification To Users</h2>

    <label for="ddlUsers">Select User:</label>
    <asp:DropDownList ID="ddlUsers" runat="server"></asp:DropDownList>

    <br /><br />

    <label for="txtNotification">Notification Message:</label>
    <asp:TextBox ID="txtNotification" runat="server" TextMode="MultiLine" Rows="3" Columns="30"></asp:TextBox>

    <br /><br />

    <asp:Button ID="btnSend" runat="server" Text="Send Notification" OnClick="btnSend_Click" />

    <br /><br />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

</div>
    </form>
</body>
</html>
