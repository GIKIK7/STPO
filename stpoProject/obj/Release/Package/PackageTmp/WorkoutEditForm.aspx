<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutEditForm.aspx.cs" Inherits="stpoProject.WorkoutEditForm" %>

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
                    <a href="WorkoutForm.aspx">Wróc</a>
                </td>
                <td style="width:70%" align="center">
                    <asp:Label ID="Lbl_editWorkout" runat="server" Text="Edycja treningu na: " Font-Size="XX-Large"></asp:Label>
                </td>
                <td style="width:15%"></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="exerciseName" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" SelectCommand="SELECT * FROM [exercise]"></asp:SqlDataSource>
                    &ensp;<asp:TextBox ID="TxtBox_sets" runat="server" Width="50px"></asp:TextBox>
&nbsp;serii&nbsp;
                    <asp:TextBox ID="TxtBox_reps" runat="server" Width="50px"></asp:TextBox>
&nbsp;powtórzeń</td>
                <td>
                    <asp:Button ID="Btn_addField" runat="server" Text="Dodaj Ćwiczenie" OnClick="Btn_addField_Click" />
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
