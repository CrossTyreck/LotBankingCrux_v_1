<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="LotBankingCrux_v_1.Account.Login" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
      
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="loginForm">
        <img alt="logo" src="Images/Logo.jpg" />
        <asp:Login ID="LoginForm" runat="server" OnAuthenticate="Login_Click">
        </asp:Login>


    </section>
</asp:Content>
