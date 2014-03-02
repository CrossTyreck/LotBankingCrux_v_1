<%@ Page Title="" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CreateUserLogin.aspx.cs" Inherits="LotBankingCrux_v_1.CreateUserLogin" %>

<asp:Content ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent" runat="server">
    Remember to fill in all the fields to add a user
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Login Name&nbsp;&nbsp; <asp:TextBox ID="tbUserName" runat="server" Width="119px"></asp:TextBox>
    <br />
    Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbPassword" runat="server" Width="119px"></asp:TextBox>
    <br />
    User Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DDLUserType" runat="server" OnSelectedIndexChanged="DLLUserType_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="Select a User Type" Value=""></asp:ListItem>
        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
        <asp:ListItem Text="Builder" Value="2"></asp:ListItem>
        <asp:ListItem Text="Investor" Value="3"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;<br />
    Option&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbOptionMask" runat="server" Width="119px"></asp:TextBox>
&nbsp;Use 0 for default<br />
    <asp:Label ID="lblBuilderName" runat="server" Text="Builder Name"></asp:Label>
    &nbsp;<asp:TextBox ID="tbBuilderName" runat="server"></asp:TextBox>
    <asp:Label ID="lblUserAdded" runat="server" ForeColor="Green" Text="User Added" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="butInsertLogin" runat="server" OnClick="butInsertLogin_Click" Text="SUBMIT" />
    <br />
    <asp:Panel ID="Panel2" runat="server" Height="311px">
        <asp:Label ID="lblEmailDestination" runat="server" Text="To:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmailDestination" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEmailOrigin" runat="server" Text="From: "></asp:Label>
        <asp:TextBox ID="txtEmailOrigin" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblEmailSubject" runat="server" Text="Label"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtEmailSubject" runat="server" Width="429px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtEmailContent" runat="server" Height="137px" Width="465px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
