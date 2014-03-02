﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CreateUserLogin.aspx.cs" Inherits="LotBankingCrux_v_1.CreateUserLogin" %>

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
    <br />
    <asp:Button ID="butInsertLogin" runat="server" OnClick="butInsertLogin_Click" Text="SUBMIT" />
    <br />
</asp:Content>
