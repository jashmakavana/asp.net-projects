<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2>State Add Edit Page</h2>
        </div>
    </div>    <br />
    <div class="row">
        <div class="col-md-4">
            Country
        </div>
        <div class="col-md-8">
            <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-select"></asp:DropDownList>
             
            <!--
                <asp:RequiredFieldValidator id="rfvCountryId" runat="server"
                ControlToValidate="ddlCountryID"
                ErrorMessage="Country name is a required field."
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
        </div><br />
    <div class="row">
        <div class="col-md-4">
            State Name
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control" />
            <!--<div class="col-md-2">
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="Enter State Name" ForeColor="Red" ToolTip="State Name - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>  
                 OR

            <asp:RequiredFieldValidator id="rfvStateNam" runat="server"
                ControlToValidate="txtStateName"
                ErrorMessage="State name is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>-->
            </div>
        </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            State Code  
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control" />
           <!-- <asp:RequiredFieldValidator id="rfvStateCode" runat="server"
            ControlToValidate="txtStateCode"
            ErrorMessage="State Code is a required field."
            ForeColor="Red">
        </asp:RequiredFieldValidator>-->
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
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

