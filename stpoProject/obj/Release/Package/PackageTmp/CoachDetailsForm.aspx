<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachDetailsForm.aspx.cs" Inherits="stpoProject.TrenerDetailsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 15%;
            height: 30px;
        }
        .auto-style2 {
            width: 70%;
            height: 30px;
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
                        <asp:Label ID="Lbl_Coach" runat="server" Text="Trener" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large"></asp:Label>
                    </td>
                    <td style="width: 15%">
                        
                        <asp:Button ID="Btn_goToEditCoachProfile" runat="server" OnClick="Btn_goToEditCoachProfile_Click" Text="Edytuj profil" />
                        
                        <asp:Button ID="Btn_chat" runat="server" OnClick="Btn_chat_Click" Text="Chat" />
                        
                        <asp:Button ID="Btn_dealStart" runat="server" OnClick="Btn_dealStart_Click" Text="Rozpocznij współprace" />
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%"align="right">
                        <a>Imie: </a>
                    </td>
                    <td style="width: 70%">
                        <asp:Label ID="Lbl_Name" runat="server"></asp:Label>
                    </td>
                    <td style="width: 15%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 15%" align="right">
                        <a>Nazwisko: </a>
                    </td>
                    <td style="width: 70%">
                        <asp:Label ID="Lbl_lastName" runat="server"></asp:Label>
                    </td>
                    <td style="width: 15%">
                        
                    </td>
                </tr>

                <tr>
                    <td align="right"><a>Kategoria: </a></td>
                    <td>
                        <asp:Label ID="LbL_Category" runat="server"></asp:Label>

                    </td>
                    <td>
                       
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Lbl_dietPrice" runat="server" Text="Cena za diete:" Width="120px"></asp:Label>
                        <asp:Label ID="Lbl_actualDietPrice" runat="server" Text="brak" Width="50px"></asp:Label>
                        <asp:Label ID="Lbl_currency" runat="server" Text="zł"></asp:Label>
                        <asp:TextBox ID="TxtBox_dietPrice" runat="server" Width="50px"></asp:TextBox>
                        <asp:Button ID="Btn_updateDietPrice" runat="server" OnClick="Btn_updateDietPrice_Click" Text="Zatwierdź" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                         <asp:Label ID="Lbl_workoutPrice" runat="server" Text="Cena za trening: " Width="120px"></asp:Label>
                        <asp:Label ID="Lbl_actualWorkoutPrice" runat="server" Text="brak" Width="50px"></asp:Label>
                        <asp:Label ID="Lbl_currency2" runat="server" Text="zł"></asp:Label>
                        <asp:TextBox ID="TxtBox_workoutPrice" runat="server" Width="50px"></asp:TextBox>
                        <asp:Button ID="Btn_updateWorkoutPrice" runat="server" OnClick="Btn_updateWorkoutPrice_Click" Text="Zatwierdź" />
                    </td>
                    <td></td>
                </tr>
                 <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>


                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Btn_searchClients" runat="server" Text="Przeglądaj Klientów" OnClick="Btn_searchClients_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2"></td>
                    <td class="auto-style1">
                        <asp:Button ID="Btn_wyloguj" runat="server" OnClick="Btn_wyloguj_Click" Text="Wyloguj sie" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Lbl_rate" runat="server" Font-Bold="True" Text="Średnia ocena trenera to: "></asp:Label>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:DropDownList ID="DropList_ratings" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Btn_rateCoach" runat="server" OnClick="Btn_rateCoach_Click" Text="Oceń" />
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Panel ID="Panel_comments" runat="server">
                        </asp:Panel>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtBox_com" runat="server" width="100%" ></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td align="right">

                        <asp:Button ID="Btn_writeComm" runat="server" OnClick="Btn_writeComm_Click" Text="Napisz Komentarz" />

                    </td>
                    <td></td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
