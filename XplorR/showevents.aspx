<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="showevents.aspx.cs" Inherits="XplorR.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
   
     
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:2px">
        <h2>List of Events</h2>
    <p> Click on know more to select Artist/Band. <br /> It will redirect you to a page containing Twitter stats</p>
    </div>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:HyperLinkField DataNavigateUrlFields="kmURL" HeaderText="Know more" NavigateUrl="kmURL" Text="Click Here" />
            <asp:HyperLinkField DataNavigateUrlFields="Url" HeaderText="Link to event" Text="Link to event" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
</asp:Content>
