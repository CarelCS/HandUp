<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HandUpGUI._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript">
        function getOrientation() {
            return Math.abs(window.orientation) - 90 == 0 ? "landscape" : "portrait";
        };
        function getMobileWidth() {
            return getOrientation() == "landscape" ? screen.availHeight : screen.availWidth;
        };
        function getMobileHeight() {
            return getOrientation() == "landscape" ? screen.availWidth : screen.availHeight;
    </script>
    <p>
        <asp:Label ID="lblUser" runat="server" Text="User Name : "></asp:Label><asp:TextBox ID="txtUserName" runat="server" Text="Carel"></asp:TextBox><br />
        <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="Admin"></asp:TextBox>
        <asp:Label ID="lblLoginFailure" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="Button1_Click" />.<br /><br />
        <asp:Label ID="lblTableCode" runat="server" Text="Table Code : "></asp:Label><asp:TextBox ID="txtTableCode" runat="server"></asp:TextBox>
        <asp:Button ID="btnJoinTable" runat="server" Text="Join Table" 
            onclick="btnJoinTable_Click" />

    </p>
<script language="javascript" type="text/javascript">

</script>
</asp:Content>