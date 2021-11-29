<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutForm.aspx.cs" Inherits="stpoProject.WorkoutForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Trening</title>
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
            <div class="container"><a class="navbar-brand" href="#" runat="server" onserverclick="Btn_goBack_Click"><img class="logo" src="assets/logoS.png" />
                <asp:Label ID="Lbl_lastName" runat="server" Text="Imię i Nazwisko"></asp:Label></a>
                <asp:Button style="position:center" CssClass="btn btn-dark" ID="Btn_editWorkout" runat="server" OnClick="Btn_editWorkout_Click" Text="Edytuj trening" />            
            </div>
        </nav><br />
        <h2 class="text-center"><strong><asp:Label ID="Lbl_workout" runat="server" Text="Trening z dnia: "></asp:Label></strong></h2><br />
        <div class="container navigation-clean-button">
            <div class="row"><br />
                <asp:Panel ID="Panel_workout" runat="server"></asp:Panel>
            </div><hr />
            <div class="mb-3"><a style="width:100px" class="btn" href="WorkoutListForm.aspx">Wróć</a></div>
            <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
        </div><br/< />
    </form>
</body>
</html>
