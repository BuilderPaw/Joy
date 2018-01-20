<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="login">
        <h1 style="margin-top:1px; margin-left:1px;color:teal;font-size:30px;font-weight:600;">Club Reports</h1>
        <!--<asp:Textbox id="txtDomain" value="MRSLGROUP" width="80%" style="text-align: center;" enabled="false" runat="server"></asp:Textbox>
        <br />-->
        <b>Username:</b>
        <asp:Textbox id="txtUsername" width="60%" CssClass="object-default" style="margin-left:20%;" runat="server"></asp:Textbox>
        <br />
        <b>Password:</b>
        <asp:Textbox id="txtPassword" width="60%" CssClass="object-default" style="margin-left:20%;" runat="server" textmode="Password"></asp:Textbox>
        <br />
        <br />
        <asp:Button id="btnLogin" runat="server" text="Login" CssClass="btn" onclick="btnLogin_Click"></asp:Button>
        <br />
        <asp:Label id="errorLabel" runat="server" forecolor="#ff3300"></asp:Label>
        <br />
    </div>
</asp:Content>

