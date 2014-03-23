<%@ Page Title="Due Diligence Copy" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="DueDiligenceCopy.aspx.cs" Inherits="LotBankingCrux_v_1.DueDiligenceCopy" %>

<%@ Register Assembly="LotBankingCrux_v_1" Namespace="LotBankingCrux_v_1.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div id="topnav">
        <div>
            <ul id="menu-list">
                <li>
                    <asp:LinkButton ID="lnkbtnTransactionDocumentation" runat="server" AccessKey=" " OnClick="lnkbtnTransactionDocumentation_Click">TRANSACTION DOCUMENTATION</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="lnkbtnMarketDueDiligence" runat="server" AccessKey=" " OnClick="lnkbtnMarketDueDiligence_Click">MARKET DUE DILIGENCE</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="lnkbtnBuilderResume" runat="server" AccessKey=" " OnClick="lnkbtnBuilderResume_Click">BUILDER RESUME</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <div class="multiviewpanel">
        <asp:MultiView ID="mviwDueDiligence" runat="server">
            <asp:View ID="viwBuilderResume" runat="server">
               
            </asp:View>
            <asp:View ID="viwMarketDueDiligenceMaterials" runat="server">
                

            </asp:View>
            <asp:View ID="viwTransactionDocumentation" runat="server">
               
            </asp:View>
        </asp:MultiView>

    </div>

</asp:Content>



