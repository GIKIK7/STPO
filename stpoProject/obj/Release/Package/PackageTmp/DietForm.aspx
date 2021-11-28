<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DietForm.aspx.cs" Inherits="stpoProject.DietForm" %>

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
                    <asp:Button ID="Btn_goBack" runat="server" OnClick="Btn_goBack_Click" Text="Wróc do swojgo profilu" />
                </td>
                <td align="center" style="width:70%">
                    <asp:Label ID="Lbl_diet" runat="server" Font-Size="XX-Large" Text="Dieta na: "></asp:Label>
                </td>
                <td style="width:15%">
                    <asp:Button ID="Btn_goEditDiet" runat="server" OnClick="Btn_goEditDiet_Click" Text="Edytuj diete" />
                </td>
            </tr>

             <tr>
                <td align="right">
                    <asp:Label ID="Lbl_sniadanie" runat="server" Text="Śniadanie: "></asp:Label>
                 </td>
                <td>
                    <asp:Label ID="Lbl_breakfastMealName" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Lbl_amountBreakfast" runat="server" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>

             <tr>
                <td align="right"> 
                    <asp:Label ID="Lbl_dinner" runat="server" Text="Obiad: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Lbl_dinnerName" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Lbl_amountDinner" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>

             <tr>
                <td align="right">
                    <asp:Label ID="Lbl_supper" runat="server" Text="Kolacja: "></asp:Label>   
                </td>
                <td>
                    <asp:Label ID="Lbl_supperMealName" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Lbl_amountSupper" runat="server" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
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
