<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentInfo.aspx.cs" Inherits="Pages_Account_UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="font-weight: 700; text-align: right; width: 220px;">Card Type: </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True" Value="0">Master/Visa Card</asp:ListItem>
                    <asp:ListItem Value="1">Credit Card</asp:ListItem>
                    <asp:ListItem Value="2">Debit Card</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="DropDownList1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700; text-align: right; width: 220px;">Card Holder Name :</td>
            <td>
                <asp:TextBox ID="txtCardName" runat="server"  Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtCardName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700; text-align: right; width: 220px;">Card No :</td>
            <td>
                <asp:TextBox ID="txtCardNo" runat="server"  Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtCardNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700; text-align: right; width: 220px;">CVV Number :</td>
            <td>
                <asp:TextBox ID="txtCvv" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtCvv" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="font-weight: 700; text-align: right; width: 220px;">Expiration Date :</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtDate" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
    <tr>
             <td style="width: 220px; text-align: right;">
               <asp:Button ID="btnProceed" runat="server" Text="Place Order" Width="81px" Height="37px" style="text-align: right" OnClick="btnProceed_Click" />
            &nbsp;&nbsp;&nbsp;
                 </td>
        <td>
                 <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </td>
        </tr>
  
    </table>
</asp:Content>

