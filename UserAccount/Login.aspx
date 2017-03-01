<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineShoppingWebApp.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="align-content:center;">
        <tr >
            <td align="left" colspan="2">
                <h2><strong>LOGIN</strong></h2>
            </td>
        </tr>
        <tr>
            <td >USERNAME : </td>
            <td align="left">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
                    ErrorMessage="USERNAME IS MISSING" ForeColor="Red" ControlToValidate="txtUserName" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>PASSWORD : </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                    ErrorMessage="PASSWORD IS MISSING" ForeColor="Red" ControlToValidate="txtPassword" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" Width="100px" BackColor="Green" CausesValidation="false"/>
                <br />
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="logintext" align="right" colspan="2">
                <h3>ARE YOU NEW USER? GO TO MY ACCOUNT AND SIGN UP FIRST.</h3>
            </td>
        </tr>
    </table>
</asp:Content>
