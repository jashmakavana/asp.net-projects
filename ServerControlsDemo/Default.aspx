<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="/contant/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
        
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="3">
                    country:<asp:TextBox ID="txt1" runat="server" />
                    <br />
                    value:<asp:TextBox ID="txt2" runat="server" />
                    <br />
                    country new:<asp:TextBox ID="newtxt1" runat="server" />
                    <br />
                    value:<asp:TextBox ID="newtxt2" runat="server" />
                    <br />
                    <asp:Button ID="btncChange" runat="server" Text="Change" OnClick="btncChange_Click" />
                    <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnRemove" runat="server" Text="REMOVE" OnClick="btnRemove_Click" />
                </td>
            </tr>         
            <tr>
                <td>
                    <asp:ListBox ID="lbCountry" runat="server" Rows="3" SelectionMode="Multiple" OnSelectedIndexChanged="lbCountry_SelectedIndexChanged" >
                    </asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnRight" runat="server" Text=">" OnClick="btnRight_Click" />
                    <br />
                    <asp:button ID="btnLeft" runat="server" Text="<" OnClick="btnLeft_Click" />
                    <br />
                    <asp:Button ID="btnAllRight" runat="server" Text=">>" OnClick="btnAllRight_Click" />
                    <br />
                    <asp:Button ID="btnAllLeft" runat="server" Text="<<" OnClick="btnAllLeft_Click" />
                </td>
                <td>
                    <asp:ListBox ID="lb2Country" runat="server" Rows="3" SelectionMode="Multiple">

                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="show" OnClick="btnShow_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatus" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
