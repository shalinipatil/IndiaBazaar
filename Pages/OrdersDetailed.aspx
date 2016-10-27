<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="OrdersDetailed.aspx.cs" Inherits="Pages.Pages_OrdersDetailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="12" DataSourceID="sdsdetail" ForeColor="Black" 
        GridLines="Vertical" Width="503px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="PRoductOrdered" HeaderText="PRoductOrdered" 
                SortExpression="PRoductOrdered" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" 
                ReadOnly="True" SortExpression="Amount" />
            <asp:BoundField DataField="Price" HeaderText="Price" 
                SortExpression="Price" />
            <asp:CheckBoxField DataField="OrderShipped" HeaderText="OrderShipped" 
                SortExpression="OrderShipped" />
            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" 
                ReadOnly="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="sdsdetail" runat="server" ConnectionString="<%$ ConnectionStrings:GroceryDBConnectionString %>" SelectCommand="Select PRoductOrdered, SUM(Amount) As Amount,Price,OrderShipped, SUM(Amount*Price) As Total
from Orders where ClientName = @client And PurchasedDate = @date
GROUP BY PRoductOrdered, Price, OrderShipped ">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="client" QueryStringField="client" />
            <asp:QueryStringParameter DbType="Date" DefaultValue="" Name="date" QueryStringField="date" />
        </SelectParameters>
</asp:SqlDataSource>
    <br />
    <asp:Button ID="btnShip" runat="server" Height="41px" Text="Ship Order" 
        Width="125px" onclick="btnShip_Click" />
    <br />
    </asp:Content>

