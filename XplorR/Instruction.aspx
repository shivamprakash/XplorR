<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Instruction.aspx.cs" Inherits="XplorR.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <h2>Instruction for using this application</h2>
    <div style="margin-bottom:10px"> 
        <asp:BulletedList ID="BulletedList1" runat="server"  BorderStyle="Groove" BorderColor="#6666ff" BackColor="Wheat">
            <asp:ListItem>Enter name and city on the home page.</asp:ListItem>
            <asp:ListItem>Click the arrow to go to the next page.</asp:ListItem>
            <asp:ListItem>All events going to happen in the city will be listed here.</asp:ListItem>
            <asp:ListItem>Click on Know more to get the popularity of the band/artist</asp:ListItem>
            <asp:ListItem>On clicking a page will be displayed which will have tweet count of that particular artist which u selected from the city which you gave. </asp:ListItem>
            <asp:ListItem>Also this page will also have trending topics from the city provided.</asp:ListItem>
            <asp:ListItem>On clicking next this will show latest news related to the artist/band.</asp:ListItem>
            <asp:ListItem>On clicking nect, weather data of the specified city will be displayed</asp:ListItem>
    </asp:BulletedList>
    </div>
    <h3 >Technical Information</h3>
    <asp:BulletedList ID="BulletedList2" runat="server"  BorderStyle="Groove" BorderColor="#6666ff" BackColor="Wheat">
        <asp:ListItem>Name is stored in cookie and displayed on top right corner.</asp:ListItem>
        <asp:ListItem>City is stored in session and used for fetching data.</asp:ListItem>
        <asp:ListItem>Name and city are checked using client side validation form javascript.</asp:ListItem>
        <asp:ListItem>All data retreived form web service is stored in cache for 10 mins which will be displayed nect time you land up  on the same page.</asp:ListItem>
        
        <asp:ListItem>List of services used are:</asp:ListItem>
        <asp:ListItem>Event Service(REST)</asp:ListItem>
        <asp:ListItem>TweetCounter(REST)</asp:ListItem>
        <asp:ListItem>Tweet Trending(REST)</asp:ListItem>
        <asp:ListItem>News Focus(SOAP)</asp:ListItem>
        <asp:ListItem>Weather dat(SOAP)</asp:ListItem>

    </asp:BulletedList>

   
    

   
</asp:Content>


