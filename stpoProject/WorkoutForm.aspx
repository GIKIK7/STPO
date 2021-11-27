<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutForm.aspx.cs" Inherits="stpoProject.WorkoutForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Btn_goBack" runat="server" OnClick="Btn_goBack_Click" Text="Wróc do swojgo profilu" />
         <table style="width:100%">
            <tr>
                <td style="width:15%"></td>
                <td align="center" style="width:70%">
                    <asp:Label ID="Lbl_workout" runat="server" Font-Size="XX-Large" Text="Trening na: "></asp:Label>
                </td>
                <td style="width:15%">
                    <asp:Button ID="Btn_editWorkout" runat="server" OnClick="Btn_editWorkout_Click" Text="Edytuj" />
                </td>
            </tr>

             <tr>
                <td></td>
                <td>
                    <asp:Panel ID="Panel_workout" runat="server">
                    </asp:Panel>
                 </td>
                <td></td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
                </td>
                <td></td>
                <td></td>
            </tr>

        </table>
    </form>
</body>
</html>
