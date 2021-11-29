<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessagesForm.aspx.cs" Inherits="stpoProject.MessagesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Chat</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css"/>
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css"/>
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css"/>
    <link rel="stylesheet" href="assets/css/Registration-Form-with-Photo.css"/>
    <link rel="stylesheet" href="assets/css/styles.css"/>
    <style type="text/css">
        .logo {
            margin-left:auto;
            margin-right:auto;
            width: 75px;
            height: 75px;
        }
    </style>
</head>
<body style="background-color:#f1f7fc">
    <form id="form2" runat="server">
        <nav class="navbar navbar-light navbar-expand-lg navigation-clean-button">
            <div class="container"><a class="navbar-brand" href="#" runat="server" onserverclick="Btn_back_Click"><img class="logo" src="assets/logoS.png" />
                <asp:Label ID="Lbl_lastName" runat="server" Text="Imię i Nazwisko"></asp:Label></a>
            </div>
        </nav><br />
        <h2 class="text-center"><strong>Chat</strong></h2><br />
        <div class="container">
            <div class="row navigation-clean-button">
                <div class="mb-3"><asp:Panel ID="Panel1" runat="server" style="width:100%" Height="500px" ScrollBars="Auto"></asp:Panel></div>
                <div class="mb-3"><asp:TextBox ID="TxtBox_content" Width="90%" runat="server"></asp:TextBox>
                <asp:Button CssClass="btn btn-dark" ID="Btn_Send" runat="server" Text="Wyślij" style="width:9%" OnClick="Btn_Send_Click" /></div>
            </div>
       </div>        
    </form>
</body>
</html>
