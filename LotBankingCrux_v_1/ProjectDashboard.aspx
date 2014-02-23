<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="ProjectDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.ProjectDashboard" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <ul id="horizontal-list">
        <li>
            <asp:LinkButton ID="LotTakeDown" runat="server" Style="text-decoration: none" OnClick="LotTakeDown_OnClick" ForeColor="Black">Lot Take Down Schedule</asp:LinkButton>
           
            <asp:DropDownList ID="ddlDocuments" OnSelectedIndexChanged="DDLDocuments_SelectedIndexChanged" AutoPostBack="true" runat="server">
                </asp:DropDownList>
        </li>

    </ul>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    This is where builder content goes
</asp:Content>

