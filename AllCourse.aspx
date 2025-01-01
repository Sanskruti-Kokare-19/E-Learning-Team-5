<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="ELearningProject.AllCourse" %>

<!DOCTYPE html>
<html>
<head>
    <title>All Courses</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>All Courses List</h2>

            <!-- Dropdown for Master Course -->
            <label for="ddlMasterCourse">Select Master Course:</label>
              <asp:DropDownList ID="ddlMasterCourse" runat="server" />
           <%-- <asp:DropDownList ID="ddlMasterCourse" runat="server">
                <asp:ListItem Text="Select a Course" Value="0" />
                <asp:ListItem Text="Full Stack Java" Value="1" />
                <asp:ListItem Text="Full Stack DotNet" Value="2" />
            </asp:DropDownList>--%>
            <br /><br />

            <!-- Fetch Button -->
            <asp:Button ID="btnFetch" runat="server" Text="Fetch Data" OnClick="btnFetch_Click" />
            <br /><br />

            <!-- DataList for Displaying Courses -->
            <asp:DataList ID="dlCourses" runat="server" RepeatColumns="3" CellPadding="10">
                <ItemTemplate>
                    <div style="border: 1px solid #ddd; padding: 10px; text-align: center;">
                        <img src='<%# Eval("CourseImage") %>' alt="Course Image" style="width: 100px; height: 100px;" />
                        <h4><%# Eval("CourseName") %></h4>
                        <p>Price: $<%# Eval("CoursePrice") %></p>
                        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>