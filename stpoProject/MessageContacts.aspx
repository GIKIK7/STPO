<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageContacts.aspx.cs" Inherits="stpoProject.MessageContacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Lista konwersacji</title>
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
        <h2 class="text-center"><strong>Konwersacje</strong></h2><br />
        <div class="container">
            <div class="row navigation-clean-button">
                <div class="mb-3 navbar-brand"><asp:Label ID="LbL_contactsInfo" runat="server" Text="Rozmowy: "></asp:Label><br /></div>
                <div class="mb-3"><asp:Panel ID="Panel_conversation" runat="server"></asp:Panel></div>
            </div>
            <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
       </div>        
    </form>
</body>
</html>