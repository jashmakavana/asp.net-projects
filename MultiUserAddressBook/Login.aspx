<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MultiUserAddressBook_Login" %>

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
<body style="background-image: url(../contant/images/bg.jpg);">
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <h1>Existing User Login to MultiUser Address Book</h1><hr />
            </div>
        </div><br /> 
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8">
                <asp:Label runat="server" ID="lblMessage" ForeColor="Red" EnableViewState="false" />
            </div>
         </div>
        <br />
        <div class="row">
            <div class="col-md-4" align="right">
                <h3>User Name : </h3>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtUserNameLogin" runat="server" />
            </div>
        </div><br />
        <div class="row">
            <%--<div></div>--%>
            <div class="col-md-4" align="right" >
                <h3>Password : </h3>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPasswordLogin" type="password" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                
            </div>
            <div class="col-md-8">
                <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="btn btn-default btn-sm" OnClick="btnLogin_Click" />&nbsp;&nbsp;
                <asp:HyperLink runat="server" ID="hlRegister" Text="Create Account" CssClass="btn btn-primary btn-sm" NavigateUrl="~/MultiUserAddressBook/Register Page.aspx" />   
            </div>
            
        </div>
        <br />
        
    </div>
    </form>
</body>
</html>
