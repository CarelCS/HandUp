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
                document.getElementById('dvEmployeeDetails').style.display = '';
                document.getElementById('dvEmployee').style.display = '';
                document.getElementById('dvMenu').style.display = 'none';
                document.getElementById('dvReports').style.display = 'none';
                document.getElementById('dvTableManagement').style.display = 'none';
                break;
            case "2":
                document.getElementById('dvEmployeeDetails').style.display = 'none';
                document.getElementById('dvEmployee').style.display = 'none';
                document.getElementById('dvMenu').style.display = '';
                document.getElementById('dvReports').style.display = 'none';
                document.getElementById('dvTableManagement').style.display = 'none';
                break;
            case "3":
                document.getElementById('dvEmployeeDetails').style.display = 'none';
                document.getElementById('dvEmployee').style.display = 'none';
                document.getElementById('dvMenu').style.display = 'none';
                document.getElementById('dvReports').style.display = '';
                document.getElementById('dvTableManagement').style.display = 'none';
                break;
            case "4":
                document.getElementById('dvEmployeeDetails').style.display = 'none';
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
    <div id="dvEmployeeDetails">
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTel" runat="server" Text="Contact Number"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rbtnGender" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress1" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdress1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblAddress2" runat="server" Text="Address2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress3" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress3" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmpType" runat="server" Text="Employee Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEmpType" runat="server">
                    <asp:ListItem Value="1">Waiter</asp:ListItem>
                    <asp:ListItem Value="2">Processor</asp:ListItem>
                    <asp:ListItem Value="3">Guest</asp:ListItem>
                    <asp:ListItem Value="4">Administrator</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEmpStatus" runat="server">
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="2">Inactive</asp:ListItem>
                    <asp:ListItem Value="3">Deleted</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="calStartDate" runat="server"></asp:Calendar>
            </td>
            <td>
                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="calEndDate" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnClearAddNew" runat="server" Text="Add New Employee" 
                    onclick="btnClearAddNew_Click" />
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnUpdateAddEmp" runat="server" Text="Submit" 
                    onclick="btnUpdateAddEmp_Click" />
            </td>
        </tr>
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
