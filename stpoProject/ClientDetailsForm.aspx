<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDetailsForm.aspx.cs" Inherits="stpoProject.ClientDetailsForm" %>

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
                        <asp:Label ID="Lbl_Client" runat="server" Text="Klient" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large"></asp:Label>
                    </td>
                    <td style="width: 15%">
                        
                        <asp:Button ID="btn_goToEditClientProfile" runat="server" OnClick="btn_goToEditClientProfile_Click" Text="Edytuj Profil" />
                        
                        <asp:Button ID="Btn_Chat" runat="server" OnClick="Btn_Chat_Click" Text="Chat" />
                        
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
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>

                <tr>
                    <td style="width: 15%" align="right"></td>
                    <td style="width: 70%"></td>
                    <td style="width: 15%">
                        <asp:Button ID="Btn_wyloguj" runat="server" OnClick="Btn_wyloguj_Click" Text="Wyloguj sie" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td> <a href="CoachSearchForm.aspx">nie masz jeszcze przypisanego trenera? znajdz odpowiedniego </a></td>
                    <td></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
