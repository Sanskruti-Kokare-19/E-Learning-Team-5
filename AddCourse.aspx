<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="ELearningProject.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 50%; margin: 50px auto;">
            <h2>Add Course</h2>
            <asp:Label ID="lblMasterName" runat="server" Text="Select Master Name: "></asp:Label>
              <asp:DropDownList ID="ddlMasterCourse" runat="server" />
            <%--<asp:RequiredFieldValidator ID="rfvMasterName" runat="server" ControlToValidate="ddlMasterName"
                InitialValue="0" ErrorMessage="Please select a master name!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <br /><br />

            <asp:Label ID="lblCourse" runat="server" Text="Course Name: "></asp:Label>
            <asp:TextBox ID="txtCourseName" runat="server" Width="200px"></asp:TextBox>
            <br /><br />

            <asp:Label ID="lblPrice" runat="server" Text="Course Price: "></asp:Label>
            <asp:TextBox ID="txtCoursePrice" runat="server" Width="200px"></asp:TextBox>
            <br /><br />

            <asp:Label ID="lblImage" runat="server" Text="Upload Course Image: "></asp:Label>
            <asp:FileUpload ID="fileUploadImage" runat="server" />
            <br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add Course" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
