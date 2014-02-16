<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUserLogin.aspx.cs" Inherits="LotBankingCrux_v_1.CreateUserLogin" %>

<asp:Content ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent" runat="server">
    Remember to fill in all the fields to add a user
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Login Name<asp:TextBox ID="tbUserName" runat="server" Width="119px"></asp:TextBox>
    <br />
    Password<asp:TextBox ID="tbPassword" runat="server" Width="119px"></asp:TextBox>
    <br />
    User Type<asp:TextBox ID="tbUserType" runat="server" Width="119px"></asp:TextBox>
&nbsp;1 = Admin, 2 = Builder, 3 = Investor<br />
    Option<asp:TextBox ID="tbOptionMask" runat="server" Width="119px"></asp:TextBox>
&nbsp;Use 0 for default<br />
    <asp:Button ID="butInsertLogin" runat="server" OnClick="butInsertLogin_Click" Text="SUBMIT" />
    <br />
    Builder Name<asp:TextBox ID="tbBuilderName" runat="server"></asp:TextBox>
    <br />
</asp:Content>
