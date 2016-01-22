<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgOrderProcessing.aspx.cs" Inherits="HandUpGUI.pgOrderProcessing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<script type="text/javascript">
    function AcceptOrder(orderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = orderID;
        document.getElementById("<%= hdnOrderStatus.ClientID %>").value = "5";
        var ClickChangeAlert = document.getElementById("<%= btnUpdateOrderStatus.ClientID %>");
        ClickChangeAlert.click();
    }

    function ConfirmProcessed(orderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = orderID;
        document.getElementById("<%= hdnOrderStatus.ClientID %>").value = "6";
        var ClickChangeAlert = document.getElementById("<%= btnUpdateOrderStatus.ClientID %>");
        ClickChangeAlert.click();
    }

    function CompleteOrder(orderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = orderID;
        document.getElementById("<%= hdnOrderStatus.ClientID %>").value = "6";
        var ClickChangeAlert = document.getElementById("<%= btnUpdateOrderStatus.ClientID %>");
        ClickChangeAlert.click();
    }

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
        newWindow = window.open("", null, "height=200,width=800,status=yes,toolbar=no,menubar=no,location=no");
        newWindow.document.body.style = "background-image: url('Images/Icons/BG.jpg');" //.backgroundImage = "url('Images/Icons/BG.jpg')";
        newWindow.document.write("<textarea id=\"txtAddArea\" cols=\"110\" rows=\"10\"></textarea><br /><input id=\"btnTextAddConfirm\" type=\"button\" onclick=\"window.opener.setValue(document.getElementById('txtAddArea').value);window.close();\" value=\"Add Text\" />");
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

    setInterval(myCheckAlert, 10000);

    function myCheckAlert() {
        var ClickChangeAlert = document.getElementById("<%= btnRefresh.ClientID %>");
        ClickChangeAlert.click();
    }
</script>
<body style="background: linear-gradient(to right, silver, white);"><%----%>
    <form id="form1" runat="server">
    <asp:Button ID="btnLogout" runat="server" Text="Logout" 
        onclick="btnLogout_Click" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updateAlerts" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        THE ORDER LIST
                    </td>
                    <div id="dvTablesOrders" runat="server">
                    </div>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="visibility: hidden">
        <asp:Button ID="btnUpdateTextValues" runat="server" Text="UPdateText" OnClick="btnUpdateTextValues_Click" />
        <asp:Button ID="btnUpdateOrderStatus" runat="server" Text="Button" OnClick="btnUpdateOrderStatus_Click" />
        <asp:Button ID="btnRefresh" runat="server" Text="Button" OnClick="btnRefresh_Click"/>
        <asp:HiddenField ID="hdnTableNumber" runat="server" />
        <asp:HiddenField ID="hdnTextForOrder" runat="server" />
        <asp:HiddenField ID="hdnOrderNumber" runat="server" />
        <asp:HiddenField ID="hdnOrderStatus" runat="server" />
    </div>
    </form>
</body>
</html>
