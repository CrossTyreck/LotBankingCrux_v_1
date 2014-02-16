<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LotBankingCrux_v_1.Account.Login" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
      
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="loginForm">
        <h2>Use a local account to log in.</h2>
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" ID="LoginForm">
            <LayoutTemplate>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="Log in" OnClick="Login_Click" />
                    <asp:Label ID="LoginErrorLabel" runat="server" AssociatedControlID="LoginErrorLabel" ForeColor="Red" Visible="False">Please verify your credintials and try to login again</asp:Label>
                    <br />
                </fieldset>
            </LayoutTemplate>

        </asp:Login>


    </section>

</asp:Content>
