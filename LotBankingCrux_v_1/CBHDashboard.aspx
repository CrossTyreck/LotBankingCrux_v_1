<%@ Page Title="Project Dashboard" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CBHDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.CBHDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script src="Scripts/gaugeSVG.js"></script>
    <div class="menubar">
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
    <asp:Panel ID="pnlMeters" CssClass="multiviewpanel" runat="server" Height="225px" Width="625px">
        <table>
            <tr>
                <td>
                    <div id="meter1" style="width: 200px; height: 200px"></div>
                    <asp:Label runat="server" ID="lblMeter1" Text="METER3" />
                    <script>
                        new function () {
               <% Response.Write(meter1.GenerateMeterScriptValues("meter1", "meter11")); %>
                        };
                    </script>
                </td>
                <td>
                    <div id="meter2" style="width: 200px; height: 200px"></div>
                    <asp:Label runat="server" ID="lblMeter2" Text="METER2" />
                    <script>
                        new function () {
              <% Response.Write(meter2.GenerateMeterScriptValues("meter2", "meter22")); %>
                        };
                    </script>
                </td>
                <td>
                    <div id="meter3" style="width: 200px; height: 200px"></div>
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
    <asp:Panel ID="pnlGraphs" CssClass="multiviewpanel" runat="server" Height="200px">
        <%-- Insert Graphs in here. --%>
    </asp:Panel>
    <div class="menubar">
        <div>
            <ul id="horizontal-list">

                <li>
                    <asp:LinkButton ID="ProjectProposals" runat="server" OnClick="Proposals_Click">Proposals</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="ExistingProjects" runat="server" OnClick="Projects_Click">Projects</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="BuilderDocuments" runat="server" OnClick="BuilderDocuments_Click">Builder Documents</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
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

