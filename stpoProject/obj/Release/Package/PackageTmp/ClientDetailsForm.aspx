<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDetailsForm.aspx.cs" Inherits="stpoProject.ClientDetailsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%">
                <tr>
                    <td style="width: 15%">
                        <asp:Button ID="Btn_goToYourProfile" runat="server" OnClick="Btn_goToYourProfile_Click" Text="Wróc do swojego profilu" />
                    </td>
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
                    <td class="auto-style1" align="right">
                         <a>Przypisany trener: </a>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Lbl_assignCoach" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style1"></td>
                </tr>

                <tr>
                    <td style="width: 15%" align="right"></td>
                    <td style="width: 70%">
                        <asp:Button ID="Btn_Diet" runat="server" OnClick="Btn_makeDiet_Click" Text="Dieta" />
                    </td>
                    <td style="width: 15%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td> 
                        <asp:Button ID="Btn_searchCoaches" runat="server" OnClick="Btn_searchCoaches_Click" Text="Przegądaj Trenerów" />
                    </td>
                    <td>
                        <asp:Button ID="Btn_wyloguj" runat="server" OnClick="Btn_wyloguj_Click" Text="Wyloguj sie" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
