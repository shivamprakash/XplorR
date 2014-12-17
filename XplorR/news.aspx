<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="XplorR.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>News of your favourite artist</h2>
    <p>Click the arrow below to go to next page</p>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:HyperLinkField DataNavigateUrlFields="Url" DataTextField="Url" NavigateUrl="Url" Text="URL" />
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>
    <br />
    <div style="margin-top:110px;align-items:center;margin-left:500px">
    <asp:ImageButton ID="btnNext3" runat="server" ImageUrl="download.jpg" Width="128px" OnClick="btnNext3_Click"  />
        </div>
</asp:Content>
