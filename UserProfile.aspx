<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="E_Learning.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    User Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" AutoGenerateColumns="false" OnItemCommand="DataList1_ItemCommand">
                        <ItemTemplate>
                            <div class="card flex-fill">
                                <div class="card-header">
                                    <h2 class="card-titles">Course</h2>
                                </div>
                                <div class="card-body">
                                    <div class="form-group">
                                        <h5 class="card-title"><%# Eval("MasterCourseName") %></h5>
                                        <p class="card-text"><%# Eval("CourseTopicName") %></p>
                                        <p class="card-text"><%# Eval("CourseTopicPrice") %></p>
                                    </div>

                                    <div class="form-btn">
                                        <asp:Button ID="Addbtn" class="btn btn-primary" runat="server" CommandName="Add" CommandArgument='<%#Eval("MasterCourseId") %>' Text="Add" />
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:DataList>
      
</asp:Content>
