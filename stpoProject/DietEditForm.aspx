<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DietEditForm.aspx.cs" Inherits="stpoProject.DietEditForm" %>

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
                    <a href="DietForm.aspx"> Wróc </a>
                </td>
                <td style="width:70%" align="center">
                    <asp:Label ID="Lbl_diet" runat="server" Font-Size="XX-Large" Text="Edytuj diete na: "></asp:Label>
                </td>
                <td style="width:15%">
                </td>
            </tr>

             <tr>
                <td align="right">
                    <asp:Label ID="Lbl_sniadanie" runat="server" Text="Śniadanie: "></asp:Label>
                 </td>
                <td>
                    <asp:DropDownList ID="DropList_breakfast" runat="server" DataSourceID="SqlDataSource1" DataTextField="mealName" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" SelectCommand="SELECT * FROM [meals]"></asp:SqlDataSource>
                    <asp:TextBox ID="TxtBox_breakfast" runat="server" Width="60px"></asp:TextBox> g
                </td>
                <td></td>
            </tr>

             <tr>
                <td align="right"> 
                    <asp:Label ID="Lbl_dinner" runat="server" Text="Obiad: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropList_dinner" runat="server" DataSourceID="SqlDataSource1" DataTextField="mealName" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtBox_dinner" runat="server" Width="60px"></asp:TextBox> g
                </td>
                <td></td>
            </tr>

             <tr>
                <td align="right">
                    <asp:Label ID="Lbl_supper" runat="server" Text="Kolacja: "></asp:Label>   
                </td>
                <td>
                    <asp:DropDownList ID="DropList_supper" runat="server" DataSourceID="SqlDataSource1" DataTextField="mealName" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtBox_supper" runat="server" Width="60px"></asp:TextBox> g
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Btb_addDiet" runat="server" OnClick="Btb_addDiet_Click" Text="Edytuj" />
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
