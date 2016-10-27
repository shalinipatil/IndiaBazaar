<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderProduct.aspx.cs" Inherits="Pages_OrderProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnOk" runat="server" Text="Ok" Visible="False" Width="100px"  onclick="btnOk_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False"  Width="100px" onclick="btnCancel_Click" />
   
    &nbsp;&nbsp;
   
    <asp:Button ID="btnOrder" runat="server" Text="Order!"  onclick="btnOrder_Click" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
   <asp:Panel ID="pnlProducts" runat="server">
    </asp:Panel>
   
    

</asp:Content>

