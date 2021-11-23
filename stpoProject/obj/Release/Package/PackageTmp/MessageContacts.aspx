<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageContacts.aspx.cs" Inherits="stpoProject.MessageContacts" %>

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
                    <td style="width:20%">
                        <asp:Button ID="Btn_back" runat="server" OnClick="Btn_back_Click" Text="Wróc" />
                    </td>
                    <td style="width:60%">
                        <asp:Label ID="LbL_contactsInfo" runat="server" Text="Przejdź do rozmowy z:"></asp:Label>
                        <asp:Panel ID="Panel_conversation" runat="server">
                        </asp:Panel>
                    </td>
                    <td style="width:20%"></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
