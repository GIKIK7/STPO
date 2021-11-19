<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachSearchForm.aspx.cs" Inherits="stpoProject.CoachSearchForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .cell
        {
            width: 500px;
            float: left;
            padding: 2px;
        }      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width:100%">
                <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Lbl_Coaches" runat="server" Text="Trenerzy" ></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="LbL_sort" runat="server" Text="Sortuj po: "></asp:Label>
                        <asp:Button ID="Btn_sortByName" runat="server" OnClick="Btn_sortByName_Click" Text="imieniu" />
                        <asp:Button ID="Btn_sortByLastName" runat="server" Text="nazwisku" OnClick="Btn_sortByLastName_Click" />
                        <asp:Button ID="Btn_sortByCategory" runat="server" Text="Kategorii" OnClick="Btn_sortByCategory_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="DataSource_coaches" OnItemCommand="itemCommand">
                            <ItemTemplate>
                                imie:
                                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                                <br />
                                nazwisko:
                                <asp:Label ID="last_nameLabel" runat="server" Text='<%# Eval("last_name") %>' />
                                <br />
                                kategoria:
                                <asp:Label ID="categoryNameLabel" runat="server" Text='<%# Eval("categoryName") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="DataSource_coaches" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" 
                            SelectCommand='SELECT [name], [last_name], [categoryName] FROM [CoachesWithCategories]'></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style1"></td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
