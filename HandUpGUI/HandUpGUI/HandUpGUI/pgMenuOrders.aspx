<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgMenuOrders.aspx.cs" Inherits="HandUpGUI.pgMenuOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    function OpenTable(Number) {
        document.getElementById("<%= hdnTableNumber.ClientID %>").value = Number;
        var ClickChangeTable = document.getElementById("<%= btnChangeTable.ClientID %>");
        ClickChangeTable.click();
    }

    function ChangeDiv(DivDisplay) {
        if (DivDisplay == "Menu") {
            document.getElementById('dvMenu').style.display = '';
            document.getElementById('dvOrderList').style.display = 'none';
            document.getElementById('dvAddTable').style.display = 'none';
        }
        if (DivDisplay == "Order") {
            document.getElementById('dvMenu').style.display = 'none';
            document.getElementById('dvOrderList').style.display = '';
            document.getElementById('dvAddTable').style.display = 'none';
        }
        if (DivDisplay == "Split") {
            document.getElementById('dvMenu').style.display = '';
            document.getElementById('dvOrderList').style.display = '';
            document.getElementById('dvAddTable').style.display = 'none';
        }
        if (DivDisplay == "Hide") {
            document.getElementById('dvMenu').style.display = 'none';
            document.getElementById('dvOrderList').style.display = 'none';
            document.getElementById('dvAddTable').style.display = 'none';
        }
    }

    function ShowAdd() {
        document.getElementById('dvMenu').style.display = 'none';
        document.getElementById('dvOrderList').style.display = 'none';
        document.getElementById('dvAddTable').style.display = '';
    }

    setInterval(myCheckAlert, 5000);

    function myCheckAlert() {
        var CurrentAlert = document.getElementById("<%= lblAlert.ClientID %>").innerHTML;
        if (CurrentAlert == "ALERT") {
            alert("ALERT RUNNING");
        }
        var ClickChangeAlert = document.getElementById("<%= btnAlertUpdate.ClientID %>");
        ClickChangeAlert.click();
    }
</script>
<body>
    <form id="form1" runat="server" enableviewstate="true">
    <div>
            ORDER AND MENU <br /> Welcome back : 
            <asp:Label ID="lblEmployeeUserName" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <table><tr><td><div id="dvTablesTop" runat="server"></div></td><td onclick="ShowAdd()">+</td></tr></table><br /><br />
        <asp:Label ID="lblTableOpened" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    ADD SPACE
                </td>
            </tr>
        </table>
    </div>
    <div id="dvAddTable" style="display: none;">
        <table>
            <tr>
                <td>Add Table</td>
                <td>
                    <asp:Label ID="tblTableName" runat="server" Text="Table Name"></asp:Label>
                    <asp:TextBox ID="txtTableName" runat="server"></asp:TextBox><br />
                    <asp:DropDownList ID="dlPatronCount" runat="server">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:Button ID="btnAddTable" runat="server" Text="+" onclick="btnAddTable_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="dvMenu" style="display: inline;">
        <table>
            <tr>
                <td>THE MENU</td>
            </tr>
        </table>
    </div>
    <div id="dvOrderList" style="display: inline;">
        <table>
            <tr>
                <td>THE ORDER LIST</td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td><asp:Label ID="lblTableGUI" runat="server" Text=""></asp:Label></td>
                <td id="tdMenu" onclick="ChangeDiv('Menu')">Menu</td>
                <td id="tdOrder" onclick="ChangeDiv('Order')">Orders</td>
                <td id="tdSplit" onclick="ChangeDiv('Split')">All</td>
                <td id="td1" onclick="ChangeDiv('Hide')">Hide</td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updateAlerts" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblAlert" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnAlertUpdate" runat="server" Text="Update"
                onclick="btnAlertUpdate_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="visibility:hidden">
        <asp:Button ID="btnChangeTable" runat="server" Text="Change Table" onclick="btnChangeTable_Click" />
        <asp:HiddenField ID="hdnTableNumber" runat="server" />
    </div>
    </form>
</body>
</html>
