<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineShoppingWebApp.Account.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1 style="text-align: center"><span style="font-weight: normal"><strong><span style="color: #006600; ">SIGN UP AS A NEW MEMBER</span></strong></span></h1>

    <table style="color: #006600; ">
        <tr>
            <td>First Name: </td>
            <td style="width: 426px">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="FirstName is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Last Name: </td>
            <td style="width: 426px">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="LastName is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>Username:</td>
            <td style="width: 426px">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                    ControlToValidate="txtUsername" ErrorMessage="Username is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
             </td>
        </tr>

         <tr>
            <td style="height: 26px">Password:</td>
            <td style="width: 426px; height: 26px;">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" 
                    ErrorMessage="Password is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
             </td>
        </tr>

         <tr>
            <td style="height: 30px">ConfirmPassword:</td>
            <td style="height: 30px; width: 426px;">
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidatorConfirm" runat="server" 
                    ControlToValidate="txtConfirm" ErrorMessage="Password must be same." ForeColor="Red" 
                    ControlToCompare="txtPassword" ></asp:CompareValidator>
             </td>
        </tr>

         <tr>
            <td>Email:</td>
            <td style="width: 426px">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtEmail" 
                    ErrorMessage="Please enter a valid email." ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
             </td>
        </tr>

         <tr>
            <td>Address:</td>
            <td style="width: 426px">
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                    ControlToValidate="txtAddress" ErrorMessage="Address is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
             </td>
        </tr>

         <tr>
            <td style="height: 30px">City :</td>
            <td style="height: 30px; width: 426px">
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                    ControlToValidate="txtCity" ErrorMessage="City is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
             </td>
        </tr>

        <tr>
            <td>Country:</td>
            <td style="width: 426px">
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" 
                    ControlToValidate="txtCountry" ErrorMessage="Country is missing." ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

       

        <tr >
            
            <td align="center" >
                <asp:Button ID="btnRegistration" runat="server" Text="SIGN UP" OnClick="btnRegistration_Click" BackColor="#006600"/>
                <asp:Label ID="lblResult" runat="server"></asp:Label>
                <br />
               

            </td>
            <td>
                <input id="Reset" style="width: 64px; margin-left: 0px" type="reset" value="RESET" />
            </td>
        </tr>
         
    </table>
</asp:Content>
