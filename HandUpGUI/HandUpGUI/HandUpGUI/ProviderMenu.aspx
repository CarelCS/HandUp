<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProviderMenu.aspx.cs" Inherits="HandUpGUI.ProviderMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script language="javascript">
    function ChangemenuAreaByID(GroupID) {
        document.getElementById("<%= hdnGroupCurrentPrev.ClientID %>").value = document.getElementById("<%= hdnGroupCurrentPrev.ClientID %>").value + "|" + document.getElementById("<%= hdnGroupCurrent.ClientID %>").value;
        document.getElementById("<%= hdnGroupCurrent.ClientID %>").value = GroupID;
        var ClickChangeAlert = document.getElementById("<%= btnChangeGroup.ClientID %>");
        ClickChangeAlert.click();
    }

    function btnGoBackOneGroup() {
        var X = document.getElementById("<%= hdnGroupCurrentPrev.ClientID %>").value;
        //alert(X);
        var ArrayBack = X.split("|");
        var NewBack = "";
        for (i = 0; i < ArrayBack.length - 1; i++) {
            //alert(ArrayBack[i]);
            NewBack = NewBack + "|" + ArrayBack[i];
        }
        //alert(NewBack);
        document.getElementById("<%= hdnGroupCurrentPrev.ClientID %>").value = NewBack;
        document.getElementById("<%= hdnGroupCurrent.ClientID %>").value = ArrayBack[ArrayBack.length - 1];
        var ClickChangeAlert = document.getElementById("<%= btnChangeGroup.ClientID %>");
        ClickChangeAlert.click();
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddlMenuesAvailable" runat="server">
                </asp:DropDownList><br />
                <asp:Button ID="btnGoToMenu" runat="server" Text="Go to Menu" 
                    onclick="btnGoToMenu_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <input id="btnBackOneGroup" type="button" value="Back" onclick="btnGoBackOneGroup()" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvMenuGroup" runat="server"></div><br />
                <div id="dvMenuMain" runat="server"></div>
            </td>
        </tr>
    </table>    
        <asp:HiddenField ID="hdnGroupHeaders" runat="server" />
        <asp:HiddenField ID="hdnGroupCurrent" runat="server" />
        <asp:HiddenField ID="hdnMaxSubs" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdnGroupCurrentPrev" runat="server" />
        <asp:Button ID="btnChangeGroup" runat="server" Text="ChangeGroup" 
            onclick="btnChangeGroup_Click" />
    </div>
    </form>
</body>
</html>
