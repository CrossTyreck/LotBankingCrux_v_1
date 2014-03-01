﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="Builder.aspx.cs" Inherits="LotBankingCrux_v_1.Builder" %>

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

     <asp:Image runat="server" alt="Builder Logo" class="leftalignElement" src="" ID="imgBuilderLogo" />
    <h1 id="buildername" class="centerElement">
       
        FULTON HOMES </h1>
    <p class="centerElement">
        <asp:Label ID="lblContactName" runat="server" Text="Contact Name:"></asp:Label>
        <asp:LinkButton ID="lnkbtnContactName" runat="server" OnClick="lnkbtnContactName_Click"></asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number:"></asp:Label>
        <asp:LinkButton ID="lnkbtnContactNumber" runat="server" OnClick="lnkbtnContactNumber_Click"></asp:LinkButton>
    </p>
     <p class="centerElement">
         <asp:TextBox ID="txtAddContactName" runat="server" Visible="False"></asp:TextBox>
         <asp:TextBox ID="txtAddContactNumber" runat="server" Visible="False"></asp:TextBox>
    </p>
     <p class="centerElement">
         <asp:Button ID="btnSubmitContact" runat="server" CssClass="button" OnClick="btnSubmitContact_Click" Text="Submit Contact Info" ValidateRequestMode="Enabled" Visible="False" />
    </p>
    <asp:Panel ID="pnlRequirements" runat="server">
    </asp:Panel>
    <h1>
        <asp:LinkButton ID="lnkbtnProposals" runat="server" OnClick="lnkbtnProposals_Click">Proposals</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnProjects" runat="server" OnClick="lnkbtnProjects_Click">Projects</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnBuilderDocuments" runat="server" OnClick="lnkbtnBuilderDocuments_Click">Builder Documents</asp:LinkButton>

        <asp:MultiView ID="DashboardView" runat="server" ActiveViewIndex="0" OnActiveViewChanged="DashboardView_ActiveViewChanged">
            <asp:View ID="viwProposals" runat="server">

                <asp:Panel ID="ProjectProposalsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
            </asp:View>
            <asp:View ID="viwProjects" runat="server">
                <asp:Panel ID="ExistingProjectsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px">
                </asp:Panel>
            </asp:View>
            <asp:View ID="viwBuilderDocuments" runat="server">
                <asp:Panel ID="BuilderDocumentsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
            </asp:View>
        </asp:MultiView>




    </h1>






</asp:Content>


