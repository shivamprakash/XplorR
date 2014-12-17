<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="XplorR.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script type="text/JavaScript" >
           function validateCity() {
               var name = document.getElementById('<%=txtName.ClientID%>').value;
            var cityRegex = /^[a-zA-z] ?([a-zA-z]|[a-zA-z] )*[a-zA-z]$/;
            var nameregex = /^[a-zA-z] ?([a-zA-z]|[a-zA-z] )*[a-zA-z]$/;
            var city = document.getElementById('<%=txtCity.ClientID%>').value;
            if (city == '' || !cityRegex.test(city)) {
                alert('Enter a valid city');
                document.getElementById('<%=txtCity.ClientID%>').value = "";
                return false;
            }
            if (name == '' || !nameregex.test(name)) {
                alert('Enter a valid Name');
                document.getElementById('<%=txtName.ClientID%>').value = "";
                return false;
            }
            return true;
        }
</script>
    
    <div id="login" style="margin-top:5px" >
    <h2 > Your one stop to entertainment search</h2>
    <div style="float:left; margin-right:2px"> <asp:Label ID="lblEnterName" runat="server" Text="Enter Name : " Font-Italic="true"></asp:Label> </div>
    <div style="margin-left:2px"><asp:TextBox ID="txtName" runat="server" BorderStyle="Groove" ></asp:TextBox></div> <br /><br />
    <div style="float:left; margin-right:4px"> <asp:Label ID="Label1" runat="server" Text="Enter City : " Font-Italic="true"></asp:Label></div> 
    <asp:TextBox ID="txtCity" runat="server" BorderStyle="Groove">      </asp:TextBox> <br />
        <p>Ex: New York, Los Angeles</p>
        <p>Note: Weather service not working for Phoenix.</p>
    <div style="margin-left:113px"><asp:ImageButton ID="btnSave" runat="server" OnClientClick="return validateCity()" OnClick="btnSave_Click" ImageUrl="~/save-button-png-hi.png" Width="78px" Height="41px" /></div>
        
        <p>Click the arrow below to go to next page</p>
    <div style="margin-top:80px;align-items:center;margin-left:500px">
        <asp:ImageButton ID="btnNext1" runat="server" ImageUrl="download.jpg" Width="128px" OnClick="btnNext1_Click"/>
    </div>
    </div>
    
</asp:Content>
