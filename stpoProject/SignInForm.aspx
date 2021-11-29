<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInForm.aspx.cs" Inherits="stpoProject.SignInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"/>
    <title>Zarejestruj się</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css"/>
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css"/>
    <link rel="stylesheet" href="assets/css/styles.css"/> 
</head>  
<body>  
    <section class="login-clean">
        <form method="post" runat="server">
            <h2 class="text-center"><strong>Zarejestruj się</strong></h2><br /><hr />
            <div class="mb-3"><asp:Label ID="Lbl_login" runat="server" Font-Size="Large" Text="Login:"></asp:Label></div>
            <div class="mb-3"><asp:TextBox CssClass="form-control" ID="TxtBox_login" runat="server" Font-Size="Large"></asp:TextBox></div>
            <div class="mb-3"><asp:Label ID="Lbl_password" runat="server" Font-Size="Large" Text="Hasło:"></asp:Label></div>
            <div class="mb-3"><asp:TextBox CssClass="form-control" ID="TxtBox_password" runat="server" Font-Size="Large" TextMode="Password" ></asp:TextBox></div>
            <div class="mb-3"><asp:Label ID="Lbl_name" runat="server" Font-Size="Large" Text="Imię:"></asp:Label></div>
            <div class="mb-3"><asp:TextBox CssClass="form-control" ID="TxtBox_name" runat="server" Font-Size="Large"></asp:TextBox></div>
            <div class="mb-3"><asp:Label ID="Lbl_lastName" runat="server" Font-Size="Large" Text="Nazwisko:"></asp:Label></div>
            <div class="mb-3"><asp:TextBox CssClass="form-control" ID="TxtBox_LastName" runat="server" Font-Size="Large"></asp:TextBox></div>
            <div class="mb-3"><asp:CheckBox ID="ChkBox_trener" runat="server" OnCheckedChanged="ChkBox_trener_CheckedChanged" Text="&nbspTrener" AutoPostBack="true" /></div>
            <div class="mb-3"><asp:DropDownList ID="DropList_category" runat="server" DataSourceID="SqlDataSource1" DataTextField="categoryName" DataValueField="categoryName" Enabled="False"></asp:DropDownList></div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" SelectCommand="SELECT [categoryName], [ID] FROM [category]"></asp:SqlDataSource>
            <div class="mb-3"><asp:Button CssClass="btn btn-primary d-block w-100" ID="Btn_SignIn" runat="server" BorderStyle="None" Font-Size="Large" OnClick="Btn_SignIn_Click" Text="Zarejestruj się"/></div>
            <div class="mb-3 text-center"><asp:Label ID="Lbl_Helper" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label></div>
            <a class="forgot" href="LogInForm.aspx">Zaloguj się</a>
        </form>
    </section>
</body>  
</html>  
