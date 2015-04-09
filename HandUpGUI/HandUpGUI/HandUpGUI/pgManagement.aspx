<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgManagement.aspx.cs" Inherits="HandUpGUI.pgManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script language="javascript">

    function ChangePage(Option) {
        switch (Option) {
            case "1":
                document.getElementById('dvEmployee').style.display = '';
                document.getElementById('dvMenu').style.display = 'none';
                document.getElementById('dvReports').style.display = 'none';
                document.getElementById('dvTableManagement').style.display = 'none';
                break;
            case "2":
                document.getElementById('dvEmployee').style.display = 'none';
                document.getElementById('dvMenu').style.display = '';
                document.getElementById('dvReports').style.display = 'none';
                document.getElementById('dvTableManagement').style.display = 'none';
                break;
            case "3":
                document.getElementById('dvEmployee').style.display = 'none';
                document.getElementById('dvMenu').style.display = 'none';
                document.getElementById('dvReports').style.display = '';
                document.getElementById('dvTableManagement').style.display = 'none';
                break;
            case "4":
                document.getElementById('dvEmployee').style.display = 'none';
                document.getElementById('dvMenu').style.display = 'none';
                document.getElementById('dvReports').style.display = 'none';
                document.getElementById('dvTableManagement').style.display = '';
                break;
            default:
        }
    }

    function EditDeleteMenuItem(MenuID, Status) {
        document.getElementById("<%= hdnMenuID.ClientID %>").value = MenuID;
        document.getElementById("<%= hdnMenuStatus.ClientID %>").value = Status;
        var ClickChangeAlert = document.getElementById("<%= btnEditMenuItem.ClientID %>");
        ClickChangeAlert.click();
    }

    function EditDeleteEmployee(Employee, Status, Active) {
        document.getElementById("<%= hdnEmployeeID.ClientID %>").value = MenuID;
        document.getElementById("<%= hdnEmployeeStatus.ClientID %>").value = Status;
        document.getElementById("<%= hdnEmployeeActive.ClientID %>").value = Active;
        var ClickChangeAlert = document.getElementById("<%= btnEditEmployee.ClientID %>");
        ClickChangeAlert.click();
    }

    function EditDeleteTable(TableID) {
        document.getElementById("<%= hdnTableID.ClientID %>").value = MenuID;
        var ClickChangeAlert = document.getElementById("<%= btnEditEmployee.ClientID %>");
        ClickChangeAlert.click();
    }

    function MoveOrder(OrderID) {
    }

    function openOrderTextWindow() {
        newWindow = window.open("", null, "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no");
        newWindow.document.write("<textarea id=\"txtAddArea\" cols=\"20\" rows=\"2\"></textarea><br /><input id=\"btnTextAddConfirm\" type=\"button\" onclick=\"window.opener.setValue(document.getElementById('txtAddArea').value);window.close();\" value=\"Add Text\" />");
        var TextValue = window.opener.document.getElementById("<%= hdnTextForOrder.ClientID %>").value;
        //alert(TextValue);
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
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1">
        <tr>
            <td>
            <div id="dvEmployeeOption" onclick="ChangePage('1')">Employees</div>
            </td>
            <td>
            <div id="dvMenuOption" onclick="ChangePage('2')">Menu</div>
            </td>
            <td>
            <div id="dvReportOption" onclick="ChangePage('3')">Reports</div>
            </td>
            <td>
            <div id="dvTableManagementOption" onclick="ChangePage('4')">Table Management</div>
            </td>
        </tr>
    </table>
    </div>
    <div id="dvEmployee">
    <table width="100%">
        <tr><td>Employees</td></tr>
        <tr><td><div id="dvEmployeeList" runat="server"></div></td></tr>
        <tr><td><div id="dvEmployeeEditAdd" runat="server"></div></td></tr>
    </table>
    </div>
    <div id="dvMenu" style="display: none;">
    <table width="100%">
        <tr><td>Menu</td></tr>
        <tr><td><div id="dvMenulist" runat="server"></div></td></tr>
        <tr><td><div id="dvMenuItemEditAdd" runat="server"></div></td></tr>
    </table>
    </div>
    <div id="dvReports" style="display: none;">
    <table width="100%">
        <tr><td>Reports</td></tr>
    </table>
    </div>
    <div id="dvTableManagement" style="display: none;">
    <table width="100%">
        <tr><td>Table Management</td></tr>
        <tr><td><div id="dvTableList" runat="server"></div></td></tr>
        <tr><td><div id="dvEditTableOrders" runat="server"></div></td></tr>
    </table>
    </div>
    <div id="dvHiddenFields">
        <asp:HiddenField ID="hdnMaxSubs" runat="server" />
        <asp:Button ID="btnEditEmployee" runat="server" Text="Button" onclick="btnEditEmployee_Click" />
        <asp:Button ID="btnEditMenuItem" runat="server" Text="Button" onclick="btnEditMenuItem_Click" />
        <asp:Button ID="btnEditTable" runat="server" Text="Button" 
            onclick="btnEditTable_Click" />
        <asp:Button ID="btnUpdateTextValues" runat="server" Text="Button" 
            onclick="btnUpdateTextValues_Click" />
        <asp:HiddenField ID="hdnMenuID" runat="server" />
        <asp:HiddenField ID="hdnMenuStatus" runat="server" />
        <asp:HiddenField ID="hdnEmployeeID" runat="server" />
        <asp:HiddenField ID="hdnEmployeetatus" runat="server" />
        <asp:HiddenField ID="hdnEmployeeActive" runat="server" />
        <asp:HiddenField ID="hdnTableID" runat="server" />
        <asp:HiddenField ID="hdnTextForOrder" runat="server" />
        <asp:HiddenField ID="hdnOrderNumber" runat="server" />
    </div>
    </form>
</body>
</html>
