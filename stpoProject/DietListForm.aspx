<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DietListForm.aspx.cs" Inherits="stpoProject.DietListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%">

            <tr>
                <td style="width:15%">
                    <asp:Button ID="Btn_goBackToYourProfile" runat="server" OnClick="Btn_goBackToYourProfile_Click" Text="Wróc do swojego profilu" />
                </td>
                <td align="center" style="width:70%">
                    <asp:Label ID="Lbl_DIet" runat="server" Text="Dieta" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                </td>
                <td style="width:15%"></td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Panel ID="Panel_diet" runat="server">
                    </asp:Panel>
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>

        </table>
    </form>
</body>
</html>
