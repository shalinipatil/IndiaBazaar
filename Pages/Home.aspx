<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Pages_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align: left">
    Select Product Type :
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sdsType" DataTextField="type" DataValueField="type" AutoPostBack="True" style="text-align: left">
    </asp:DropDownList>
    <asp:SqlDataSource ID="sdsType" runat="server" ConnectionString="<%$ ConnectionStrings:GroceryDBConnectionString %>" SelectCommand="SELECT DISTINCT [type] FROM [Product] ORDER BY [type]"></asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</p>
</asp:Content>

