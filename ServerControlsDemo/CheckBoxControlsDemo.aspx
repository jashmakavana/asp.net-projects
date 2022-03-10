<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckBoxControlsDemo.aspx.cs" Inherits="ServerControlsDemo_CheckBoxControlsDemo" %>

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
                <div class="col-md-12">
                    <asp:CheckBox ID="chkCricket" runat="server" Text="Cricket" />&nbsp;
                    <asp:CheckBox ID="ChkReading" runat="server" Text="Reading" />&nbsp;
                    <asp:CheckBox ID="ChkDancing" runat="server" Text="Dancing" />&nbsp;
                    <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" />&nbsp; <br />
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>

                </div>
            </div>
      </div>
    </form>
</body>
</html>