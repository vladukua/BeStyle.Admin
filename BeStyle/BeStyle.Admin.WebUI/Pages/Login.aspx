<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BeStyle.Admin.WebUI.Pages.Login" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnBody" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="log">
        <asp:Login ID="lgnLogin" runat="server" BackColor="White" BorderColor="#CCCC00" BorderPadding="2" BorderStyle="Inset"
                   DisplayRememberMe="False" UserNameLabelText="Admin Name:" CssClass="log" OnLoggingIn="lgnLogin_OnLoggingIn"
                    InstructionText="Type your Login/Email and Password below;"/>
    </div>  
</asp:Content>
