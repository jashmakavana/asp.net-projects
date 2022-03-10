<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country Add Edit Page</h2>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-4">
            Country Name
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control" />
            
                <asp:RequiredFieldValidator id="rfvCountryName" runat="server"
                ControlToValidate="txtCountryName"
                ErrorMessage="Please field Country name."
                ForeColor="Red">
                </asp:RequiredFieldValidator>
        </div>
    </div>
    
    <br />
    <div class="row">
        <div class="col-md-4">
            Country Code
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control" />
            
                <asp:RequiredFieldValidator id="rfvCountryCode" runat="server"
                ControlToValidate="txtCountryCode"
                ErrorMessage="Please field Country Code."
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
            
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" NavigateUrl="~/AdminPanel/Country/CountryList.aspx" />
        </div>
    </div>
</asp:Content>

