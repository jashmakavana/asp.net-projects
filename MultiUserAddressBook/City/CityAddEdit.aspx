<%@ Page Title="" Language="C#" MasterPageFile="~/contant/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="MultiUserAddressBook_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <%--<div class="row">
        <div class="col-md-12">
            <h2></h2>
        </div>
    </div>--%>    
    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Label runat="server" CssClass="btn-outline-danger" ID="lblMessage" EnableViewState="false" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            State
        </div>
        <div class="col-md-8">
            <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-select"></asp:DropDownList>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-4">
            City Name
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvCityName" runat="server"
                ControlToValidate="txtCityName"
                ErrorMessage="please enter City Name"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            STD Code
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtStdCode" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvStdCode" runat="server"
                ControlToValidate="txtStdCode"
                ErrorMessage="please enter STD Code"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            PIN Code
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" />
            <!--
                <asp:RequiredFieldValidator id="rfvPincode" runat="server"
                ControlToValidate="txtPinCode"
                ErrorMessage="please enter Pin Code"
                ForeColor="Red">
                </asp:RequiredFieldValidator>-->
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

