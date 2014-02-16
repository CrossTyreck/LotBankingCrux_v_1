<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Builder.aspx.cs" Inherits="LotBankingCrux_v_1.Builder" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <ul id="horizontal-list">
        <li>
            <asp:LinkButton ID="BuilderProposal" runat="server" Style="text-decoration: none" OnClick="BuilderProposal_OnClick" ForeColor="Black">New Proposal</asp:LinkButton>
        </li>
        <asp:DropDownList ID="CurrentProjects" runat="server">
        </asp:DropDownList>
        <asp:LinkButton ID="ProjectDashboard" runat="server" Style="text-decoration: none" OnClick="ProjectDashboard_OnClick" ForeColor="Black"></asp:LinkButton>
    </ul>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        @font-face {
            font-family: Eyeglass;
            src: url('/Content/Fonts/eyeglass-normal.ttf'),;
        }

        html {
            margin: 0;
            padding: 0;
        }

        body {
            font-family: Eyeglass, sans-serif;
            margin: 0;
            padding: 0;
            min-height: 100%;
        }

        hr {
            width: 90%;
        }

        #buildername {
            padding-top: 10px;
            margin-bottom: 0px;
        }

        .panel-parent {
            display: block;
            border: thin outset #C0C0C0;
            background-color: #D8D8D8;
            margin: 0 auto;
            height: 830px;
            width: 82%;
        }

        .panel-background {
            background-image: url('/Images/texture.png');
            background-repeat: repeat;
            height: 100%;
            width: 100%;
        }

        .panel-style {
            background-color: #F0F0F0;
            display: block;
            margin: 0 auto;
            margin-top: 5px;
            margin-bottom: 5px;
            height: 75%;
            width: 80%;
        }

        .auto-style1 {
            text-align: center;
        }

        .auto-style2 {
            width: 32px;
            height: 32px;
        }

        #Text1 {
            height: 20px;
            width: 550px;
            display: block;
            margin: 0 auto;
        }

        .textSize {
            height: 20px;
            width: 550px;
        }

        #calendar {
            margin: 0 auto;
            display: inline-block;
        }

        .center {
            margin: 0 auto;
        }
    </style>




    <h1 id="buildername">
        <asp:Image runat="server" alt="Builder Logo" class="auto-style2" src="" ID="imgBuilderLogo" />
        FULTON HOMES </h1>
    <hr />





</asp:Content>


