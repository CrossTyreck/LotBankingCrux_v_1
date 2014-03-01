<%@ Page Title="Project Dashboard" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CBHDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.CBHDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>






<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script src="Scripts/gaugeSVG.js"></script>

    <div class="menubar">
        <div>
            <ul id="horizontal-list">
                <%--     <asp:Chart ID="Chart1" runat="server" Width="339px">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>--%><%--  <li>Select Builder </li>--%><%--  <asp:DropDownList ID="ddlBuilders" runat="server">
                </asp:DropDownList>--%>
                <li>
                    <asp:LinkButton ID="AddUsers" runat="server" OnClick="AddUser_OnClick" ForeColor="Black">Add User</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="ProjectProposals" runat="server" OnClick="Proposals_Click">Proposals</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="ExistingProjects" runat="server" OnClick="Projects_Click">Projects</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="BuilderDocuments" runat="server" OnClick="BuilderDocuments_Click">Builder Documents</asp:LinkButton>
                </li>

                <!--These need to be moved to the Projects Window!-->

                <!------------------------------------------------->

            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="pnlMeters" CssClass="multiviewpanel" runat="server" Height="200px">

        <div id="meter1" style="width: 350px; height: 300px"></div>
        <script>
            window.onload = function () {
              <% Response.Write(meter1.GenerateMeterScriptValues("meter1", "meter11")); %>
            };
        </script>
     
    </asp:Panel>
    <asp:Panel ID="pnlGraphs" CssClass="multiviewpanel" runat="server" Height="200px">
    </asp:Panel>






    <br />






    <asp:Label ID="lblOrderBy" runat="server" Text="Order By: "></asp:Label>
    <asp:DropDownList ID="ddlOrderBy" runat="server">
    </asp:DropDownList>






    <asp:MultiView ID="DashboardView" runat="server" ActiveViewIndex="0" OnActiveViewChanged="DashboardView_ActiveViewChanged">
        <asp:View ID="ProjectProposalsView" runat="server">
            <p>
                <asp:Label ID="lblProjectProposals" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Proposals"></asp:Label>
            </p>

            <asp:Panel ID="ProjectProposalsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
        </asp:View>
        <asp:View ID="ExistingProjectsView" runat="server">
            <p>
                <asp:Label ID="lblCurrentProjects" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Projects"></asp:Label>
            </p>
            <asp:Panel ID="ProjectsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px">
            </asp:Panel>
        </asp:View>
        <asp:View ID="BuilderDocumentsView" runat="server">
            <p>
                <asp:Label ID="lblBuiderDocuments" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Builder Documents"></asp:Label>
            </p>
            <asp:Panel ID="BuilderDocumentsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
        </asp:View>
    </asp:MultiView>




    <!-- These guys need to be added to the sides of the page 
     <table class="tasklist">
        <tr>
            <th>TASK LIST</th>
        </tr>
        <tr>
            <td>row 1, cell 1</td>
        </tr>
        <tr>
            <td>row 1, cell 2</td>
        </tr>
    </table>

    <div class="title">
        Builders
    </div>
        -->
</asp:Content>

