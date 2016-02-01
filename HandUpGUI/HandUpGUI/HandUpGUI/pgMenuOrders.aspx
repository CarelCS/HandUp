<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgMenuOrders.aspx.cs" Inherits="HandUpGUI.pgMenuOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    </style>
</head>
<script type="text/javascript">

    function GoToAddSpace(URL) {
        var win = window.open(URL, '_blank');
        win.focus();
    }

    function OpenTable(Number) {
        document.getElementById("<%= hdnTableNumber.ClientID %>").value = Number;
        var ClickChangeTable = document.getElementById("<%= btnChangeTable.ClientID %>");
        ClickChangeTable.click();
    }

    function OpenTableDDL() {
        var CurrentTable = document.getElementById("TableSelectDDL");
        document.getElementById("<%= hdnTableNumber.ClientID %>").value = CurrentTable.value;
        var ClickChangeTable = document.getElementById("<%= btnChangeTable.ClientID %>");
        ClickChangeTable.click();
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
        var Counter = document.getElementById("<%= hdnMaxSubs.ClientID %>").value;
        document.getElementById("<%= hdnOrderSelectValues.ClientID %>").value = OrderID + "|";
        for (i = 0; i < Counter; i++) {
            try {
                var SelectID = OrderID + "_ddlFirstSub_" + i;
                var LiStAsk = document.getElementById(SelectID);
                var SelVal = LiStAsk.value;
                document.getElementById("<%= hdnOrderSelectValues.ClientID %>").value += "~ " + SelVal + " ";
            }
            catch (ex) { 
            }
        }
        var ClickChangeAlert = document.getElementById("<%= btnPlaceOrder.ClientID %>");
        ClickChangeAlert.click();
    }

    function openOrderTextWindow() {
        newWindow = window.open("", null, "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no");
        newWindow.document.write("<textarea id=\"txtAddArea\" cols=\"20\" rows=\"2\"></textarea><br /><input id=\"btnTextAddConfirm\" type=\"button\" onclick=\"window.opener.setValue(document.getElementById('txtAddArea').value);window.close();\" value=\"Add Text\" />");
        var TextValue = window.opener.document.getElementById("<%= hdnTextForOrder.ClientID %>").value;
        if (TextValue != "") {
            newWindow.close();
        }
    }

    function setValue(value) {
        document.getElementById("<%= hdnTextForOrder.ClientID %>").value = value;
        var ClickChangeAlert = document.getElementById("<%= btnUpdateTextValues.ClientID %>");
        ClickChangeAlert.click();
    }

    function openOrderConfirmAlertWindow(value) {
        //alert("WHAT THE HELL " + value);
        document.getElementById("<%= hdnAlertWindowOpen.ClientID %>").value = "OPEN";
        newWindow = window.open("", null, "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no");
        var MyArray2 = value.split("~");
        //alert("THIS GUI : "  + MyArray2[1]);
        document.getElementById("<%= hdnCurrentTableGUI.ClientID %>").value = MyArray2[1];
        newWindow.document.write("<table><tr><td>" + value + "</td></tr><tr><td><textarea id=\"txtAddGUI\" cols=\"20\" rows=\"2\"></textarea></td></tr><tr><td><input id=\"btnTextAddConfirm\" type=\"button\" onclick=\"window.opener.setAlertValue(document.getElementById('txtAddGUI').value);window.close();\" value=\"Confirm the GUI\" /></td></tr></table>");
    }

    function setAlertValue(value) {
       // document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
       // document.getElementById("<%= hdnAlertWindowOpen.ClientID %>").value = "";
       // document.getElementById("<%= hdnTextForAlertGUI.ClientID %>").value = value + "~" + document.getElementById("<%= hdnCurrentTableGUI.ClientID %>").value;
        var ClickChangeAlert = document.getElementById("<%= btnUpdateAlertConfirmed.ClientID %>");
        ClickChangeAlert.click();
    }

    function AcceptConfirm(value) {
        document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
        document.getElementById("<%= hdnTextForAlertGUI.ClientID %>").value = value;
        var ClickChangeAlert = document.getElementById("<%= btnUpdateAlertConfirmed.ClientID %>");
        ClickChangeAlert.click();
    }

    function AddTextTable(OrderID) {
        document.getElementById("<%= hdnOrderNumber.ClientID %>").value = OrderID;
        openOrderTextWindow();
    }

    function ChangeDivDisplay() {
        DivDisplay = document.getElementById("<%= hdnDisplayAreas.ClientID %>").value;
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

    function ChangeDiv(DivDisplay) {
        document.getElementById("<%= hdnDisplayAreas.ClientID %>").value = DivDisplay;
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

    setInterval(myCheckAlert, 10000);

    function myCheckAlert() {
        //alert("CHECK THIS BEFORE : " + document.getElementById("<%= lblAlert.ClientID %>").innerHTML);
        var CurrentAlert = document.getElementById("<%= lblAlert.ClientID %>").innerHTML;
        document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
        //alert("CHECK THIS AFTER : " + document.getElementById("<%= lblAlert.ClientID %>").innerHTML);
        if (CurrentAlert != "") {
            var MyArray2 = CurrentAlert.split("|");
            for (i = 0; i < MyArray2.length - 1; i++) {
                var ConfirmNow = confirm(MyArray2[i]);
                var CurrentAlertToDisplay = MyArray2[i];
                if (ConfirmNow) {
                    document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
                    //alert("YES");
                    //var IsOpen = "test";  //document.getElementById("<%= hdnAlertWindowOpen.ClientID %>").value;
                    //if (IsOpen == "") {
                    i = MyArray2.length - 1;
                    //alert("in here " + CurrentAlert);
                    //openOrderConfirmAlertWindow(CurrentAlert);
                    AcceptConfirm(CurrentAlertToDisplay);
                    document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
                    //}
                }
                else {
                    document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
                }
            }
        }
        //document.getElementById("<%= lblAlert.ClientID %>").innerHTML = "";
        //alert("WHAT THE FUCK : " + document.getElementById("<%= lblAlert.ClientID %>").innerHTML);
        var ClickChangeAlert = document.getElementById("<%= btnAlertUpdate.ClientID %>");
        ClickChangeAlert.click();
    }

    function ChangemenuArea(GroupID) {
        var X = document.getElementById("<%= hdnGroupHeaders.ClientID %>").value;
        var MyArray2 = X.split("|");
        for (i = 0; i < MyArray2.length - 1; i++) {
            document.getElementById("dvGroup" + MyArray2[i]).style.display = 'none';
        }
        document.getElementById(GroupID).style.display = '';
        document.getElementById("<%= hdnGroupCurrent.ClientID %>").value = GroupID;
    }

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

    function CallWaiter() {
        document.getElementById("<%= hdnAlertText.ClientID %>").value = "Call waiter";
        var ClickChangeAlert = document.getElementById("<%= btnAlertSent.ClientID %>");
        ClickChangeAlert.click();
    }

    function CloseBill() {
        document.getElementById("<%= hdnAlertText.ClientID %>").value = "Close Bill";
        var ClickChangeAlert = document.getElementById("<%= btnAlertSent.ClientID %>");
        ClickChangeAlert.click();
    }

    function CloseTable() {
        document.getElementById("<%= hdnAlertText.ClientID %>").value = "Close Table";
        var ClickChangeAlert = document.getElementById("<%= btnAlertSent.ClientID %>");
        ClickChangeAlert.click();
    }
</script>
<body style="background-image:url(Images/Icons/BG.jpg); background-size: 100%; background-repeat:no-repeat; border:0;">
    <form id="form1" runat="server" enableviewstate="true" >
    <asp:Button ID="btnLogout" runat="server" Text="Logout" 
        onclick="btnLogout_Click" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%" style="background-color:transparent; height:100%">
            <tr align="center">
                <td align="center">
                    <div id="dvAddArea" runat="server"></div>
                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td>
                <div>
                    <asp:Label ID="lblEmployeeUserName" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div id="dvWaiterMenu">
                    <table width="100%">
                        <tr>
                            <td>
                                <div id="dvTablesTop" runat="server">
                                </div>
                            </td>
                            <td>
                                <input id="Button1" type="button" value="Go to Table" onclick="OpenTableDDL()" />
                            </td>
                            <td>
                                <input id="Button2" type="button" value="Add a Table" onclick="ShowAdd()"/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:Label ID="lblTableOpened" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
     </table>
     <table>
        <tr>
            <td><div id="dvCallWaiter" onclick="CallWaiter()" runat="server"><img id="imgCallWaiter" src="Images/Icons/CallWaiter.png" runat="server" /></div></td>
            <td><div id="dvCloseBill" onclick="CloseBill()" runat="server"><img id="imgCloseBill" src="Images/Icons/CloseBill.png" runat="server"  /></div></td>
            <td><div id="dvCloseTable" onclick="CloseTable()" runat="server"><img id="imgCloseTable" src="Images/Icons/CloseTable.png" runat="server"  /></div></td>
        </tr>
    </table>
    <table border="0" width="100%">
        <tr>
            <td id="tdMenu" onclick="ChangeDiv('Menu')">
                <img id="imgMenu" src="Images/Icons/Menu.png" runat="server"  />
            </td>
            <td id="tdOrder" onclick="ChangeDiv('Order')">
                <img id="imgOrders" src="Images/Icons/Orders.png" runat="server"  />
            </td>
            <td id="tdSplit" onclick="ChangeDiv('Split')">
                <img id="imgAll" src="Images/Icons/All.png" runat="server"  />
            </td>
            <td id="td1" onclick="ChangeDiv('Hide')">
                <img id="imgHide" src="Images/Icons/Hide.png" runat="server"  />  
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <div id="dvAddTable" style="display: none;">
                    <table width="100%">
                        <tr>
                            <td>
                                Add Table
                            >
                            <td>
                                <asp:Label ID="tblTableName" runat="server" Text="Table Name"></asp:Label>
                                <asp:TextBox ID="txtTableName" runat="server"></asp:TextBox><br />
                                <asp:DropDownList ID="ddlPatronCount" runat="server">
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
                                </asp:DropDownList>
                                <br />
                                <asp:Button ID="btnAddTable" runat="server" Text="+" OnClick="btnAddTable_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvMenu" style="display: inline;">
                    <table width="100%">
                        <tr>
                            <td>
                                <input id="btnBackOneGroup" type="button" value="Back" onclick="btnGoBackOneGroup()" /></td>
                        </tr>
                        <tr>
                            <td>
                            <div id="dvMenuGroup" runat="server"></div><br />
                            <div id="dvMenuMain" runat="server"></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvOrderList" style="display: inline;">
                    <table width="100%">
                        <tr>
                            <td>
                                THE ORDER LIST
                                <div id="dvTablesOrders" runat="server">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    
                </div>
            </td>
        </tr>
        <tr>
            <td>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblTableGUI" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWaiterName" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <div id="dvWaiterImage" runat="server"></div>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>
   
    <div style="visibility: hidden">
        <asp:UpdatePanel ID="updateAlerts" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnAlertUpdate" runat="server" Text="Update" OnClick="btnAlertUpdate_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="visibility: hidden">
        <asp:Button ID="btnChangeTable" runat="server" Text="Change Table" OnClick="btnChangeTable_Click" />
        <asp:Button ID="btnUpdateTextValues" runat="server" Text="UPdateText" OnClick="btnUpdateTextValues_Click" />
        <asp:Button ID="btnUpdateAlertConfirmed" runat="server" Text="Alert Confirm" onclick="btnUpdateAlertConfirmed_Click" />
        <asp:Button ID="btnPlaceOrder" runat="server" Text="Button" onclick="btnPlaceOrder_Click" />
        <asp:Button ID="btnUpdateOrderStatus" runat="server" Text="Button" OnClick="btnUpdateOrderStatus_Click" />
        <asp:Button ID="btnAlertSent" runat="server" Text="ALERT" onclick="btnAlertSent_Click" />
        <asp:Button ID="btnChangeGroup" runat="server" Text="ChangeGroup" onclick="btnChangeGroup_Click" />
        <asp:HiddenField ID="hdnTableNumber" runat="server" />
        <asp:HiddenField ID="hdnTextForOrder" runat="server" />
        <asp:HiddenField ID="hdnOrderNumber" runat="server" />
        <asp:HiddenField ID="hdnTableCodeOnlyGuest" runat="server" />
        <asp:HiddenField ID="hdnMaxSubs" runat="server" />
        <asp:HiddenField ID="hdnOrderSelectValues" runat="server" />
        <asp:HiddenField ID="hdnOrderStatus" runat="server" />
        <asp:HiddenField ID="hdnGroupHeaders" runat="server" />
        <asp:HiddenField ID="hdnGroupCurrent" runat="server" />
        <asp:HiddenField ID="hdnTextForAlertGUI" runat="server" />
        <asp:HiddenField ID="hdnAlertWindowOpen" runat="server" />
        <asp:HiddenField ID="hdnAlertText" runat="server" EnableViewState="false" ViewStateMode="Disabled" />
        <asp:HiddenField ID="hdnDisplayAreas" runat="server" />
        <asp:HiddenField ID="hdnGroupCurrentPrev" runat="server" />
        <asp:HiddenField ID="hdnCurrentTableGUI" runat="server" />
    </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    if (document.getElementById("<%= hdnTableCodeOnlyGuest.ClientID %>").value != "") {
        document.getElementById('dvWaiterMenu').style.display = 'none';
    }
    ChangeDivDisplay();
    document.getElementById("<%= hdnAlertText.ClientID %>").value = "";
</script>
</html>
