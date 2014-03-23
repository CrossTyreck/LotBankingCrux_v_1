<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="ProjectProposal.aspx.cs" Inherits="LotBankingCrux_v_1.ProjectProposal" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table id="PP-table">
        <tr>
            <td>
                <asp:Panel ID="pnlProjectInfo" runat="server" Width="324px" CssClass="panel-style">
                    <div>
                        <asp:Label ID="lblProjectName" runat="server" Text="Project Name: "></asp:Label>
                        <asp:TextBox ID="txtProjectName" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblFirstStreet" runat="server" Text="First Street:"></asp:Label>
                    <asp:TextBox ID="txtFirstStreet" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblSecondStreet" runat="server" Text="Second Street:"></asp:Label>
                    <asp:TextBox ID="txtSecondStreet" CssClass="PP-textbox"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
                    <asp:TextBox ID="txtCity" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
                    <asp:TextBox ID="txtState" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblCardinal" runat="server" Text="Cardinal: "></asp:Label>
                    <asp:TextBox ID="txtCardinal" CssClass="PP-textbox"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblNumberOfLots" runat="server" Text="Number Of Lots: "></asp:Label>
                    <asp:TextBox ID="txtNumberOfLots" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblAcquisitionPrice" runat="server" Text="Acquisition Price: "></asp:Label>
                    <asp:TextBox ID="txtAcquisitionPrice" CssClass="PP-textbox"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblImprovementCost" runat="server" Text="Improvement Cost: "></asp:Label>
                    <asp:TextBox ID="txtImprovementCosts" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblDataInserted" runat="server" ForeColor="Green" Text="Data Inserted" Visible="False" ClientIDMode="Static"></asp:Label>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="button" />
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="mapPanel" runat="server"  Width="600px">
                    <asp:Image ID="mapImage" ImageUrl="http://maps.googleapis.com/maps/api/staticmap?center=Phoenix,AZ&zoom=13&size=600x600&maptype=roadmap&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&sensor=false"
                        runat="server" Width="605px" Style="margin-top: 4px" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click" Text="Accept" CssClass="button" />
                    <asp:Button ID="btnDecline" runat="server" CssClass="button" OnClick="btnDecline_Click" Text="Decline" />
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="pnlMap" runat="server">
                    <asp:Button ID="btnCheckLocation" CssClass="button" runat="server" Text="Check Location" OnClick="btnCheckLocation_Click" />
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
