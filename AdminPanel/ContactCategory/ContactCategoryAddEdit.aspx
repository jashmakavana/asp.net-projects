<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>ContactCategory Add Edit Page</h2>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-4">
            ContactCategory Name
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtContactCategoryName" CssClass="form-control" />
            
                <asp:RequiredFieldValidator id="rfvContactCategoryName" runat="server"
                ControlToValidate="txtContactCategoryName"
                ErrorMessage="Please field Contact Category Name."
                ForeColor="Red">
                </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Label runat="server" CssClass="btn-outline-danger" ID="lblMessage" EnableViewState="false" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click"/>
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryList.aspx" />
        </div>
    </div>

</asp:Content>

