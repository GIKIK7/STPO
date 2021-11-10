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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width:100%">
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="DataSource_coaches">
                            <ItemTemplate>
                                name:
                                <asp:LinkButton ID="nameLabel" runat="server" Text='<%# Eval("name") %>'/>
                                <br />
                                last_name:
                                <asp:LinkButton ID="last_nameLabel" runat="server" Text='<%# Eval("last_name") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="DataSource_coaches" runat="server" ConnectionString="<%$ ConnectionStrings:DBstpoConnectionString %>" 
                            SelectCommand="SELECT [name], [last_name] FROM [coaches]"></asp:SqlDataSource>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Label ID="Lbl_helper" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style1"></td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
