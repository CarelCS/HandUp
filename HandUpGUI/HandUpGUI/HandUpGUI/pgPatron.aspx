<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgPatron.aspx.cs" Inherits="HandUpGUI.pgPatron" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url(Images/Icons/BG.jpg); background-size: 100%; background-repeat:no-repeat; border:0;">
    <form id="form1" runat="server">
    <div>
    <table width="100%">
        <tr align="center">
            <td align="right">Restaurant Menus</td>
            <td align="left">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="center">
            <td align="right"></td>
            <td align="left">
                <asp:Button ID="btnSeeMenu" runat="server" Text="VIew Menu" 
                    onclick="btnSeeMenu_Click" />
            </td>
        </tr>
        <tr align="center">
            <td align="right">Join Table Code</td>
            <td align="left">
                <asp:TextBox ID="txtTableCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr align="center">
            <td align="right"></td>
            <td align="left">
                <asp:Button ID="btnJoinTable" runat="server" Text="JoinTable" 
                    onclick="btnJoinTable_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
