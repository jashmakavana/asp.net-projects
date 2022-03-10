<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TextBoxDemoCalc.aspx.cs" Inherits="ServerControlsDemo_TextBoxDemoCalc" %>

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
                <div class="col-md-3">
                    <asp:TextBox ID="txtNo1" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblMsg1" runat="server" style="color:red"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtNo2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblMsg2" runat="server" style="color:red"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnAdd" runat="server" Text="Add (+)" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSub" runat="server" Text="Sub(-)" OnClick="btnSub_Click" />
                    <asp:Button ID="btnMul" runat="server" Text="Mul(*)" OnClick="btnMul_Click" />
                    <asp:Button ID="btnDiv" runat="server" Text="Div(/)" OnClick="btnDiv_Click" />
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="lblAnswer" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblMsg3" runat="server" style="color:red"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
