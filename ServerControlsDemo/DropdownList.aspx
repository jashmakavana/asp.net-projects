<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropdownList.aspx.cs" Inherits="List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Country:<asp:TextBox ID="txtCountry" runat="server" AutoPostBack="True"></asp:TextBox><br />
            Code:<asp:TextBox ID="txtCcode" runat="server" TextMode="Number" AutoPostBack="True"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>

            <br />
            <asp:Button ID="btnAdd" runat="server" style="margin-bottom: 0px" Text="Add" OnClick="btnAdd_Click" />
            &nbsp;
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
            
            <br /><hr />

         <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                <asp:ListItem Value="91">India</asp:ListItem>
            </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;
            
                   <asp:Button runat="server" ID="btnShowAllDdl" OnClick="btnShowDdl_Click" Text="Show All" />&nbsp;&nbsp;
            <asp:Button runat="server" ID="btnClearAllDdl" Text="Clear" OnClick="btnClearAllDdl_Click"/>
           
            <br />
        <asp:Label ID="lblShowCountryList" runat="server" />

        </div>
    </form>
</body>
</html>
