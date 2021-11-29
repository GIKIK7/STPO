<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientSearchForm.aspx.cs" Inherits="stpoProject.ClientSearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Klienci</title>
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
        <h2 class="text-center"><strong><asp:Label ID="Lbl_Coaches" runat="server" Text="Klienci"></asp:Label></strong></h2><br />
        <div class="container col-md-6">
            <asp:Label ID="LbL_sort" runat="server" Text="Sortuj po: "></asp:Label>
            <asp:Button CssClass="btn" ID="Btn_sortByName" runat="server" OnClick="Btn_sortByName_Click" Text="imieniu" />
            <asp:Button CssClass="btn" ID="Btn_sortByLastName" runat="server" Text="nazwisku" OnClick="Btn_sortByLastName_Click" />
            <asp:Button CssClass="btn" ID="Btn_charges" runat="server" OnClick="Btn_charges_Click" Text="tylko Twoi podopieczni" />
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="mb-3 navigation-clean-button" style="width:100%;"><asp:DataList ID="DataList2" runat="server" DataSourceID="DataSource_coaches" OnItemCommand="itemCommand">
                    <ItemTemplate>
                    Imię:
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                    <br />
                    Nazwisko:
                    <asp:Label ID="last_nameLabel" runat="server" Text='<%# Eval("last_name") %>' />
                    <br />
                    <asp:Button CssClass="btn btn-dark" ID="Btn_goToCoachPage" runat="server" Text="Przejdź do profilu" commandargument='<%# Eval("ID") %>'/>
                    <hr />
                    </ItemTemplate>
                    </asp:DataList>
                    <div class="mb-3"><a style="width:100px" class="btn" href="CoachDetailsForm.aspx">Wróć</a></div>
                </div>
                    <asp:SqlDataSource ID="DataSource_coaches" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" 
                            SelectCommand='SELECT [name], [last_name], [ID] FROM [clients]'></asp:SqlDataSource>
            </div>
            <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
        </div>  
    </form>
</body>
</html> 