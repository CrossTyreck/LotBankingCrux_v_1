<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="ProjectDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.ProjectDashboard" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <ul id="horizontal-list">
        <li>
            <asp:LinkButton ID="LotTakeDown" runat="server" Style="text-decoration: none" OnClick="LotTakeDown_OnClick" ForeColor="Black">Lot Take Down Schedule</asp:LinkButton>
           
            <asp:LinkButton ID="DueDiligence" runat="server" Style="text-decoration: none" OnClick="DueDiligence_OnClick" ForeColor="Black">Due Diligence</asp:LinkButton>
        </li>

    </ul>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="pnlProjectDocumentsTest" runat="server" Height="189px">
        <asp:Label ID="lblDocumentsinProject" runat="server" Text="Documents within this project"></asp:Label>
    </asp:Panel>
&nbsp;
</asp:Content>

