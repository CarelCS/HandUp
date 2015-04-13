<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HandUpGUI._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript">
        function getOrientation() {
            return Math.abs(window.orientation) - 90 == 0 ? "landscape" : "portrait";
        };
        function getMobileWidth() {
            var WidthHere = getOrientation() == "landscape" ? screen.availHeight : screen.availWidth;
            document.getElementById("<%= screenHeight.ClientID %>").value = WidthHere;
            return WidthHere;
        };
        function getMobileHeight() {
            var HeightHEre = getOrientation() == "landscape" ? screen.availWidth : screen.availHeight;
            document.getElementById("<%= screenWidth.ClientID %>").value = HeightHEre;
            return HeightHEre;
        };

        function Sizes() {
            getMobileWidth();
            getMobileHeight();
        };

        function openOrderTextWindow() {
            newWindow = window.open("", null, "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no");
            newWindow.document.write("<textarea id=\"txtTableCode\" cols=\"20\" rows=\"1\"></textarea><br /><input id=\"btnTableCodeConfirm\" type=\"button\" onclick=\"window.opener.setValue(document.getElementById('txtTableCode').value);window.close();\" value=\"Confirm Table Code\" />");
            var TextValue = window.opener.document.getElementById("<%= txtTableCode.ClientID %>").value;
            //alert(TextValue);
            if (TextValue != "") {
                newWindow.close();
            }
        }
        
        function setValue(value) {
            document.getElementById("<%= hdnTableCode.ClientID %>").value = value;
            var ClickChangeAlert = document.getElementById("<%= btnUpdateTableCode.ClientID %>");
            ClickChangeAlert.click();
        }

    </script>
    <p>
    <table width="100%" >
        <tr>
            <td align="right"><asp:Label ID="lblUser" runat="server" Text="User Name : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtUserName" runat="server" Text="Carine"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="Admin"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblLoginFailure" runat="server" Text=""></asp:Label></td>
            <td align="left"><asp:Button ID="btnLogin" runat="server" Text="Login" onclick="Button1_Click" /></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblTableCode" runat="server" Text="Table Code : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtTableCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right"></td>
            <td align="left"><asp:Button ID="btnJoinTable" runat="server" Text="Join Table" onclick="btnJoinTable_Click" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnRegister" runat="server" Text="Register" 
                    onclick="btnRegister_Click" /></td>
        </tr>
    </table>
        <asp:HiddenField ID="hdnTableCode" runat="server" />
        <asp:Button ID="btnUpdateTableCode" runat="server" Text="Button" 
            onclick="btnUpdateTableCode_Click" />
        <asp:HiddenField ID="screenHeight" runat="server" />
        <asp:HiddenField ID="screenWidth" runat="server" />
        <div style="visibility:collapse">
            <asp:Button ID="btnSendSize" runat="server" Text="Button" onclick="btnSendSize_Click" />
        </div>

    </p>
<script language="javascript">

    var chkPostBack = '<%= Page.IsPostBack ? "true" : "false" %>';
    if (chkPostBack == "false") {
        Sizes();
        var ClickChangeAlert = document.getElementById("<%= btnSendSize.ClientID %>");
        ClickChangeAlert.click();
    }
</script>
</asp:Content>