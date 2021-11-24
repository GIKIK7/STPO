<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="stpoProject.LogInForm" %>

<!DOCTYPE html>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">   
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Untitled</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css"/>
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css"/>
    <link rel="stylesheet" href="assets/css/styles.css"/> 
</head>  
<body>  
    <section class="login-clean">
        <form method="post" runat="server">
            <h2 class="visually-hidden">Login Form</h2>
            <div class="illustration"><i class="icon ion-ios-navigate"></i></div>
            <div class="mb-3"><asp:Label ID="LbL_User" runat="server" Font-Size="X-Large" Text="Login:"></asp:Label></div>
            <div class="mb-3"><asp:TextBox CssClass="form-control" ID="TxtBox_User" runat="server" Font-Size="X-Large"></asp:TextBox></div>
            <div class="mb-3"><asp:Label ID="Lbl_Password" runat="server" Font-Size="X-Large" Text="Hasło :"></asp:Label></div>
            <div class="mb-3"><asp:TextBox CssClass="form-control" ID="TxtBox_Password" runat="server" Font-Size="X-Large" TextMode="Password" ></asp:TextBox></div>
            <div class="mb-3"><asp:Button CssClass="btn btn-primary d-block w-100" ID="Btn_LogIn" runat="server" BorderStyle="None" Font-Size="X-Large" OnClick="Btn_LogInClick" Text="Zaloguj się"/></div>
            <div class="mb-3"><asp:Label ID="LbL_Helper" runat="server" Font-Size="X-Large"></asp:Label></div>
        </form>
    </section>
</body>  
</html>  