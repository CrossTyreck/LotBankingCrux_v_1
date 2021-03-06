﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="ProjectProposal.aspx.cs" Inherits="LotBankingCrux_v_1.ProjectProposal" %>

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
                    <asp:Label ID="lblFirstStreet" runat="server" Text="First Street:"></asp:Label>
                    <asp:DropDownList ID="txtFirstStreetSuffix"  CssClass="DropDown_Style" runat="server">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Rd." Value="1"></asp:ListItem>
                        <asp:ListItem Text="Blvd." Value="2"></asp:ListItem>
                        <asp:ListItem Text="Hwy." Value="3"></asp:ListItem>
                        <asp:ListItem Text="Ave." Value="4"></asp:ListItem>
                        <asp:ListItem Text="St." Value="5"></asp:ListItem>
                        <asp:ListItem Text="Dr." Value="6"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtFirstStreet" CssClass="PP-textbox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblSecondStreet" runat="server" Text="Second Street:"></asp:Label>
                    <asp:DropDownList ID="txtSecondStreetSuffix" CssClass="DropDown_Style" runat="server">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Rd." Value="1"></asp:ListItem>
                        <asp:ListItem Text="Blvd." Value="2"></asp:ListItem>
                        <asp:ListItem Text="Hwy." Value="3"></asp:ListItem>
                        <asp:ListItem Text="Ave." Value="4"></asp:ListItem>
                        <asp:ListItem Text="St." Value="5"></asp:ListItem>
                        <asp:ListItem Text="Dr." Value="6"></asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:TextBox ID="txtNumberOfLots" CssClass="PP-textbox" runat="server" placeholder="Enter Numeric Value"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblAcquisitionPrice" runat="server" Text="Acquisition Price: "></asp:Label>
                    <asp:TextBox ID="txtAcquisitionPrice" CssClass="PP-textbox"  runat="server" placeholder="Enter Numeric Value"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblImprovementCost" runat="server" Text="Improvement Cost: "></asp:Label>
                    <asp:TextBox ID="txtImprovementCosts" CssClass="PP-textbox" runat="server" placeholder="Enter Numeric Value"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblDataInserted" runat="server" ForeColor="Green" Text="Data Inserted" Visible="False" ClientIDMode="Static"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnCheckLocation" runat="server" CssClass="button" OnClick="btnCheckLocation_Click" Text="Check Location" />
                    <br />
                    <br />
                    <asp:Label ID="lblAddInfoReq" runat="server" ForeColor="Red" Text="Crescent Bay Holdings requires additional financial information be submitted before your proposal can be accepted. Please contact a Crescent Bay Holdings associate for more info." Visible="False"></asp:Label>
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
                    <asp:Label ID="lblRollPrice" runat="server" Text="Roll Price" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtbxRollPrice" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click" Text="Accept" CssClass="button" />
                    <asp:Button ID="btnDecline" runat="server" CssClass="button" OnClick="btnDecline_Click" Text="Decline" />
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="pnlMap" runat="server" CssClass="pnlMap">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click" Text="Submit" Width="99px" />
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
