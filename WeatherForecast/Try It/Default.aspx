<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 643px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="CityTextBox" runat="server" OnTextChanged="TextBox1_TextChanged" style="margin-left: 5cm"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Get Weather Info" style="margin-left: 5cm" OnClick="SearchButton_Click" /><br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
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
    </form>
</body>
</html>
