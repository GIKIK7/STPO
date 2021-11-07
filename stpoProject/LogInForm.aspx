<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="stpoProject.LogInForm" %>

<!DOCTYPE html>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        .auto-style1 {  
            width: 100%;  
        }  
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            width: 281px;
        }
        .auto-style4 {
            height: 37px;
            width: 281px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            width: 281px;
            height: 31px;
        }
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <table class="auto-style1">  
            <tr>  
                <td colspan="6" style="text-align: center; vertical-align: top">  
                    <asp:Label ID="Lbl_LogIn" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Log In "></asp:Label>  
                </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td style="text-align: center" class="auto-style3">  
                    <asp:Label ID="LbL_User" runat="server" Font-Size="X-Large" Text="User:"></asp:Label>  
                </td>  
                <td style="text-align: center">  
                    <asp:TextBox ID="TxtBox_User" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td> 
                <td> </td>
            </tr>  
            <tr>  
                <td class="auto-style2"> </td>  
                <td style="text-align: center" class="auto-style4">  
                    <asp:Label ID="Lbl_Password" runat="server" Font-Size="X-Large" Text="Password :"></asp:Label>  
                </td>  
                <td style="text-align: center" class="auto-style2">  
                    <asp:TextBox ID="TxtBox_Password" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
                <td> </td>
            </tr>  
            <tr>  
                <td> </td>  
                <td class="auto-style3"> </td>  
                <td> </td>  
                <td> </td>
            </tr>  
            <tr>  
                <td> </td>  
                <td class="auto-style3"> </td>  
                <td style="text-align: center">  
                    <asp:Button ID="Btn_LogIn" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Btn_LogInClick" Text="Log In" />  
                </td>   
                <td> </td>
            </tr>  
            <tr>  
                <td class="auto-style5"> </td>  
                <td class="auto-style6"> 
                    <asp:Label ID="Lbl_NoAccunt" runat="server" Text="Nie masz jeszcze konta?"></asp:Label>
                </td>  
                <td class="auto-style5">
                    <a href ="SignInForm.aspx"> Zarejestruj sie!</a>
                </td>
                <td class="auto-style5">  
                </td>  
            </tr>  

            <tr> 
                <td></td>
                <td>
                    <asp:Label ID="LbL_Helper" runat="server" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>

        </table>  
      
    </div>  
    </form>  
</body>  
</html>  