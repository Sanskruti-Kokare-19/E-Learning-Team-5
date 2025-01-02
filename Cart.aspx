<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="E_Learning.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Cart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <head>
        <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    </head>

    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="307px" Width="1138px" OnRowDeleting="GridView1_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="PID">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Imag">
                <ItemTemplate>
                    <asp:Image ID="Image1" ImageUrl='<%#Eval("CourseTopicPic")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CourseName">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("CourseTopicName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MasterCourseName">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("MasterCourseName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MasterCourseId">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("MasterCourseId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CoursePrice">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("CourseTopicPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TranDate">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("TranDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Suser") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-danger" CommandName="Delete" Text="Remove" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView><br />
    <div>
        <asp:Label ID="Label9" runat="server" Text="Total Amount"></asp:Label>
    </div>
    <br />
    <div>
        <asp:Button ID="RemoveBtn" class="btn btn-lg btn-block btn-info" runat="server" Text="Continue Shopping" />
        <asp:Button ID="BuyBtn" class="btn btn-lg btn-block btn-success" runat="server" Text="BuyNow" OnClick="BuyBtn_Click" />
    </div>
    

</asp:Content>
