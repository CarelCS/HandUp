<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgOnShiftWaiters.aspx.cs" Inherits="HandUpGUI.pgOnShiftWaiters" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvEmployeeList" runat="server">
    </div>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Update On Shift" />
    <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" 
        Text="Back to Management" />
    </form>
</body>
</html>
