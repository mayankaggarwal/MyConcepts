<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserAuth.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Please Login</h1>
    <p>UserName:<asp:TextBox ID="UserName" runat="server"></asp:TextBox></p>
    <p>Password:<asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></p>
    <p><asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /></p>
    <p>
        <asp:Label ID="BadCredentials" runat="server" ForeColor="Red" Visible="false" Text="The credentials that you entered are invalid. Please try again."></asp:Label>
    </p>
</asp:Content>
