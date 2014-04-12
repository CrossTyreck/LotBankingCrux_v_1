<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="ProjectDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.ProjectDashboard" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div id="topnav">
        <div id="duedil-nav">
            <ul id="menu-list">
                <li>
                    <asp:LinkButton ID="LotTakeDown" runat="server" Style="text-decoration: none" OnClick="LotTakeDown_OnClick">LOT TAKE DOWN SCHEDULE</asp:LinkButton>
                </li>
                <li>| </li>
                <li>
                    <asp:LinkButton ID="DueDiligence" runat="server" Style="text-decoration: none" OnClick="DueDiligence_OnClick">DUE DILIGENCE</asp:LinkButton>
                </li>

            </ul>
        </div>
    </div>

    <asp:Panel ID="pnlProjectDocumentsTest" runat="server" Height="189px">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblAccessLiquidity" runat="server" Text="Access to Liquidity"></asp:Label>
                <br />
                <asp:TextBox ID="txtbxAccessToLiquidity" runat="server" Height="123px" Width="375px" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSaveChng_Click" Text="Save" />
                <asp:Label ID="lblAcctoLiquConf" runat="server" Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    &nbsp;
   
</asp:Content>

