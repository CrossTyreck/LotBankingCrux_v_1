<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="LotBankingCrux_v_1.Account.Login" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="belowTopnav">
        <asp:Panel class="pageDown" runat="server" DefaultButton="LoginForm$LoginButton">
            <div id="login">
                <img alt="logo" src="Images/logo.png" />
                <asp:Login ID="LoginForm" runat="server" OnAuthenticate="Login_Click">
                </asp:Login>
            </div>
            <div style="clear: both;"></div>
        </asp:Panel>
    </div>
</asp:Content>
