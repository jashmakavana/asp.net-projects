<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register Page.aspx.cs" Inherits="MultiUserAddressBook_Register_Page" EnableEventValidation="false"  %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="/contant/js/bootstrap.bundle.min.js"></script>
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="/contant/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    
</head>
<body class="img js-fullheight" style="background-image: url(../contant/images/bg.jpg);">
    <form id="form1" runat="server">
	<section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Register Your Page</h2>
				</div>
			</div>
            <div class="row">
                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <asp:Label runat="server" ID="lblMessage" ForeColor="red" EnableViewState="false" />
                                </div>
                             </div>
			<div class="row justify-content-center">
				<div class="col-md-6 "> <!-- class="col-lg-4" -->
					
		      	<%--<h3 class="mb-4 text-center">Have an account?</h3>--%>
		        <form action="#" class="signin-form">
                            <div class="form-group">
                                    <asp:TextBox ID="txtUserName" runat="server" type="text" CssClass="form-control" placeholder="Username"  /><!-- khali required lakhvanu che bajuma e client side validation che-->
                                       <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Enter Unique Name" ForeColor="Red" ToolTip="UserName - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                            
                            <div class="form-group">
                                   <asp:TextBox ID="txtPassword" runat="server" type="password" CssClass="form-control" placeholder="Password"  /><!-- khali required lakhvanu che bajuma e client side validation che-->
                                    <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password" runat="server" ></span> 
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Your Password" ForeColor="Red" ToolTip="Password - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>           
                            </div>
                    
                            <div class="form-group">
                                    <asp:TextBox ID="txtDisplayName" runat="server" type="text" CssClass="form-control" placeholder="DisplayName"  /><!-- khali required lakhvanu che bajuma e client side validation che-->
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtDisplayName" Display="Dynamic" ErrorMessage="Enter Display Name" ForeColor="Red" ToolTip="DisplayName - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>         
                       
                            <div class="form-group">
                                    <asp:TextBox ID="txtMobileNo" runat="server" type="text" CssClass="form-control" placeholder="MobileNo"  /><!-- khali required lakhvanu che bajuma e client side validation che-->
                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Your Mobile Number" ForeColor="Red" ToolTip="Mobile Number - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>  
                            </div>
                                
                             <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" type="text" CssClass="form-control" placeholder="Email" /><!-- khali required lakhvanu che bajuma e client side validation che-->
                                    <asp:RegularExpressionValidator ID="rgvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter a Valid email id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>
                             </div>
	                        <div class="row form-group">	            	            
                                <div class="col-md-4">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="form-control btn btn-primary submit px-3" OnClick="btnRegister_Click"/>&nbsp;&nbsp;</div>
                                <div class="col-md-4">
                                    <asp:Button runat="server" ID="btnCancel" ToolTip="Cancel" Text="Cancel" CssClass="form-control btn btn-danger submit px-3" OnClick="btnCancel_Click"  />
                                </div>
                                <div class="col-md-4">
                                    <asp:HyperLink runat="server" ID="hlAlreadyUser" Text="Already User ?" BackColor="Window" CssClass="btn btn-btn-block" NavigateUrl="~/MultiUserAddressBook/Login.aspx" />   <!-- CssClass="btn btn-btn-default btn-sm" -->
                                </div>
                                
	                        </div>
                            <div class="row">
                                <div class="col-md-4"></div>
                                
				            </div>
	                        <!--<div class="form-group d-md-flex">
	            	            <div class="w-50">
		            	            <label class="checkbox-wrap checkbox-primary">Remember Me
									              <input type="checkbox"  runat="server"  />
									              <span class="checkmark"></span>
									            </label>
								            </div>
								            <div class="w-50 text-md-right">
									            <a href="#" style="color: #fff">Forgot Password</a>
								            </div>                    
	                        </div>-->
	          </form>
		      </div>
				
		 </div>

		</div>
	</section>

	<script src="~/contant/css/js/jquery.min.js"></script>
  <script src="~/contant/css/js/popper.js"></script>
  <script src="~/contant/css/js/bootstrap.min.js"></script>
  <script src="~/contant/css/js/main.js"></script>
    </form>
</body>
</html>
