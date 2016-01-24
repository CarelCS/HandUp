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

        function Login() {
            var ClickChangeTable = document.getElementById("<%= btnJoinTable.ClientID %>");
            ClickChangeTable.click();
        }

        function Register() {
            var ClickChangeTable = document.getElementById("<%= btnRegister.ClientID %>");
            ClickChangeTable.click();
        }
    </script>
    <%--<asp:Button ID="btnLogout" runat="server" Text="Logout" onclick="btnLogout_Click" />--%>
    <table width="100%" border="0" style="background-color:transparent; background-size: 100%; background-repeat:no-repeat; border:0;">
        <tr>
            <td colspan="2" align="center">
                <asp:Image ID="Image3" ImageUrl="~/Images/Icons/Logo-01.png" runat="server" /></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblUser" runat="server" Text="User Name : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtUserName" runat="server" Text="Carine"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="Admin"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblTableCode" runat="server" Text="Table Code : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtTableCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right"><div id="dvRegister" onclick="Register()">
                <asp:Image ID="Image2" ImageUrl="~/Images/Icons/Register-01.png" runat="server" /></div></td>
            <td align="left"><div id="dvLogin" onclick="Login()">
                <asp:Image ID="Image1" ImageUrl="~/Images/Icons/Login-01.png" runat="server" /></div></td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblLoginFailure" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
    </table>
        <asp:HiddenField ID="screenHeight" runat="server" />
        <asp:HiddenField ID="screenWidth" runat="server" />
        <div style="visibility:collapse">
            <asp:Button ID="btnRegister" runat="server" Text="Register" onclick="btnRegister_Click" />
            <asp:Button ID="btnJoinTable" runat="server" Text="Join Table" onclick="btnJoinTable_Click" />
            <asp:Button ID="btnSendSize" runat="server" Text="Button" onclick="btnSendSize_Click" />
        </div>
<script language="javascript">

    var chkPostBack = '<%= Page.IsPostBack ? "true" : "false" %>';
    if (chkPostBack == "false") {
        Sizes();
        var ClickChangeAlert = document.getElementById("<%= btnSendSize.ClientID %>");
        ClickChangeAlert.click();
    }
</script>
</asp:Content>