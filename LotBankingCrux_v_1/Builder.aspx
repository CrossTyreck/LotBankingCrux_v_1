<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="Builder.aspx.cs" Inherits="LotBankingCrux_v_1.Builder" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
        <div class="table">
            <ul id="horizontal-list">
                <li>
                    <asp:LinkButton ID="BuilderProposal" runat="server" OnClick="BuilderProposal_OnClick" ForeColor="Black">New Proposal</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h1 id="buildername">
        <asp:Image runat="server" alt="Builder Logo" class="auto-style2" src="" ID="imgBuilderLogo" />
        FULTON HOMES </h1>
    <asp:Panel ID="pnlRequirements" runat="server">
    </asp:Panel>
    <h1>
        <asp:LinkButton ID="lnkbtnProposals" runat="server" OnClick="lnkbtnProposals_Click">Proposals</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnProjects" runat="server" OnClick="lnkbtnProjects_Click">Projects</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnBuilderDocuments" runat="server" OnClick="lnkbtnBuilderDocuments_Click">Builder Documents</asp:LinkButton>

     <asp:MultiView ID="DashboardView" runat="server" ActiveViewIndex="0" OnActiveViewChanged="DashboardView_ActiveViewChanged">
            <asp:View ID= "viwProposals" runat= "server"> 

                <asp:Panel ID="ProjectProposalsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
            </asp:View>
            <asp:View ID= "viwProjects" runat= "server"> 
                <asp:Panel ID="ExistingProjectsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px">
                    
                </asp:Panel>
            </asp:View>
            <asp:View ID= "viwBuilderDocuments" runat= "server"> 
                <asp:Panel ID="BuilderDocumentsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
            </asp:View>
       </asp:MultiView>




    </h1>






</asp:Content>


