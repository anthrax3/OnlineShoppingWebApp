<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="IncomeReport.aspx.cs" Inherits="OnlineShoppingWebApp.Admin.IncomeReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContectPlaceHolder1" runat="server">
     <div align="center">
        <asp:Label ID="lblTitle" runat="server" style="font-weight: 700">Income Report</asp:Label>
        <hr />
    </div>

    <table align="center" cellspacing="1" style="width: 100%; background-color: #FFFFFF;">
        <tr>
            <td align="center">
                <asp:RadioButtonList ID="rblIncomeFilter" runat="server" AutoPostBack="true"
                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIncomeFilter_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Today</asp:ListItem>
                    <asp:ListItem Value="2">This Month</asp:ListItem>
                    <asp:ListItem Value="3">This Year</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

         <tr>
             <td align="center">
                 &nbsp;
             </td>
         </tr>

         <tr>
             <td align="center">
                 <asp:Label ID="lblIncome" runat="server" ForeColor="Red"
                     Style="font-weight:700"></asp:Label>
             </td>
         </tr>

         <tr>
             <td align="center">
                  <asp:GridView ID="gvIncomeReport" runat="server" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
                    CellPadding="3" CellSpacing="1" GridLines="None" Width="100%" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100"/>
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" ItemStyle-Width="150" />
                        <asp:BoundField DataField="CustomerPhoneNo" HeaderText="PhoneNo" ItemStyle-Width="20"/>
                        <asp:BoundField DataField="TotalProducts" HeaderText="Products" ItemStyle-Width="150" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Price" ItemStyle-Width="150"/>
                        

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
             </td>
         </tr>
    </table>
</asp:Content>
