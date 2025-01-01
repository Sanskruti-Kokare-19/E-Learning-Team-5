<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMasterCourse.aspx.cs" Inherits="ELearningProject.AddMasterCourse" %>

<!DOCTYPE html>
<head runat="server">
    <title>Add Master Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 50%; margin: 50px auto;">
            <h2>Add Master Course</h2>
            <asp:Label ID="lblMasterCourse" runat="server" Text="Master Course Name: "></asp:Label>
            <asp:DropDownList ID="ddlMasterCourse" runat="server" Width="200px">
                <asp:ListItem Value="">Select Master Course</asp:ListItem>
                <asp:ListItem Value="Full Stack Java">Full Stack Java</asp:ListItem>
                <asp:ListItem Value="Full Stack DotNet">Full Stack DotNet</asp:ListItem>
            </asp:DropDownList>
           <%-- <asp:RequiredFieldValidator ID="rfvMasterCourse" runat="server" ControlToValidate="ddlMasterCourse"
                InitialValue="0" ErrorMessage="Please select a course!" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <br /><br />

             <asp:Label ID="lblImage" runat="server" Text="Upload Course Image: "></asp:Label>
            <asp:FileUpload ID="fileUploadImage" runat="server" />
            <br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
