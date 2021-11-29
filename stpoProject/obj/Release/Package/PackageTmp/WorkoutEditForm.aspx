<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutEditForm.aspx.cs" Inherits="stpoProject.WorkoutEditForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Edycja treningu</title>
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
            </div>
        </nav><br />
        <h2 class="text-center"><strong><asp:Label ID="Lbl_editWorkout" runat="server" Text="Edycja treningu z dnia: "></asp:Label></strong></h2><br />
        <div class="container navigation-clean-button">
            <div class="row"><br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" SelectCommand="SELECT * FROM [exercise]"></asp:SqlDataSource>
                <div class="mb-3"><asp:Panel ID="Panel_workout" runat="server"></asp:Panel></div>
                <div class="mb-3"><asp:Button Width="150px" CssClass="btn btn-dark" ID="Btn_addField" runat="server" Text="Dodaj ćwiczenie" OnClick="Btn_addField_Click" />
				<asp:Button Width="150px" CssClass="btn btn-dark" ID="Btn_edit" runat="server" OnClick="Btn_edit_Click" Text="Edytuj" />
                <asp:Button Width="150px" CssClass="btn btn-dark" ID="Btn_commit" runat="server" OnClick="Btn_commit_Click" Text="Zatwierdź" />
                <a style="width:10%" class="btn" href="WorkoutForm.aspx">Wróć</a></div>
            </div>
            <asp:Label ID="Lbl_helper" runat="server" ForeColor="#CC3300"></asp:Label>
        </div>
    </form>
</body>
</html>
