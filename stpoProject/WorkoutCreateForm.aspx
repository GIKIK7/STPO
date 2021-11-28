<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutCreateForm.aspx.cs" Inherits="stpoProject.WorkoutEditForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                    <asp:Label ID="Lbl_editWorkout" runat="server" Text="Stwórz trening" Font-Size="XX-Large"></asp:Label>
                </td>
                <td style="width: 15%">&nbsp;</td>
            </tr>

            <tr>
                <td></td>
                <td>

                    <asp:Calendar ID="workout_calendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>

                </td>
                <td></td>
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
