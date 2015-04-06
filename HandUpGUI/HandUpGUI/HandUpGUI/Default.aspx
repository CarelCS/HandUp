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
    </script>
    <p>
    <table width="100%" >
        <tr>
            <td align="right"><asp:Label ID="lblUser" runat="server" Text="User Name : "></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtUserName" runat="server" Text="Carel"></asp:TextBox></td>
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
    </table>
        
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