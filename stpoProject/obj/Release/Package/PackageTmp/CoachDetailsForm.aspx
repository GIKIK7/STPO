<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachDetailsForm.aspx.cs" Inherits="stpoProject.TrenerDetailsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%">
                <tr>
                    <td style="width: 15%"></td>
                    <td style="width: 70%" align ="center">
                        <asp:Label ID="Lbl_Coach" runat="server" Text="Trener" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large"></asp:Label>
                    </td>
                    <td style="width: 15%">
                        <a href="CoachEditForm.aspx">Edytuj Profil</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%"align="right">
                        <a>Imie: </a>
                    </td>
                    <td style="width: 70%">
                        <asp:Label ID="Lbl_Name" runat="server"></asp:Label>
                    </td>
                    <td style="width: 15%"></td>
                </tr>
                <tr>
                    <td style="width: 15%" align="right">
                        <a>Nazwisko: </a>
                    </td>
                    <td style="width: 70%">
                        <asp:Label ID="Lbl_lastName" runat="server"></asp:Label>
                    </td>
                    <td style="width: 15%"></td>
                </tr>
                <tr>
                    <td style="width: 15%" align="right"></td>
                    <td style="width: 70%"></td>
                    <td style="width: 15%">
                        <asp:Button ID="Btn_wyloguj" runat="server" OnClick="Btn_wyloguj_Click" Text="Wyloguj sie" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
