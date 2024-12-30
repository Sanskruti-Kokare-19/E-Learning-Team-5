<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveManagement.aspx.cs" Inherits="le.LeaveManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>Leave Management Form</h2>
  <table>
      <tr>
          <td>From Date:</td>
          <td><asp:Calendar ID="calFromDate" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
              <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
              <DayStyle BackColor="#CCCCCC" />
              <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
              <OtherMonthDayStyle ForeColor="#999999" />
              <SelectedDayStyle BackColor="#333399" ForeColor="White" />
              <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
              <TodayDayStyle BackColor="#999999" ForeColor="White" />
              </asp:Calendar></td>
      </tr>
      <tr>
          <td>To Date:</td>
          <td><asp:Calendar ID="calToDate" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
              <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
              <DayStyle BackColor="#CCCCCC" />
              <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
              <OtherMonthDayStyle ForeColor="#999999" />
              <SelectedDayStyle BackColor="#333399" ForeColor="White" />
              <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
              <TodayDayStyle BackColor="#999999" ForeColor="White" />
              </asp:Calendar></td>
      </tr>
      <tr>
          <td>Total Leave Days (Excluding Weekends):</td>
          <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
      </tr>
      <tr>
          <td colspan="2">
              <asp:Button ID="btnCalculate" runat="server" Text="Calculate Days" OnClick="btnCalculate_Click" />
          </td>
      </tr>
  </table>
        </div>
    </form>
</body>
</html>
