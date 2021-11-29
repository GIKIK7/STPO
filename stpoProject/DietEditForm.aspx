<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DietEditForm.aspx.cs" Inherits="stpoProject.DietEditForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Edycja diety</title>
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
        <h2 class="text-center"><strong><asp:Label ID="Lbl_diet" runat="server" Text="Edycja diety z dnia: "></asp:Label></strong></h2><br />
        <div class="container navigation-clean-button">
            <div class="row"><br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" SelectCommand="SELECT * FROM [meals]"></asp:SqlDataSource>
                <div class="col-md-6" style="width:100px"><asp:Label ID="Lbl_sniadanie" runat="server" Text="Śniadanie: "></asp:Label></div>
                <div class="col-md-6" style="width:200px"><asp:DropDownList ID="DropList_breakfast" runat="server" DataSourceID="SqlDataSource1" DataTextField="mealName" DataValueField="ID"></asp:DropDownList></div>
                &nbsp;&nbsp;<div class="col-md-6" style="width:200px"><asp:TextBox ID="TxtBox_breakfast" runat="server" Width="60px"></asp:TextBox> g</div></div>
            <div class="row">
                <div class="col-md-6" style="width:100px"><asp:Label ID="Lbl_dinner" runat="server" Text="Obiad: "></asp:Label></div>
                <div class="col-md-6" style="width:200px"><asp:DropDownList ID="DropList_dinner" runat="server" DataSourceID="SqlDataSource1" DataTextField="mealName" DataValueField="ID"></asp:DropDownList></div>
                &nbsp;&nbsp;<div class="col-md-6" style="width:200px"><asp:TextBox ID="TxtBox_dinner" runat="server" Width="60px"></asp:TextBox> g</div></div>
            <div class="row">
                <div class="col-md-6" style="width:100px"><asp:Label ID="Lbl_supper" runat="server" Text="Kolacja: "></asp:Label></div>
                <div class="col-md-6" style="width:200px"><asp:DropDownList ID="DropList_supper" runat="server" DataSourceID="SqlDataSource1" DataTextField="mealName" DataValueField="ID"></asp:DropDownList></div>
                &nbsp;&nbsp;<div class="col-md-6" style="width:200px"><asp:TextBox ID="TxtBox_supper" runat="server" Width="60px"></asp:TextBox> g</div></div>
                <div class="mb-3"><asp:Button CssClass="btn btn-dark" ID="Btb_addDiet" runat="server" OnClick="Btb_addDiet_Click" Text="Edytuj" /><a style="width:10%" class="btn" href="DietForm.aspx">Wróć</a></div>
            <asp:Label ID="Lbl_helper" runat="server" ForeColor="#CC3300"></asp:Label>
        </div>
    </form>
</body>
</html>


                    
 
                    

                    

                    


