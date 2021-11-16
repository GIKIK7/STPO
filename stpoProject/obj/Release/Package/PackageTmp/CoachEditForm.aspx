<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachEditForm.aspx.cs" Inherits="stpoProject.CoachEditForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td style="width: 20%"></td>
                    <td style="width: 65%" align ="center">
                        <asp:Label ID="Lbl_Coach" runat="server" Text="Edycja Trenera " Font-Bold="True" Font-Italic="False" Font-Size="XX-Large"></asp:Label>
                    </td>
                    <td style="width: 15%"></td>
                </tr>
                <tr>
                    <td style="width: 15%"align="right">
                        <a>Imie: </a>
                    </td>
                    <td style="width: 70%">
                        <asp:TextBox ID="TxtBox_Name" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td style="width: 15%"></td>
                </tr>
                <tr>
                    <td style="width: 15%" align="right">
                        <a>Nazwisko: </a>
                    </td>
                    <td style="width: 70%">
                        <asp:TextBox ID="TxtBox_lastName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td style="width: 15%"></td>
                </tr>

                <tr>
                    <td style="width: 15%" align="right">
                        <asp:Label ID="Lbl_helper" runat="server" Font-Overline="False" ForeColor="#CC3300"></asp:Label>
                    </td>
                    <td style="width: 70%" align="right" spacing="10">

                        <a href="CoachDetailsForm.aspx">Powrót</a>

                        <!-- spaces -->
                        <a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a> 

                        <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="Edytuj" />

                    </td>
                    <td style="width: 15%"></td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
