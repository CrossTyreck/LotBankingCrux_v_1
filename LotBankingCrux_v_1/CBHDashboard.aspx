<%@ Page Title="Project Dashboard" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="CBHDashboard.aspx.cs" Inherits="LotBankingCrux_v_1.CBHDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script src="Scripts/gaugeSVG.js"></script>
    <div id="topnav">
        <div>
            <ul class="menu-list">
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="AddUser_OnClick" ForeColor="Black">Add User</asp:LinkButton>
                </li>
                <li>
                    <asp:DropDownList ID="ddlBuilders" runat="server" OnSelectedIndexChanged="GoToBuilder">
                    </asp:DropDownList>
                    <asp:Label ID="Label1" runat="server" Text="Go to selected builder page"></asp:Label>
                </li>
                <li>
                    <asp:Button ID="GoToBuilderButton" runat="server" Text="Go!" OnClick="GoToBuilder" />
                </li>
            </ul>
        </div>
    </div>

</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Panel ID="pnlPage" CssClass="pnlPage" runat="server">

            <div id="duedil-nav">
                <ul class="menu-list">
                    <li>
                        <asp:LinkButton ID="lnkData" runat="server" OnClick="Data_Click">DATA</asp:LinkButton></li>
                    <li>| </li>
                    <li>
                        <asp:LinkButton ID="lnkbtnProposals" runat="server" OnClick="Proposals_Click">PROPOSALS</asp:LinkButton></li>
                    <li>| </li>
                    <li>
                        <asp:LinkButton ID="lnkbtnProjects" runat="server" OnClick="Projects_Click">PROJECTS</asp:LinkButton></li>
                    <li>| </li>
                    <li>
                        <asp:LinkButton ID="lnkbtnBuilderDocuments" runat="server" OnClick="BuilderDocuments_Click">BUILDER DOCUMENTS</asp:LinkButton></li>
                </ul>
            </div>


            <asp:MultiView ID="DashboardView" runat="server" ActiveViewIndex="3">
                <asp:View ID="ProjectProposalsView" runat="server">
                    <asp:Label ID="lblProjectProposals" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Proposals"></asp:Label>
                    <br />
                    <asp:CheckBox ID="chkDeclined" runat="server" Text="Declined" />
                    <asp:CheckBox ID="chkAwaitingBuilderInfo" runat="server" Text="Awaiting Builder Info" />
                    <asp:CheckBox ID="chkAwaitingApproval" runat="server" Text="Awaiting Approval" />
                    <br />
                    <asp:Label ID="lblBuilders" runat="server" Text="Choose Builder: "></asp:Label>
                    <br />
                    <asp:ListBox ID="lstbxBuilders" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    <asp:Label ID="lblOrderBy" runat="server" Text="Order By: "></asp:Label>
                    <asp:DropDownList ID="ddlOrderBy" runat="server" Width="79px">
                    </asp:DropDownList>
                    <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Go!" Width="56px" />
                    <asp:Panel ID="ProjectProposalsPanel" runat="server" CssClass="multiviewpanel projectPanel">
                    </asp:Panel>
                </asp:View>
                <asp:View ID="ExistingProjectsView" runat="server">
                    <asp:Label ID="lblCurrentProjects" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Projects"></asp:Label>
                    <asp:Label ID="lblOrderBy1" runat="server" Text="Order By: "></asp:Label>
                    <asp:DropDownList ID="ddlOrderBy1" runat="server" Width="79px">
                    </asp:DropDownList>
                    <asp:Panel ID="ProjectsPanel" runat="server" CssClass="multiviewpanel projectPanel">
                    </asp:Panel>
                </asp:View>
                <asp:View ID="BuilderDocumentsView" runat="server">
                    <asp:Label ID="lblBuiderDocuments" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Underline="True" Style="text-align: center" Text="Builder Documents"></asp:Label>
                    <asp:Label ID="lblOrderBy2" runat="server" Text="Order By: "></asp:Label>
                    <asp:DropDownList ID="ddlOrderBy2" runat="server" Width="79px">
                    </asp:DropDownList>
                    <asp:Panel ID="BuilderDocumentsPanel" runat="server" CssClass="multiviewpanel" Height="400px" Width="800px"></asp:Panel>
                </asp:View>

                <asp:View ID="DataView" runat="server">
                    <center>
    <div style="margin: 0 auto;">
        <div style="display: inline; margin: 0 auto;">
            <div id="meter1" class="centermeters"></div>
            <script>
                new function () {
                                <% Response.Write(meter1.GenerateMeterScriptValues("meter1", "meter11")); %>
                };
            </script>

            <div id="meter2" class="centermeters"></div>
            <script>
                new function () {

              <% Response.Write(meter2.GenerateMeterScriptValues("meter2", "meter22")); %>
                };

            </script>
        </div>
        <div>

            <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="WhiteSmoke" Height="500px" Width="500px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Builder Profitability" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                </Titles>
                <BorderSkin SkinStyle="Emboss"></BorderSkin>
                <Series>
                    <asp:Series Name="Default" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
                        <Area3DStyle Rotation="0" />
                        <AxisY LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
        </center>
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
    </div>
</asp:Content>

