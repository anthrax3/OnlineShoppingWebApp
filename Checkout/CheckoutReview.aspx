<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="OnlineShoppingWebApp.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <h1>Order Review</h1>
    <p></p>
    <h3 style="padding-left: 33px">Products:</h3>
    <asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="10" Width="500" BorderColor="#efeeef" BorderWidth="33">              
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" />        
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" />        
            <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice" DataFormatString="{0:c}"/>     
            <asp:BoundField DataField="ProductQuantity" HeaderText="ProductQuantity" />        
        </Columns>    
    </asp:GridView>
    <asp:DetailsView ID="ShipInfo" runat="server" AutoGenerateRows="False" GridLines="None" CellPadding="10" BorderStyle="None" CommandRowStyle-BorderStyle="None">
        <Fields>
        <asp:TemplateField>
            <ItemTemplate>
                <h3>Shipping Address:</h3>
                <br />
                <asp:Label ID="FirstName" runat="server" Text='<%#: Eval("FirstName") %>'></asp:Label>  
                <asp:Label ID="LastName" runat="server" Text='<%#: Eval("LastName") %>'></asp:Label>
                <br />
                <asp:Label ID="Address" runat="server" Text='<%#: Eval("Address") %>'></asp:Label>
                <br />
                <asp:Label ID="City" runat="server" Text='<%#: Eval("City") %>'></asp:Label>
                <asp:Label ID="State" runat="server" Text='<%#: Eval("State") %>'></asp:Label>
                <asp:Label ID="PostalCode" runat="server" Text='<%#: Eval("PostalCode") %>'></asp:Label>
                <p></p>
                <h3>Order Total:</h3>
                <br />
                $<asp:Label ID="Total" runat="server" Text='<%#: Eval("Total") %> '></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
          </Fields>
    </asp:DetailsView>
    <p></p>
    <hr />
    <p></p>
     <p></p>
    <asp:Button ID="CheckoutConfirm" runat="server" Text="Complete Order" OnClick="CheckoutConfirm_Click" BackColor="green" ForeColor="white" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ddd"/>
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" OnClick="btnCancel_Order" Width="115px" BackColor="red" ForeColor="white" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ddd"/>
     <p></p>
     <p></p>
</asp:Content>

