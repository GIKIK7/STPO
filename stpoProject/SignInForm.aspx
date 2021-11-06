<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInForm.aspx.cs" Inherits="stpoProject.SignInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        .auto-style1 {  
            width: 100%;  
        }  
        .auto-style3 {
            height: 41px;
        }
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <table class="auto-style1">  
            <tr>
                <td class="auto-style3"> </td>  
                <td class="auto-style3"> </td>  
                <td style="text-align: center" class="auto-style3">  
                    <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Button1_Click" Text="Get Data"/>  
                </td>  
                <td class="auto-style3"> </td>  
                <td class="auto-style3"> </td>  
                <td class="auto-style3"> </td>  
            </tr>  
            <tr>  
                <td> </td>  
                <td> </td>  
                <td>  
                    <asp:Label ID="lbl1" runat="server" Font-Size="X-Large" Height="200"></asp:Label>  
                </td>  
                <td> </td>  
                <td> </td>  
                <td> </td>  
            </tr>  
        </table>  
      
    </div>  
    </form>  
</body>  
</html> 