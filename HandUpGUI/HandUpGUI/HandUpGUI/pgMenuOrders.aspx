<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgMenuOrders.aspx.cs" Inherits="HandUpGUI.pgMenuOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            ORDER AND MENU <br /> Welcome back : 
            <asp:Label ID="lblEmployeeUserName" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <table><tr><td></td><td><asp:Button ID="btnAddTable" runat="server" Text="+" 
                onclick="btnAddTable_Click" /></td></tr></table>
    </div>
    </form>
</body>
</html>
