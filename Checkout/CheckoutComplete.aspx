<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckoutComplete.aspx.cs" Inherits="OnlineShoppingWebApp.Checkout.CheckoutComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Checkout Complete</h1>
    <p></p>
     <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/HappyShopping.jpg" Width="500px" />
    <br />
        <br />
                <h3>You Have Placed Order Successfully.</h3>
                        
                <p></p>
         
    <%--<asp:Label ID="lblTransactionNo" runat="server"></asp:Label><br />--%>
    <h3>Your Order Number:</h3><asp:Label ID="OrderNo" runat="server"></asp:Label>
    <br />
    <h3>Payment Transaction ID:</h3> <asp:Label ID="TransactionId" runat="server"></asp:Label>
    <p></p>
    <h3>Thank You!</h3>
    <p></p>
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continue Shopping" OnClick="Continue_Click" BackColor="green" ForeColor="white" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ddd"/>
</asp:Content>
