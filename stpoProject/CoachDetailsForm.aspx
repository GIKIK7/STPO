<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachDetailsForm.aspx.cs" Inherits="stpoProject.TrenerDetailsForm" %>

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
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_searchClients" runat="server" OnClick="Btn_searchClients_Click" Text="Przegądaj trenerów" />&nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_chat" runat="server" OnClick="Btn_chat_Click" Text="Wiadomości" />&nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_goToEditCoachProfile" runat="server" OnClick="Btn_goToEditCoachProfile_Click" Text="Edytuj profil" />&nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-light action-button" ID="Btn_wyloguj" runat="server" OnClick="Btn_wyloguj_Click" Text="Wyloguj sie" />
                </div>
            </div>
        </nav>
        <div class="container">
            <asp:Button CssClass="btn btn-dark" ID="Btn_goToYourProfile" runat="server" OnClick="Btn_goToYourProfile_Click" Text="Wróć do swojego profilu" />
            <asp:Button CssClass="btn btn-dark" ID="Btn_dealStart" runat="server" OnClick="Btn_dealStart_Click" Text="Rozpocznij współpracę" />
        </div><br />
        <div class="container">
            <div class="mb-3 navbar-brand">Kategoria:&nbsp;<asp:Label ID="LbL_Category" runat="server"></asp:Label></div><br />
        </div>
        <div class="container navigation-clean-button">
            <div class="row">
                <div class="col-md-6" style="width:12%"><asp:Label ID="Lbl_dietPrice" runat="server" Text="Cena za diete:"></asp:Label></div>
                <div class="col-md-6" style="width:7%"><asp:Label ID="Lbl_actualDietPrice" runat="server" Text="brak"></asp:Label>
                <asp:Label ID="Lbl_currency" runat="server" Text="zł"></asp:Label><br /></div><br />
                <div class="mb-3"><asp:TextBox ID="TxtBox_dietPrice" runat="server" Width="50px"></asp:TextBox></div><br />
            
                <div class="mb-3"><asp:Button Width="10%" CssClass="btn btn-dark" ID="Btn_updateDietPrice" runat="server" OnClick="Btn_updateDietPrice_Click" Text="Zatwierdź" /></div>
                <hr />
                <div class="col-md-6" style="width:12%"><asp:Label ID="Lbl_workoutPrice" runat="server" Text="Cena za trening:"></asp:Label></div>
                <div class="col-md-6" style="width:7%"><asp:Label ID="Lbl_actualWorkoutPrice" runat="server" Text="brak"></asp:Label>
                <asp:Label ID="Lbl_currency2" runat="server" Text="zł"></asp:Label><br /></div><br />
                <div class="mb-3"><asp:TextBox ID="TxtBox_workoutPrice" runat="server" Width="50px"></asp:TextBox></div><br />
                <div class="mb-3"><asp:Button Width="10%" CssClass="btn btn-dark" ID="Btn_updateWorkoutPrice" runat="server" OnClick="Btn_updateWorkoutPrice_Click" Text="Zatwierdź" /></div>               
                <br /><hr />
                <div class="mb-3"><asp:Label ID="Lbl_rate" runat="server" Font-Bold="True" Text="Średnia ocena trenera to:"></asp:Label></div>
                <br /><br /><hr />
                <div class="mb-3"><asp:DropDownList ID="DropList_ratings" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList></div>
                <div class="mb-3"><asp:Button Width="15%" CssClass="btn btn-dark" ID="Btn_rateCoach" runat="server" OnClick="Btn_rateCoach_Click" Text="Oceń" /></div>
                <div class="mb-3"><asp:Panel ID="Panel_comments" runat="server"></asp:Panel></div>
                <div class="mb-3"><asp:TextBox ID="TxtBox_com" runat="server" width="100%" ></asp:TextBox></div>
                <div class="mb-3"><asp:Button Width="15%" CssClass="btn btn-dark" ID="Btn_writeComm" runat="server" OnClick="Btn_writeComm_Click" Text="Napisz Komentarz" /></div>
                <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

                        
