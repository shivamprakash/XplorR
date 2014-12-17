<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="showTwitter.aspx.cs" Inherits="XplorR.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 >Twitter Stats about your favourite artist and your city</h2>
    <div style="margin-bottom:5px">
        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
    <br />
    </div>
    
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <asp:TextBox ID="txtResult" runat="server" Height="151px" TextMode="MultiLine" Width="383px"></asp:TextBox>
    <br />
    
    <div style="margin-top:110px;align-items:center;margin-left:500px">
    <asp:ImageButton ID="btnNext3" runat="server" ImageUrl="download.jpg" Width="128px" OnClick="btnNext3_Click"  />
        </div>
</asp:Content>
