<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
     CodeBehind="Products.aspx.cs" Inherits="OnlineShoppingWebApp.Admin.Products" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<script runat="server">
    private void OnRecordDeleted(object source, SqlDataSourceStatusEventArgs e) {
     Label1.Text = e.AffectedRows + " row(s) were deleted";
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContectPlaceHolder1" runat="server">
     <div align="center">
        <asp:Label ID="lblTitle" runat="server" style="font-weight: 700">All Products In Stock</asp:Label>
        <hr />
    </div>
    <table align="center" cellspacing="1" style="width: 100%; background-color: #FFFFFF;">
        <tr>
            <td align="center">
                <asp:GridView ID="gvAvailableProducts" runat="server" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
                    CellPadding="3" CellSpacing="1" GridLines="None" Width="100%" AutoGenerateColumns="false" 
                    DataKeyNames="ProductID" AllowPaging="true" >
                    <Columns>
                         <asp:CommandField ShowDeleteButton="true" ButtonType="Button"/>
                        <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                        <asp:BoundField DataField="Name" HeaderText="ProductName" ItemStyle-Width="150"/>
                        <asp:BoundField DataField="CategoryName" HeaderText="ProductCategory" ItemStyle-Width="50" />
                        <asp:BoundField DataField="AvailableStock" HeaderText="AvailableStock" ItemStyle-Width="150"
                            ItemStyle-Font-Bold="true" ItemStyle-Font-Size="Larger"/>
                        <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="150"/>
                        <asp:ImageField DataImageUrlField="ImageUrl" HeaderText="ImageUrl" ControlStyle-Width="150" ControlStyle-Height="50"/>
                       
                    </Columns>

                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="true" ForeColor="#E7E7FF"/>
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center"/>
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="true" ForeColor="White"/>
                    <SortedAscendingCellStyle BackColor="#F1F1F1"/>
                    <SortedAscendingHeaderStyle BackColor="#594B9C"/>
                    <SortedDescendingCellStyle BackColor="#cac9c9"/>
                    <SortedDescendingHeaderStyle BackColor="#33276a"/>
                </asp:GridView>

                <asp:Label ID="Label1" runat="server"></asp:Label>
                <%--ConnectionString="<%$ ConnectionStrings:MyConn %>"--%>
                 <%--<connectionStrings>
                    <add name="MyConn" connectionString="Data Source=DESKTOP-Q7GJCB3\SQLEXPRESS;Initial Catalog=ShoppingCartDB;Integrated Security=True" providerName="System.Data.SqlClient"/>
                  </connectionStrings>--%>
                <%--<asp:SqlDataSource ID="SqlDataSource_Products" runat="server"
                  ConnectionString="<%$ ConnectionStrings:MyConn %>"
                    SelectCommand="SELECT * FROM [Products]"
                    DeleteCommand="DELETE FROM Products WHERE ProductID = @ProductID"
                    OnDeleted="OnRecordDeleted" ProviderName="<%$ ConnectionStrings:MyConn.ProviderName %>">
                    <DeleteParameters>
                        <asp:Parameter Name="ProductID" />
                    </DeleteParameters>
                </asp:SqlDataSource>--%>
            </td>
        </tr>
    </table>
</asp:Content>
