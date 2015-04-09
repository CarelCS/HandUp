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
    </table>
    </div>
    <div id="dvMenu" style="display: none;">
    <table width="100%">
        <tr><td>Menu</td></tr>
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
    </table>
    </div>
    </form>
</body>
</html>
