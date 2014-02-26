<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="LotBankingCrux_v_1.Account.Login" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
      
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="loginForm">
        <img alt="logo" src="Images/Logo.jpg" />
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" ID="LoginForm">
            <LayoutTemplate>

                <asp:Label runat="server" AssociatedControlID="UserName"> </asp:Label>
                <asp:TextBox runat="server" ID="UserName"  Class="logininput" placeholder="Username"/>
                <br />
                            
                <asp:Label runat="server" AssociatedControlID="Password"> </asp:Label>
                <asp:TextBox runat="server" ID="Password" Class="logininput" TextMode="Password" placeholder="Password"/>
                <br />
                            
                <asp:Button runat="server" Class="loginbutton" CommandName="Login" Text="Log in" OnClick="Login_Click" />
                <asp:Label ID="LoginErrorLabel" runat="server" AssociatedControlID="LoginErrorLabel" ForeColor="Red" Visible="False">Please verify your credintials and try to login again</asp:Label>
                <br />

                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label ID="Label1" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>

            </LayoutTemplate>

        </asp:Login>


    </section>
</asp:Content>
