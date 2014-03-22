<%@ Page Title="Project Dashboard" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CBHDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.CBHDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script src="Scripts/gaugeSVG.js"></script>
    <div id="topnav">
        <div>
            <ul id="menu-list">
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="AddUser_OnClick" ForeColor="Black">Add User</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>

</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Panel ID="pnlPage" CssClass="pnlPage" runat="server">

            <asp:LinkButton ID="lnkbtnProposals" runat="server" OnClick="lnkbtnProposals_Click">Proposals</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnProjects" runat="server" OnClick="lnkbtnProjects_Click">Projects</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnBuilderDocuments" runat="server" OnClick="lnkbtnBuilderDocuments_Click">Builder Documents</asp:LinkButton>
            <br />

            <br />

            <asp:Label ID="lblOrderBy" runat="server" Text="Order By: "></asp:Label>
            <asp:DropDownList ID="ddlOrderBy" runat="server">
            </asp:DropDownList>


            <asp:MultiView ID="DashboardView" runat="server" ActiveViewIndex="0" OnActiveViewChanged="DashboardView_ActiveViewChanged">
                <asp:View ID="ProjectProposalsView" runat="server">
                    <asp:Label ID="lblProjectProposals" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Proposals"></asp:Label>
                    <asp:Panel ID="ProjectProposalsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
                </asp:View>
                <asp:View ID="ExistingProjectsView" runat="server">
                    <asp:Label ID="lblCurrentProjects" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Projects"></asp:Label>
                    <asp:Panel ID="ProjectsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px">
                    </asp:Panel>
                </asp:View>
                <asp:View ID="BuilderDocumentsView" runat="server">
                    <asp:Label ID="lblBuiderDocuments" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Builder Documents"></asp:Label>
                    <asp:Panel ID="BuilderDocumentsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
    </div>
    <div class="dashboard-container">
        <asp:Panel ID="pnlMeters" CssClass="meters" runat="server">
            <table id="centermeters">


                <tr>
                    <td>
                        <div id="meter1" class="centermeters"></div>
                        <asp:Label runat="server" ID="lblMeter1" Text="METER3" />
                        <script>
                            new function () {
                                <% Response.Write(meter1.GenerateMeterScriptValues("meter1", "meter11")); %>
                            };

                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="meter2" class="centermeters"></div>
                        <asp:Label runat="server" ID="lblMeter2" Text="METER2" />
                        <script>
                            new function () {

              <% Response.Write(meter2.GenerateMeterScriptValues("meter2", "meter22")); %>
                            };

                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="meter3" class="centermeters"></div>
                        <asp:Label runat="server" ID="lblMeter3" Text="METER3" />
                        <script>
                            new function () {

              <% Response.Write(meter3.GenerateMeterScriptValues("meter3", "meter33")); %>

                            };
                        </script>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="pnlGraphs" CssClass="graphs" runat="server">
            <div id="temppanel1">

                <div class="menubar">
                    <div>
                        <ul id="horizontal-list">
                    </div>



                    <div id="temppanel2">
                    </div>
        </asp:Panel>
    </div>
</asp:Content>

