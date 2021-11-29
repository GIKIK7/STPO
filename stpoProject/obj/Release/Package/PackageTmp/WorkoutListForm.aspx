<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutListForm.aspx.cs" Inherits="stpoProject.WorkoutListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Btn_goBackToYourProfile" runat="server" OnClick="Btn_goBackToYourProfile_Click" Text="Wróc do swojego profilu" />
        <table style="width:100%">

            <tr>
                <td style="width:15%">
                </td>
                <td align="center" style ="width:70% ">
                    <asp:Label ID="Lbl_Workout" runat="server" Text="Treningi" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                </td>
                <td style="width:15%">
                    <asp:Button ID="Btn_createWorkout" runat="server" Text="Stwórz trening" OnClick="Btn_createWorkout_Click" />
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
                <td></td>
                <td></td>
                <td></td>
            </tr>

        </table>
    </form>
</body>
</html>
