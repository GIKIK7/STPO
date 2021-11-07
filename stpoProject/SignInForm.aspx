<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInForm.aspx.cs" Inherits="stpoProject.SignInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        .auto-style1 {  
            width: 100%;  
        }  
        .auto-style4 {
            width: 120px;
        }
        .auto-style5 {
            width: 1019px;
        }
        .auto-style6 {
            width: 120px;
            height: 26px;
        }
        .auto-style7 {
            width: 1019px;
            height: 26px;
        }
        .auto-style8 {
            width: 120px;
        }
        .auto-style9 {
            width: 120px;
            height: 26px;
        }
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <table class="auto-style1">  

            <tr>
                <td class="auto-style4"></td>
                <td align ="center" class="auto-style5">
                    <asp:Label ID="Lbl_SignIn" runat="server" Text="Zarejestruj się!"></asp:Label>
                </td>
                <td class="auto-style8"></td>
            </tr>
            
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Lbl_login" runat="server" Text="Login:"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TxtBox_login" runat="server" Width="407px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>  
            <tr>  
                <td class="auto-style6">
                    <asp:Label ID="Lbl_password" runat="server" Text="Haslo:"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TxtBox_password" runat="server" Width="404px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>  

            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Lbl_name" runat="server" Text="Imie:"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TxtBox_name" runat="server" Width="407px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>  
            <tr>  
                <td class="auto-style6">
                    <asp:Label ID="Lbl_lastName" runat="server" Text="Nazwisko:"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TxtBox_LastName" runat="server" Width="404px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>  
            <tr>  
                <td class="auto-style4">
                    <asp:Label ID="Lbl_Helper" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="Btn_SignIn" runat="server" Text="Zarejestruj sie" OnClick="Btn_SignIn_Click" />
                </td>
                <td class="auto-style8"></td>
            </tr>  
        </table>  
      
    </div>  
    </form>  
</body>  
</html> 