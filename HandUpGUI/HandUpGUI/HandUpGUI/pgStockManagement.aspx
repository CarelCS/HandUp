<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgStockManagement.aspx.cs" Inherits="HandUpGUI.pgStockManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="javascript" type="text/javascript">
    function ChangeStock(StockID) {
        document.getElementById("<%= hdnStockNumber.ClientID %>").value = StockID;
        var ClickChange = document.getElementById("<%= btnUpdateStockItemHidden.ClientID %>");
        ClickChange.click();
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="background: linear-gradient(to right, silver, white); background-size: 100%; background-repeat:repeat; border:0;">
    <form id="form1" runat="server" enableviewstate="true" >
    <div>
        <table>
            <tr>
                <td><div id="dvStockList" runat="server"></div></td>
            </tr>
        </table>
    </div>
    <div id="dvStockEdit">
    <table>
        <tr>
            <td>Stock Item : </td>
            <td>
                <asp:DropDownList ID="ddlStockItem" runat="server">
                </asp:DropDownList>
            </td>
            <td>Menu Item Linked : </td>
            <td>
                <asp:DropDownList ID="ddlMenuItem" runat="server" AutoPostBack="true" EnableViewState="true" ViewStateMode="Enabled"
                    onselectedindexchanged="ddlMenuItem_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSubmenuItem" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Description : </td>
            <td>
                <asp:TextBox ID="txtStockDesc" Rows="2" runat="server"></asp:TextBox></td>
            <td>Quantity to reduce : </td>
            <td>
                <asp:TextBox ID="txtReduceCount" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Stock Level : </td>
            <td>
                <asp:TextBox ID="txtStockLevel" runat="server"></asp:TextBox></td>
            <td>Stock Replacement Level : </td>
            <td>
                <asp:TextBox ID="txtStockLevelReplace" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Stock Level Type : </td>
            <td>
                <asp:DropDownList ID="ddlStockLevelType" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnClearStockItem" runat="server" Text="Reset" 
                    onclick="btnClearStockItem_Click" /></td>
            <td>
                <asp:Button ID="btnUpdateStockItem" runat="server" Text="Update" 
                    onclick="btnUpdateStockItem_Click1" /></td>
        </tr>
    </table>
    </div>
    <div style="visibility: hidden">
        <asp:HiddenField ID="hdnStockNumber" runat="server" />
        <asp:Button ID="btnUpdateStockItemHidden" runat="server" Text="Button" onclick="btnUpdateStockItem_Click" />
    </div>
    </form>
</body>
</html>
