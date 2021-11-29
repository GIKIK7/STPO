<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutEditForm.aspx.cs" Inherits="stpoProject.WorkoutEditForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" SelectCommand="SELECT * FROM [exercise]"></asp:SqlDataSource>

        <table style="width: 100%">

            <tr>
                <td style="width: 15%">
                    <asp:Button ID="Btn_back" runat="server" OnClick="Btn_back_Click" Text="Wróć" />
                </td>
                <td style="width: 70%" align="center">
                    <asp:Label ID="Lbl_editWorkout" runat="server" Text="Edytuj trening na:" Font-Size="XX-Large"></asp:Label>
                </td>
                <td style="width: 15%">&nbsp;</td>
            </tr>

            <tr>
                <td></td>
                <td>
                </td>
                <td>
                    <asp:Button ID="Btn_addField" runat="server" OnClick="Btn_addField_Click" Text="Dodaj Ćwiczenie" />
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
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
                <td>
                    <asp:Button ID="Btn_edit" runat="server" OnClick="Btn_edit_Click" Text="Edytuj" />
                    <asp:Button ID="Btn_commit" runat="server" OnClick="Btn_commit_Click" Text="Zatwierdź" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>

        </table>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
