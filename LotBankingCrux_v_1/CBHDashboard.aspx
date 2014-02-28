<%@ Page Title="Project Dashboard" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CBHDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.CBHDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
        <div class="table">
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
                    <asp:LinkButton ID="AddUsers" runat="server" Style="text-decoration: none" OnClick="AddUser_OnClick" ForeColor="Black">Add User</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="ProjectProposals" runat="server" OnClick="ProjectProposals_Click">Project Proposals</asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton ID="ExistingProjects" runat="server" OnClick="ExistingProjects_Click">Existing Projects</asp:LinkButton>
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
    <!-- style setup for Maps API -->
    <style type="text/css">
      
        #map-canvas {
            /*height: 100%;*/
        }
        .text {
            text-align: left;
        }
    </style>
    <!-- Javascript for Maps API -->
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?sensor=false">
    </script>
    <script src="../Scripts/bargraph-v1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function initialize() {
            var mapOptions = {
                //we can populate this region from data pulled dynamically or have the user
                //input location for the database <--easiest
                center: new google.maps.LatLng(33.4995417, -111.9272479),
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map-canvas"),
                mapOptions);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>






     <asp:MultiView ID="DashboardView" runat="server" ActiveViewIndex="0" OnActiveViewChanged="DashboardView_ActiveViewChanged">
            <asp:View ID= "ProjectProposalsView" runat= "server"> 
                <p><asp:Label ID="lblProjectProposals" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" style="text-align: center" Text="Project Proposals"></asp:Label></p>

                <asp:Panel ID="ProjectProposalsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
            </asp:View>
            <asp:View ID= "ExistingProjectsView" runat= "server"> 
                <p>
                    <asp:Label ID="lblCurrentProjects" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" style="text-align: center" Text="Current Projects"></asp:Label>
                </p>
                <asp:Panel ID="ExistingProjectsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px">
                    
                <asp:DropDownList ID="ddlBuilders" OnSelectedIndexChanged="DDLBuilders_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
             
                <asp:DropDownList ID="ddlNewProjects" OnSelectedIndexChanged="DDLNewProjects_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                </asp:Panel>
            </asp:View>
            <asp:View ID= "BuilderDocumentsView" runat= "server"> 
                <p>
                    <asp:Label ID="lblBuiderDocuments" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" style="text-align: center" Text="Builder Documents"></asp:Label>
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

