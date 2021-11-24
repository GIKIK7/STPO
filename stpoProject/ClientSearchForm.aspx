<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientSearchForm.aspx.cs" Inherits="stpoProject.ClientSearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width:100%">
                <tr>
                    <td style="width:15%">
                        <asp:Button ID="Btn_back" runat="server" Text="Wróc do swojego profilu" OnClick="Btn_back_Click" />
                    </td>
                    <td align="center" style="width:70%">
                        <asp:Label ID="Lbl_Coaches" runat="server" Text="Klienci" ></asp:Label>
                    </td>
                    <td style="width:15%">
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td >
                        <asp:Label ID="LbL_sort" runat="server" Text="Sortuj po: "></asp:Label>
                        <asp:Button ID="Btn_sortByName" runat="server" OnClick="Btn_sortByName_Click" Text="imieniu" />
                        <asp:Button ID="Btn_sortByLastName" runat="server" Text="nazwisku" OnClick="Btn_sortByLastName_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3">
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="DataSource_coaches" OnItemCommand="itemCommand">
                            <ItemTemplate>
                                imie:
                                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                                <br />
                                nazwisko:
                                <asp:Label ID="last_nameLabel" runat="server" Text='<%# Eval("last_name") %>' />
                                <br />
                                kategoria:
                                <asp:Button ID="Btn_goToCoachPage" runat="server" Text="Strona" commandargument='<%# Eval("ID") %>'/>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="DataSource_coaches" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" 
                            SelectCommand='SELECT [name], [last_name], [ID] FROM [clients]'></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style1"></td>
                </tr>

            </table>

        </div>
    </form>
</body>

</html>
