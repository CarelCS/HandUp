<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgPatron.aspx.cs" Inherits="HandUpGUI.pgPatron" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>Restaurant Menus</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSeeMenu" runat="server" Text="VIew Menu" 
                    onclick="btnSeeMenu_Click" />
            </td>
        </tr>
        <tr>
            <td>Join Table Code</td>
            <td>
                <asp:TextBox ID="txtTableCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnJoinTable" runat="server" Text="JoinTable" 
                    onclick="btnJoinTable_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
