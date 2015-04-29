<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgOrderProcessing.aspx.cs" Inherits="HandUpGUI.pgOrderProcessing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<script type="text/javascript">
    function ConfirmOrder(OrderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = OrderID;
        document.getElementById("<%= hdnOrderStatus.ClientID %>").value = "2";
        var ClickChangeAlert = document.getElementById("<%= btnUpdateOrderStatus.ClientID %>");
        ClickChangeAlert.click();
    }

    function OrderWithCallWaiter(OrderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = OrderID;
        document.getElementById("<%= hdnOrderStatus.ClientID %>").value = "3";
        var ClickChangeAlert = document.getElementById("<%= btnUpdateOrderStatus.ClientID %>");
        ClickChangeAlert.click();
    }

    function CancelOrder(OrderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = OrderID;
        document.getElementById("<%= hdnOrderStatus.ClientID %>").value = "4";
        var ClickChangeAlert = document.getElementById("<%= btnUpdateOrderStatus.ClientID %>");
        ClickChangeAlert.click();
    }

    function Order(OrderID) {
        alert("Order " + OrderID);
    }

    function openOrderTextWindow() {
        newWindow = window.open("", null, "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no");
        newWindow.document.write("<textarea id=\"txtAddArea\" cols=\"20\" rows=\"2\"></textarea><br /><input id=\"btnTextAddConfirm\" type=\"button\" onclick=\"window.opener.setValue(document.getElementById('txtAddArea').value);window.close();\" value=\"Add Text\" />");
        var TextValue = window.opener.document.getElementById("<%= hdnTextForOrder.ClientID %>").value;
        alert(TextValue);
        if (TextValue != "") {
            newWindow.close();
        }
    }

    function setValue(value) {
        document.getElementById("<%= hdnTextForOrder.ClientID %>").value = value;
        var ClickChangeAlert = document.getElementById("<%= btnUpdateTextValues.ClientID %>");
        ClickChangeAlert.click();
    }

    function AddTextTable(OrderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = OrderID;
        openOrderTextWindow();
    }
</script>
<body style="background-image:url(Images/Icons/BG.jpg); background-size: 100%; background-repeat:repeat; border:0;">
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                THE ORDER LIST
            </td>
            <div id="dvTablesOrders" runat="server">
            </div>
        </tr>
    </table>
    <div style="visibility: hidden">
        <asp:Button ID="btnUpdateTextValues" runat="server" Text="UPdateText" OnClick="btnUpdateTextValues_Click" />
        <asp:Button ID="btnUpdateOrderStatus" runat="server" Text="Button" OnClick="btnUpdateOrderStatus_Click" />
        <asp:HiddenField ID="hdnTableNumber" runat="server" />
        <asp:HiddenField ID="hdnTextForOrder" runat="server" />
        <asp:HiddenField ID="hdnOrderNumber" runat="server" />
        <asp:HiddenField ID="hdnOrderStatus" runat="server" />
    </div>
    </form>
</body>
</html>
