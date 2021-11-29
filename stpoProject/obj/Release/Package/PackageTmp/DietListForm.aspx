<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DietListForm.aspx.cs" Inherits="stpoProject.DietListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Dieta</title>
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
            <div class="container"><a class="navbar-brand" href="#" runat="server" onserverclick="Btn_goBackToYourProfile_Click"><img class="logo" src="assets/logoS.png" />
                <asp:Label ID="Lbl_lastName" runat="server" Text="Imię i Nazwisko"></asp:Label></a>
                <asp:Button style="position:center" CssClass="btn btn-dark" ID="Btn_createDiet" runat="server" OnClick="Btn_createDiet_Click" Text="Stwórz dietę" />
            </div>
        </nav><br />
        <h2 class="text-center"><strong>Wybierz dzień diety</strong></h2><br />
        <div class="container">
            <div class="row">
                <asp:Panel CssClass="navigation-clean-button" ID="Panel_diet" runat="server"></asp:Panel>
            </div>
       </div>        
    </form>
</body>
</html>
