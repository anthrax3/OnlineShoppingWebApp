<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineShoppingWebApp.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         .logintext > h3{
            color:#fc7a00;
        }
        .dropbtn {
            background-color: #4CAF50;
            color: white;
            padding: 16px;
            font-size: 16px;
            border: none;
            cursor: pointer;
        }

        .dropdown {
            position: relative;
            display: inline-block;
            
        }

        .dropdown-content {
            display: none;
            position: absolute;
            right: 0;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        }

        .dropdown-content a {
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
        }

        .dropdown-content a:hover {background-color: #f1f1f1}

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown:hover .dropbtn {
            background-color: #3e8e41;
        }
       
        .style1
        {
            width: 1080px;
          
        }
        .style2{
            width: 733px;
           
            text-align: left;
        }
        .style3{
            width: 257px;
           
            text-align: center;
        }
        .style4{
            width: 185px;
            text-align: center;
        }
        .style6{
            width: 260px;
            text-align: left;
        }
        .style7{
            width: 427px;
            text-align: center;
        }
        .style8{
            width: 108px;
            text-align: center;
            
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <table align="center" class="style1" style="background-color:whitesmoke;">
                <tr style="background-color:#f0f0f0;">
                    <td>
                        <table align="center" class="style1" style="border-bottom-style: ridge; border-width: medium; border-color: #9933FF;">
                            <tr >
                               
                                <td class="style6" rowspan="2">
                                   <asp:LinkButton ID="lblLogo" runat="server" Text="24HOURSSHOPPING.COM" Font-Names="Eras Demi ITC"
                                    Font-Size="20pt" ForeColor="#6600CC" OnClick="lblLogo_Click"></asp:LinkButton>
                                    <br />
                                    All Over The World!
                                </td>
                                <td class="style7" rowspan="2">
                                     
                                    &nbsp;
                                    <asp:TextBox ID="txtSearch" runat="server"  ForeColor="GrayText" Width="300px" height="20px"></asp:TextBox>
                                    <asp:LinkButton ID="btnSearchProduct" runat="server" Font-Underline="false" Font-Size="14pt"
                                        ForeColor="White" BackColor="green" height="25px" OnClick="btnSearchProduct_Click" >Search</asp:LinkButton>
                                
                                </td>
                                <td rowspan="2" align="right">
                                    <asp:Image ID="Image2" runat="server" Height="53px" ImageUrl="~/Images/Shopping-cart-icon.jpg" Width="40px"/>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="btnShoppingCart" runat="server" Font-Underline="false" Font-Size="20pt"
                                        ForeColor="Red" OnClick="btnShoppingCart_Click">0</asp:LinkButton>
                                </td>
                                <td align="right">
                                    
                                        <asp:Label ID="lblLogin" runat="server" ForeColor="#6600CC" Text="Login" Font-Size="20px" ></asp:Label>
                                        <asp:LinkButton ID="btnLogin" runat="server" ForeColor="#6600CC" OnClick="btnLogin_Click">LoginButton</asp:LinkButton>
                                    
                                </td>
                                <td align="right">
                                    
                                     <div class="dropdown">
                                        
                                            <button class="dropbtn">My Account</button>
                                                <div class="dropdown-content">
                                                  
                                                    <asp:LinkButton ID="btnRegistration" runat="server"  OnClick="btnRegistration_Click">SIGN UP</asp:LinkButton>
                                                    <%--<a href="~/UserAccount/Registration.aspx" runat="server">SIGN UP</a>--%>
                                                    <a href="~/UserAccount/PurchaseHistory.aspx" runat="server">PURCHASE HISTORY</a>
                                                    <a href="~/UserAccount/EditUserProfile.aspx" runat="server">EDIT PROFILE</a>
                                                    <a href="TrackYourOrder.aspx" target="_blank">TrackYourOrderStatus</a>
                                                    <asp:Label ID="lblTest" runat="server"></asp:Label>
                                                </div>
                                                                                    
                                    </div>
                                </td>
                                
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr style="background-color:#283890;">
                    <td>
                        <table align="center" class="style1" style="border: thin ridge #9900FF">
                            <tr>
                                <td class="style2" style="border-right-style: ridge; border-width: thin; border-color: #9900FF">
                                    &nbsp;
                                    <asp:Label ID="lblCategoryName" runat="server" Font-Size="15pt" ForeColor="#ffffff"></asp:Label>
                                </td>
                                
                                <td class="style3" style="border-left-style: ridge; border-width: thin; border-color: #9900FF">
                                    &nbsp;
                                    <asp:Label ID="lblProducts" runat="server" Text="Product Categories" Font-Size="15pt" ForeColor="#ffffff"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <table align="center" class="style1">
                            <tr>
                                <td class="style2" valign="top">
                                    <asp:Panel ID="pnlProducts" runat="server" ScrollBars="Auto" Height="750px" BorderColor="Black"
                                        BorderStyle="Inset" BorderWidth="1px">
                                        <asp:DataList ID="dlProducts" runat="server" RepeatColumns="4" Width="700px" Font-Bold="False"
                                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" >
                                            <ItemTemplate>
                                                <div align="left">
                                                    <table cellspacing="1" class="style4" style="border: 1px ridge #9900FF">
                                                        <tr>
                                                            <td style="border-bottom-style: ridge; border-width: 1px; border-color: #000000">
                                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' 
                                                                    style="font-weight: 700"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <img alt="" src='<%# Eval("ImageUrl") %>' runat="server" id="imgProductPhoto"
                                                                    style="border: ridge 1px black; width: 173px; height:160px;" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                                <asp:Image ID="imgStar" runat="server" Visible="false" ImageUrl="~/Images/GreenStar1.png"
                                                                style="width:15px; height:15px;"/>
                                                                Stock:&nbsp;
                                                                <asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>'
                                                                    ToolTip="Available Stock" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ProductID") %>'
                                                                    OnClick="btnAddToCart_Click" Text="Add To Cart" Width="100%"
                                                                    BorderColor="Black" BorderStyle="Inset" BorderWidth="1px" CausesValidation="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="33%" />
                                        </asp:DataList>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlMyCart" runat="server" ScrollBars="Auto" Height="750px" BorderColor="Black"
                                        BorderStyle="Inset" BorderWidth="1px" Visible="false">
                                        <table align="center" cellspacing="1">
                                            <tr>
                                                <td align="left" >
                                                    <!--h3><p style="color:red">Please Review Your Order!</p></!--h3-->
                                                    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblAvailableStockAlert" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                    <asp:DataList ID="dlCartProducts" runat="server" RepeatColumns="3" Font-Bold="false"
                                                        Font-Italic="false" Font-Overline="false" Font-Strikeout="false" Font-Underline="false"
                                                        Width="651px">
                                                        <ItemTemplate>
                                                            <div align="left">
                                                                <table cellspacing="1" style="border: 1px ridge #9900FF; text-align: center; width: 172px;">
                                                                    <tr>
                                                                         <td style="border-bottom-style: ridge; border-width: 1px; border-color: #000000">
                                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' 
                                                                                style="font-weight: 700"></asp:Label>
                                                                         </td>
                                                                    </tr>

                                                                     <tr>
                                                                         <td>
                                                                            <img alt="" src='<%# Eval("ImageUrl") %>' runat="server" id="imgProductPhoto"
                                                                                style="border: ridge 1px black; width: 157px; height: 130px;" />
                                                                        </td>
                                                                     </tr>

                                                                     <tr>
                                                                         <td>
                                                                             AvailableStock:&nbsp;
                                                                             <asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>' 
                                                                                 ToolTip="Available Stock" ForeColor="Red" 
                                                                                 Font-Bold="true"></asp:Label>

                                                                             <br />
                                                                             Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                                             &nbsp;*&nbsp;
                                                                             <asp:TextBox ID="txtProductQuantity" runat="server" Width="20px" Height="10px"
                                                                                 MaxLength="1" OnTextChanged="txtProductQuantity_TextChanged"
                                                                                 AutoPostBack="true" Text='<%# Eval("ProductQuantity") %>'></asp:TextBox>
                                                                             <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                                         </td>
                                                                     </tr>

                                                                     <tr>
                                                                         <td>
                                                                             <asp:Button ID="btnRemoveFromCart" runat="server" CommandArgument='<%# Eval("ProductID") %>'
                                                                                 Text ="RemoveFromCart" Width="100%" BorderColor="Black" BorderStyle="Inset"
                                                                                 BorderWidth="1px" OnClick="btnRemoveFromCart_Click" CausesValidation="false" BackColor="OrangeRed"/>
                                                                         </td>
                                                                     </tr>
                                                                 
                                                                </table>                                                                       
                                                            </div>
                                                                  
                                                        </ItemTemplate>
                                                        <ItemStyle Width="33%" />
                                                       
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                     <asp:ImageButton ID="CheckoutImageBtn" runat="server" 
                                                                                  ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" 
                                                                                  Width="170" AlternateText="Check out with PayPal" 
                                                                                  OnClick="CheckoutBtn_Click" 
                                                                                  BackColor="Transparent" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ddd"/> 
                                                </td>
                                                                                              
                                            </tr>
                                            <tr>
                                                 <td>
                                                    
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                 <td >
                                                     <asp:Button ID="Continue" runat="server" Width="170" Text="Continue Shopping" OnClick="Continue_Click" BackColor="green" ForeColor="#0654ba" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ddd"/>
                                                </td>
                                            </tr>
                                        </table>
                                        
                                    </asp:Panel>
                                </td>

                                <td class="style3" valign="top" align="center"> 
                                    <asp:Panel ID="pnlCategories" runat="server" ScrollBars="Auto" Height="750px" BorderColor="Black"
                                        BorderStyle="Inset" BorderWidth="1px">
                                        <asp:DataList ID="dlCategories" runat="server" CellPadding="4" ForeColor="#333333"
                                            width="252px">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnCategory" runat="server" Text='<%# Eval("CategoryName") %>'
                                                    OnClick="lbtnCategory_Click" CommandArgument='<%# Eval("CategoryID")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="true" ForeColor="#333333" />
                                        </asp:DataList>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlCheckOut" runat="server" ScrollBars="Auto" Height="750px" BorderColor="Black"
                                        BorderStyle="Inset" BorderWidth="1px" Visible="false">
                                        <table style="width: 258px;">
                                            <tr>
                                                <td align="left">
                                                   Full Name:
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCustomerName" runat="server" Width="231px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server"  ControlToValidate="txtCustomerName" 
                                                        ErrorMessage="*" ForeColor="Red"  Display="Dynamic" EnableClientScript="false" ></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    PhoneNo:
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCustomerPhoneNo" runat="server" Width="231px" MaxLength="10"></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="rfvCustomerPhoneNo" runat="server" ControlToValidate="txtCustomerPhoneNo"
                                                        ErrorMessage="*" ForeColor="Red" Display="Dynamic" EnableClientScript="false"  ></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td align="left">
                                                    EmailID
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCustomerEmailID" runat="server" Width="231px" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvCustomerEmailID" runat="server" ControlToValidate="txtCustomerEmailID"
                                                        ErrorMessage="*" ForeColor="Red" Display="Dynamic" EnableClientScript="false" ></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td align="left">
                                                    Address
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCustomerAddress" runat="server" Width="231px"
                                                       Height="81px" TextMode="MultiLine"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="rfvCustomerAddress" runat="server" ControlToValidate="txtCustomerAddress"
                                                        ErrorMessage="*" ForeColor="Red" Display="Dynamic" EnableClientScript="false" ></asp:RequiredFieldValidator> 
                                                </td>
                                            </tr>

                                             <tr>
                                                <td align="left">
                                                    Total Products :
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                   <asp:TextBox ID="txtTotalProducts" runat="server" ReadOnly="true" Width="231px" ></asp:TextBox>
                                                   
                                                </td>
                                            </tr>

                                             <tr>
                                                <td align="left">
                                                    Total Price :
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                   <asp:TextBox ID="txtTotalPrice" runat="server" ReadOnly="true" Width="231px" ></asp:TextBox>
                                                   
                                                </td>
                                            </tr>

                                             <tr>
                                                <td align="left">
                                                    Product Name :
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                   <asp:TextBox ID="txtProductName" runat="server" ReadOnly="true" Width="231px" ></asp:TextBox>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Shipping and Handling :
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                   <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                                       <asp:ListItem Value="" Selected="True">FREE SHIPPING</asp:ListItem>
                                                        <asp:ListItem Value="" >EXPRESS DELIVERY</asp:ListItem>
                                                        <asp:ListItem Value="" >REGULAR DELIVERY</asp:ListItem>
                                                   </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Payment Mode :
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                   <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                                                       <asp:ListItem Value="1" Selected="True">1. PAYPAL PAYMENT</asp:ListItem>
                                                       <asp:ListItem Value="2">2. BANK TRANSFER</asp:ListItem>
                                                       <asp:ListItem Value="3">3. CARD PAYMENT</asp:ListItem>
                                                   </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>                                            

                                             <tr>
                                                <td>
                                                                                                         
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ControlToValidate="txtCustomerEmailID" ErrorMessage="Please Enter Valid EmailID"
                                                        ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                                        <div style="text-align:center;">
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/EmptyShoppingCart1.jpg" Width="500px" />
                                             <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlOrderPlacedSuccessfully" runat="server" Visible="false">
                                        <div style="text-align:center;">
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/HappyShopping.jpg" Width="500px" /><br />
                                            <br />
                                            <label>
                                                Order Placed Successfully.
                                            </label><br />
                                            <br />
                                            Transaction Details are Sent At EmailID Provided By You.<br />
                                            <br />
                                            <br />
                                            <asp:Label ID="lblTransactionNo" runat="server" style="font-weight: 700;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </asp:Label>
                                            <br />
                                            <br />
                                            <br />
                                            <a href="TrackYourOrder.aspx" target="_blank">TrackYourTransactionDetailsHere</a>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>

                            <tr style="background-color:lightgray; height:100px;">
                                <td colspan="2" align="center" style="border:thin ridge #9900FF">
                                     &nbsp;&copy;Copyright 2016 By Mahfuz 
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
