<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TextBoxDemo1.aspx.cs" Inherits="ServerControlsDemo_TextBoxDemo1aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/contant/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox ID="txtNo1" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnCopy" runat="server" OnClick="btnCopy_Click" Text="Copy" />
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtNo2" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
