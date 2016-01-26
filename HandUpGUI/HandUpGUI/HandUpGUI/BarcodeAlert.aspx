<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarcodeAlert.aspx.cs" Inherits="HandUpGUI.BarcodeAlert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url(Images/Icons/BG.jpg); background-size: 100%; background-repeat:no-repeat; border:0;">
    <form id="form1" runat="server">
    <div>
    <table width="100%" style="text-align:center">
        <tr>
            <td style="font-weight: bold; font-family: 'Arial Black'; text-decoration: blink">
                <asp:Label ID="lblAlertSent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnGoToLogin" runat="server" Text="Go to Login Page" 
                    onclick="btnGoToLogin_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
