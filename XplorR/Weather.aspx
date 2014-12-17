<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="XplorR.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Plan your booking according to weather</h2>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="MaxTemp" HeaderText="MaxTemp" />
            <asp:BoundField DataField="MinTemp" HeaderText="MinTemp" />
            <asp:BoundField DataField="Wind" HeaderText="Wind" />
            <asp:BoundField DataField="Humidity" HeaderText="Humidity" />
            <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
            </asp:ImageField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    
</asp:Content>
