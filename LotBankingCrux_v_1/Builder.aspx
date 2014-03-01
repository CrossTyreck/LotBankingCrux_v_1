<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="Builder.aspx.cs" Inherits="LotBankingCrux_v_1.Builder" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
        <div class="table">
            <ul id="horizontal-list">
                <li>
                    <asp:LinkButton ID="BuilderProposal" runat="server" Style="text-decoration: none" OnClick="BuilderProposal_OnClick" ForeColor="Black">New Proposal</asp:LinkButton>
                </li>
                <%--<asp:LinkButton ID="ProjectDashboard" runat="server" Style="text-decoration: none" OnClick="ProjectDashboard_OnClick" ForeColor="Black"></asp:LinkButton>--%>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h1 id="buildername">
        <asp:Image runat="server" alt="Builder Logo" class="auto-style2" src="" ID="imgBuilderLogo" />
        FULTON HOMES </h1>
    <hr />





</asp:Content>


