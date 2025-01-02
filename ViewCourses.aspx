<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCourses.aspx.cs" Inherits="Elearning.ViewCourses" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Courses</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <!-- Manage MasterCourses Section -->
            <div class="row mb-4">
                <div class="col">
                    <h2 class="text-center">Manage MasterCourses</h2>
                    <asp:GridView 
                        ID="GridView1" 
                        runat="server" 
                        CssClass="table table-striped table-bordered" 
                        AutoGenerateColumns="False" 
                        OnRowCommand="GridView1_RowCommand"
                        HeaderStyle-CssClass="bg-primary text-white">
                        <Columns>
                            <asp:BoundField DataField="CourseId" HeaderText="ID" />
                            <asp:BoundField DataField="CourseName" HeaderText="MasterCourse Name" />
                            <asp:BoundField DataField="CourseImage" HeaderText="Image Path" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("CourseId") %>' CssClass="btn btn-primary btn-sm" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("CourseId") %>' CssClass="btn btn-danger btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- Manage Courses Section -->
            <div class="row mb-4">
                <div class="col">
                    <h2 class="text-center">Manage Courses</h2>
                    <asp:GridView 
                        ID="GridView2" 
                        runat="server" 
                        CssClass="table table-striped table-bordered" 
                        AutoGenerateColumns="False" 
                        OnRowCommand="GridView2_RowCommand"
                        HeaderStyle-CssClass="bg-primary text-white">
                        <Columns>
                            <asp:BoundField DataField="CourseId" HeaderText="ID" />
                            <asp:BoundField DataField="MasterCourseName" HeaderText="MasterCourse Name" />
                            <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                            <asp:BoundField DataField="CoursePrice" HeaderText="Course Price" />
                            <asp:BoundField DataField="CourseImage" HeaderText="Image Path" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("CourseId") %>' CssClass="btn btn-primary btn-sm" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("CourseId") %>' CssClass="btn btn-danger btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- Manage Topics Section -->
            <div class="row">
                <div class="col">
                    <h2 class="text-center">Manage Topics</h2>
                    <asp:GridView 
                        ID="GridView3" 
                        runat="server" 
                        CssClass="table table-striped table-bordered" 
                        AutoGenerateColumns="False"
                        OnRowCommand="GridView3_RowCommand"
                        HeaderStyle-CssClass="bg-primary text-white">
                        <Columns>
                            <asp:BoundField DataField="TopicId" HeaderText="ID" />
                            <asp:BoundField DataField="TopicName" HeaderText="Topic Name" />
                            <asp:BoundField DataField="YouTubeURL" HeaderText="YouTube URL" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditTopic" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("TopicId") %>' CssClass="btn btn-primary btn-sm" />
                                    <asp:Button ID="btnDeleteTopic" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("TopicId") %>' CssClass="btn btn-danger btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.3/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>