<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HandUpGUI._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:Label ID="lblUser" runat="server" Text="User Name : "></asp:Label><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblLoginFailure" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="Button1_Click" />.<br /><br />
        <asp:Label ID="lblTableCode" runat="server" Text="Table Code : "></asp:Label><asp:TextBox ID="txtTableCode" runat="server"></asp:TextBox>
        <asp:Button ID="btnJoinTable" runat="server" Text="Join Table" 
            onclick="btnJoinTable_Click" />
    </p>
</asp:Content>
