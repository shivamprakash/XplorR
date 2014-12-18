<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="TryEventService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       
    </style>
    
</head>
<body style="height: 433px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <div  style="height: 249px">
            
            <asp:TextBox ID="txtQuery" runat="server" style="margin-left: 7cm" Height="22px" Width="227px" placeholder="Enter city"></asp:TextBox><br />
            <asp:Label ID="lblCity" runat="server" style="margin-left: 6cm;  " Text="For ex: Tempe/Phoenix/Los Angeles/New York"></asp:Label><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Service URL: <a href="http://">http://localhost:57675/EventService.svc</a><br />
            <div style="height: 111px">
                Name: Event Service<br />
                Service Description : Fetches the list of events(concerts,drama etc) in a city entered by users.<br />
                Method Name : GetEventList<br />
                Input Parameter: City(string)<br />
                Return : List of eventData object<br />
            </div>
            <br /><br />
            <asp:Button ID="btnGetEvent" runat="server" Text="Get List of Events" style="margin-left: 7.1cm" OnClick="btnGetEvent_Click" Height="30px" Width="232px" />
        </div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:HyperLinkField DataNavigateUrlFields="Url" DataTextField="Url" Text="Link to event" />
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
    </form>
</body>
</html>
