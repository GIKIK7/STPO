<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessagesForm.aspx.cs" Inherits="stpoProject.MessagesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style ="width:100%">
                <tr>
                    <td style="width:15%"></td>
                    <td style="width:70%">&nbsp;</td>
                    <td style="width:15%"</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" style="width:100%" Height="500px" ScrollBars="Horizontal">
                        </asp:Panel>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TxtBox_content" runat="server" style="width:80%"></asp:TextBox>
                        <asp:Button ID="Btn_Send" runat="server" Text="Wyślij" style="width:9%" OnClick="Btn_Send_Click" />
                    </td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
