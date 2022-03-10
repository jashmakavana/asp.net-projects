<%@ Page Language="C#" AutoEventWireup="true" CodeFile="validationaspx.aspx.cs" Inherits="validationaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>validation</title>
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="/contant/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</head>
<body>
    
    <div>
        <form id="form2" runat="server">
    
    
    <legend>Student Enrollment Form</legend>
    <hr />
    <div class="container">
        <div class="row">
            
            <div class="col-md-4">
                <br />
                <asp:Label runat="server"  Text="Name" ID="lblName"></asp:Label>
                <label id="lblCompulsory">*</label>
                <label>:</label>
                <asp:TextBox ID="txtName" runat="server" ToolTip="Enter a Name" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                 <br />
                 <asp:Label runat="server"  Text="Enrollment Number" ID="lblEnrollmentNo"></asp:Label>
                 <label id="lblCompulsory">*</label>
                 <label>:</label>
                <asp:TextBox ID="txtEnrollmentNo" runat="server" ToolTip="Enter a Enrollment Number" Class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvEnrollmentNo" runat="server" ControlToValidate="txtEnrollmentNo" Display="Dynamic" ErrorMessage="Enter 12 digit Enrollment No" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="revEnrollmentNumber" runat="server" ControlToValidate="txtEnrollmentNo" Display="Dynamic" ErrorMessage="Please Enter a Darshan's Enrollment Numbers" ForeColor="Red" ValidationExpression="[0-9]{2}[0][5][4][0-9]{7}" ValidationGroup="Save"></asp:RegularExpressionValidator>
                 <br />
            </div>
            <hr />
        </div>
        <div class="row">
            <div class="col-md-6">
                <br />
                <asp:Label runat="server" Text="Institute" ID="lblInstitute"></asp:Label>
                <label id="lblCompulsory">*</label>
                <label>:</label>
                <asp:DropDownList ID="ddlInstitute" runat="server" ToolTip="Select a Institute" Class="form-control">
                    <asp:ListItem Value="-1" Text="Select Institute"></asp:ListItem>
                    <asp:ListItem Value="DIET" Text="Darshan Institute of Engineering & Technology"></asp:ListItem>
                    <asp:ListItem Value="DIETDS" Text="Darshan Institute of Engineering & Technology for Diploma Studies"></asp:ListItem>
                    <asp:ListItem Value="SOE" Text="School of Engineering - Darshan University"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" ControlToValidate="ddlInstitute" Display="Dynamic" ErrorMessage="Select Institute" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>

        </div>
        <div class="row">
            <div class="col-md-6">
                <br />
                <asp:Label runat="server" Text="Department" ID="lblDepartment"></asp:Label>
                <label id="lblCompulsory">*</label>
                <label>:</label>
                <asp:DropDownList ID="ddlDepartment" runat="server" ToolTip="Select a Department" Class="form-control">
                    <asp:ListItem Value="-1" Text="Select Department"></asp:ListItem>
                    <asp:ListItem Value="CE" Text="Computer Engineering"></asp:ListItem>
                    <asp:ListItem Value="Cl" Text="Civil Engineering"></asp:ListItem>
                    <asp:ListItem Value="ME" Text="Mechanical Engineering"></asp:ListItem>
                    <asp:ListItem Value="EE" Text="Electrical Engineering"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Select Department" ForeColor="Red" InitialValue="-1" Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <br />
            </div>
            <hr />
        </div>
        <div class="row">
            <div class="col-md-3">
                <br />
                <asp:Label runat="server" Text="BirthDate" ID="lblBirthDate"></asp:Label>
                <label>:</label>
                <asp:TextBox ID="txtBirthDate" runat="server" ToolTip="Enter Your BirthDate" Class="form-control"></asp:TextBox>
                <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Please enter a Valid Date" ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="Save"></asp:CompareValidator>
            </div>
            <div class="col-md-3">
                 <br />
                <asp:Label runat="server" Text="Semester" ID="lblSemester"></asp:Label>
                <label>:</label>
                <asp:TextBox ID="txtSemester" runat="server" ToolTip="Enter Semester" Class="form-control"></asp:TextBox>
                <asp:RangeValidator ID="rvSemester" runat="server" ControlToValidate="txtSemester" Display="Dynamic" ErrorMessage="Enter a Semester (Between 1 to 8)" ForeColor="Red" MaximumValue="8" MinimumValue="1" Type="Integer" ValidationGroup="Save"></asp:RangeValidator>
            </div>
            <div class="col-md-3">
                 <br />
                <asp:Label runat="server" Text="Email" ID="lblEmail"></asp:Label>
                <label>:</label>
                <asp:TextBox ID="txtEmail" runat="server" ToolTip="Enter Email id" Class="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid email address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-3">
                 <br />
                <asp:Label runat="server" Text="Mobile Number" ID="lblMobileNo"></asp:Label>
                <label id="lblCompulsory">*</label>
                <label>:</label>
                <asp:TextBox ID="txtMobile" runat="server" ToolTip="Enter Mobile" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Enter 10 digit Mobile Number" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                 <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Please enter valid indian number" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" ValidationGroup="Save"></asp:RegularExpressionValidator>

            </div>
             <div class="col-md-6">
                <br />
                <asp:Label runat="server" Text="Password" ID="lblPassword"></asp:Label>
                 <label id="lblCompulsory">*</label>
                <label>:</label>
                <asp:TextBox ID="txtPassword" runat="server" ToolTip="Enter Strong Password" Class="form-control" type="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter a Strong Password" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                 <asp:RegularExpressionValidator ID="rvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password Contain (Fix 8 characters length,2 UpperCase Character,1 Sppecial Character,2 Numerals,3 Lowecase Character)" ForeColor="Red" ValidationExpression="^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&amp;*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$" ValidationGroup="Save"></asp:RegularExpressionValidator>

            </div>
            <div class="col-md-6">
                <br />
                <asp:Label runat="server" Text="Re-type Password" ID="lblReTypePassword"></asp:Label>
                <label>:</label>
                <asp:TextBox ID="txtReTypePassword" runat="server" ToolTip="Enter Same Password" Class="form-control" type="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReTypePassword" runat="server" ControlToValidate="txtReTypePassword" ErrorMessage="Enter Re Password" ForeColor="Red" Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvReTypePassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtReTypePassword" Display="Dynamic" ErrorMessage="Re Type Password Should be same as Password" ForeColor="Red" ValidationGroup="Save"></asp:CompareValidator>

            </div>
            
            <div class="row">
                <br /><div class="col-md-12">
                <asp:Label runat="server" ForeColor="Red" ID="lblSave" EnableViewState="False"></asp:Label>
                </div>
            </div>
            <div>
                <br />
                <br />
               <asp:CheckBox ID="cbTerms" runat="server" Tooltip="Please select this checkbox" Text="Terms and Conditions are applied." EnableViewState="false"/>
                <asp:CustomValidator ID="cuvTerms" runat="server" ClientValidationFunction="Validatecheckbox" Display="Dynamic" ErrorMessage="Please Select this Checkbox" ForeColor="Red" OnServerValidate="cuvTerms_ServerValidate" ValidationGroup="Save"></asp:CustomValidator>
                <br />
                <asp:Button runat="server" Text="Save" ID="btnSave" Class="btn btn-success" OnClick="btnSave_Click" ValidationGroup="Save"/>
                
            </div>
        </div>
    </div>
    </form>
    </div>
    
</body>
</html>
