<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDetailsForm.aspx.cs" Inherits="stpoProject.ClientDetailsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Profil</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css"/>
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css"/>
    <link rel="stylesheet" href="assets/css/Navigation-with-Button.css"/>
    <link rel="stylesheet" href="assets/css/Registration-Form-with-Photo.css"/>
    <link rel="stylesheet" href="assets/css/styles.css"/>
    <style type="text/css">
        .workout {
            background-image: url(assets/hamtal.png);
            width: 600px;
            height: 600px;
            margin-left:auto;
            margin-right:auto;
        }
        .diet {
            background-image: url(assets/broku.png);
            width: 600px;
            height: 600px;
            margin-left:auto;
            margin-right:auto;
        }
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
            <div class="container"><a class="navbar-brand" href="#"><img class="logo" src="assets/logoS.png" />
                <asp:Label ID="Lbl_Name" runat="server"></asp:Label>&nbsp;<asp:Label ID="Lbl_lastName" runat="server"></asp:Label></a>     
                <div id="navcol-1" class="collapse navbar-collapse navbar-text actions" style="position:absolute; right: 325px">
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_searchCoaches" runat="server" OnClick="Btn_searchCoaches_Click" Text="Przeglądaj trenerów" />&nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_Chat" runat="server" OnClick="Btn_Chat_Click" Text="Wiadomości" />&nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light action-button" ID="btn_goToEditClientProfile" runat="server" OnClick="btn_goToEditClientProfile_Click" Text="Edytuj profil" />&nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_wyloguj" runat="server" OnClick="Btn_wyloguj_Click" Text="Wyloguj sie" />
                </div>
            </div>
        </nav>
        <div class="container"><asp:Button CssClass="btn btn-dark" ID="Btn_goToYourProfile" runat="server" OnClick="Btn_goToYourProfile_Click" Text="Wróć do swojego profilu" /></div><br />
        <div class="container">
            <div class="mb-3 navbar-brand">Przypisany trener:&nbsp;<asp:Label ID="Lbl_assignCoach" runat="server"></asp:Label></div><br />
        </div>
        <div class="container">
            <div class="row">
                <asp:Button CssClass="workout" ID="Btn_workout" runat="server" OnClick="Btn_workout_Click"/>
                <asp:Button CssClass="diet" ID="Btn_Diet" runat="server" OnClick="Btn_makeDiet_Click"/>
            </div>
            <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>


                        
                        
                        

                         
 
                        

                        
