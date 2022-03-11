<%@ Page Title="" Language="C#" MasterPageFile="~/contant/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        .myCheckBoxList label {
            padding-right: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <%--<div class="row">
        <div class="col-md-12">
            <h2>Contact Add-Edit</h2>
        </div>
    </div> </br> --%>
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Label runat="server" CssClass="btn-outline-danger" ID="lblMessage" EnableViewState="false" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Country
        </div>
        <div class="col-md-8">
            <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-select" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            State
        </div>
        <div class="col-md-8">
            <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-select" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            City
        </div>
        <div class="col-md-8">
            <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-select" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            ContactCategory
        </div>
        <div class="col-md-8">
            <%--            <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-select"></asp:DropDownList>--%>
            <asp:CheckBoxList runat="server" ID="cblContactCategoryID" CssClass="myCheckBoxList" RepeatDirection="Horizontal" />

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Contact Name
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvContactName" runat="server"
                ControlToValidate="txtContactName"
                ErrorMessage="please enter Contact Name"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Contact No
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvContactNo" runat="server"
                ControlToValidate="txtContactNo"
                ErrorMessage="please enter Contact Number"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            WhatsApp No
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtWhatsAppNo" CssClass="form-control" />

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Birth Date
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control" TextMode="Date" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Email
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvEmail" runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="please enter Email"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Age
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Address
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvAddress" runat="server"
                ControlToValidate="txtAddress"
                ErrorMessage="please enter Address name"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Blood Group
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            Facebook ID
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtFacebookID" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            LinkedIN ID
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtLinkedINID" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server" Text="Upload Photo" ID="lblUploadPhoto"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:FileUpload ID="fuFileContactPhotoPath" runat="server" />
            <asp:HiddenField ID="hfContactPhotoPath" runat="server" />
            <br />
        </div>
    </div>
    <div class="row">
        <%--<div class="col-md-4">
                <asp:Label runat="server" ID="lblAttribute" Visible="false" Text="Photo Attribute"></asp:Label>
            </div>--%>
        <div class="col-md-4">
            <asp:HiddenField runat="server" ID="hfAttribute"></asp:HiddenField>
        </div>
    </div>

    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

