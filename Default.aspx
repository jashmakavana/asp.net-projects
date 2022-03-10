<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        UserName :
        <asp:TextBox ID="UserName" runat="server" BackColor="#66FFFF">Darshan</asp:TextBox>
        <br />
        Password&nbsp; :&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
        Address&nbsp;&nbsp;&nbsp; :&nbsp;
        <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
