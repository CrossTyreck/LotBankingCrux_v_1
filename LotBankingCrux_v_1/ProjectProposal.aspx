<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectProposal.aspx.cs" Inherits="LotBankingCrux_v_1.projectproposal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/projprop.css" />


    <script>
        $(document).ready(function () {
            $('.bool-slider .inset .control').click(function () {
                if (!$(this).parent().parent().hasClass('disabled')) {
                    if ($(this).parent().parent().hasClass('false')) {
                        $(this).parent().parent().addClass('true').removeClass('false');
                    } else {
                        $(this).parent().parent().addClass('false').removeClass('true');
                    }
                }
            });
        });
    </script>


    <title>Project Proposal</title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <asp:LinkButton ID="WelcomePage" runat="server" Style="text-decoration: none" OnClick="Welcome_OnClick" ForeColor="White">Crescent Bay Holdings</asp:LinkButton>

            <h2 class="create-a-project">Create a Project</h2>
            <ul>
                <li class="name">
                    <h4>Name
                        <asp:TextBox class="user-info" ID="tbProjectName" runat="server"></asp:TextBox>
                    </h4>
                </li>
                <li class="location">
                    <h4 id="long">First Street<asp:TextBox class="user-info" ID="FirstStreet" runat="server"></asp:TextBox>
                    </h4>
                    <h4 id="lat">&nbsp; Second Street<asp:TextBox class="user-info" ID="SecondStreet" runat="server"></asp:TextBox>
                    </h4>
                    Cardinal<asp:TextBox class="user-info" ID="Cardinal" runat="server"></asp:TextBox>
                </li>
                <li class="num-lots">
                    <h4>Number of Lots<asp:DropDownList class="user-info" ID="DropDownList1" runat="server">
                        <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                    </h4>
                </li>
                <li class="acq-price">
                    <h4>Acquisition Price <span class="currency">$</span><asp:TextBox class="user-info" ID="TextBox4" runat="server"></asp:TextBox>
                    </h4>
                </li>
                <li class="imp-costs">
                    <h4>Improvement Costs <span class="currency">$</span><asp:TextBox class="user-info" ID="TextBox5" runat="server"></asp:TextBox>
                    </h4>
                </li>
            </ul>
            <ul>
                <li class="add-opts">
                    <h4>Additional Options </h4>
                    <div class="bool-slider false">
                        <div class="inset">
                            <div class="control">
                            </div>
                        </div>
                    </div>
                </li>
                <asp:Label ID="DataInserted" runat="server" AssociatedControlID="DataInserted" ForeColor="Green" Visible="False">Data Inserted</asp:Label>

                <li class="cancelcreate-parent">

                    <asp:Button class="create" ID="Button1" runat="server" Text="Create Project" OnClick="Button1_Click" />
                    <asp:Button class="cancel" ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />

                    <!--
                        <div class="create">
                            <h4>Create Project</h4>
                        </div>
                        <div class="cancel">
                            <h4>Cancel</h4>
                        </div>
                            -->
                </li>
        </div>
    </form>
</body>
</html>
