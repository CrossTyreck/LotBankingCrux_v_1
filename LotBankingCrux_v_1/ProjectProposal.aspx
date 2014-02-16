<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectProposal.aspx.cs" Inherits="LotBankingCrux_v_1.ProjectProposal" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    Project Name:<asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
    <br />
    <br />
    First Street:
    <asp:TextBox ID="txtFirstStreet" runat="server"></asp:TextBox>
    <br />
    <br />
    Second Street:<asp:TextBox ID="txtSecondStreet" runat="server"></asp:TextBox>
    <br />
    <br />
    Cardinal:<asp:TextBox ID="txtCardinal" runat="server"></asp:TextBox>
    <br />
    <br />
    Number of Lots:
    <asp:TextBox ID="txtNumberOfLots" runat="server"></asp:TextBox>
    <br />
    <br />
    Acquisition Price:
    <asp:TextBox ID="txtAcquisitionPrice" runat="server"></asp:TextBox>
    <br />
    <br />
    Improvement Costs:
    <asp:TextBox ID="txtImprovementCosts" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="lblDataInserted" runat="server" ForeColor="Green" Text="Data Inserted" Visible="False"></asp:Label>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <br />
    <br />
    <br />
    <asp:Button ID="btnDashboard" runat="server" OnClick="btnDashboard_Click" Text="Dashboard" />

    </asp:Content>